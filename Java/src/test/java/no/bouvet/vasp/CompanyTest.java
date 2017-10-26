package no.bouvet.vasp;

import static org.junit.Assert.assertEquals;

import java.io.ByteArrayInputStream;
import java.nio.charset.StandardCharsets;

import javax.xml.parsers.DocumentBuilder;
import javax.xml.parsers.DocumentBuilderFactory;
import javax.xml.xpath.XPath;
import javax.xml.xpath.XPathFactory;

import org.json.JSONArray;
import org.json.JSONObject;
import org.junit.Test;
import org.w3c.dom.Document;

/**
 * Et Company har flere Workers, og ønsker å kunne generere ansatt-rapporter i
 * tillegg til å kunne beregne årlige kostnader og gjennomsnittlig timekost.
 * Akkurat nå finnes det to rapporter, en XmlReport og en JsonReport Den
 * abstrakte klassen Worker har to implementasjoner, Employee og Consultant.
 * Oppgaven går ut på å refaktorere slik at denne logikken flyttes ut av Worker
 * og sub-klasser uten å bryte testene. Bruk Strategy til å generere rapporter
 * og Visitor til å beregne årlig kost og gjennomsnittlig timekost.
 * 
 * http://www.oodesign.com/visitor-pattern.html
 * http://www.oodesign.com/strategy-pattern.html
 */
public class CompanyTest {

    // Bruk strategy-pattern
    @Test
    public void generateJsonReport_should_return_all_properties_of_all_workers_as_Json()
    {
        Company company = createTestCompany();
        String jsonReport = company.generateJsonReport();

        JSONObject jsonObject = new JSONObject(jsonReport);

        JSONObject erna = findWorker(jsonObject, "Erna Solberg");
        assertEquals("CEO", erna.getString("Position"));

        JSONObject bjarne = findWorker(jsonObject, "Bjarne Håkon Hanssen");
        assertEquals("First House", bjarne.getString("Company"));

        JSONObject siv = findWorker(jsonObject, "Siv Jensen");
        assertEquals("CFO", siv.getString("Position"));
    }
    
    // Bruk strategy-pattern
    @Test
    public void generateXmlReport_should_return_all_properties_of_all_workers_as_Xml() throws Exception
    {
        Company company = createTestCompany();
        String xmlReport = company.generateXmlReport();

    	XPath xpath = XPathFactory.newInstance().newXPath();
    	DocumentBuilder dBuilder = DocumentBuilderFactory.newInstance().newDocumentBuilder();
    	Document document = dBuilder.parse(new ByteArrayInputStream(xmlReport.getBytes(StandardCharsets.UTF_8.name())));
   	
    	String ernaPosition = xpath.compile("/Workers/Worker[Name='Erna Solberg']/Position").evaluate(document);
        assertEquals("CEO", ernaPosition);

    	String bjarneCompany = xpath.compile("/Workers/Worker[Name='Bjarne Håkon Hanssen']/Company").evaluate(document);
        assertEquals("First House", bjarneCompany);

        String sivPosition = xpath.compile("/Workers/Worker[Name='Siv Jensen']/Position").evaluate(document);
        assertEquals("CFO", sivPosition);
    }

	// Bruk Visitor-pattern
	@Test
	public void calculateYearlyCost_should_calculate_yearly_cost_for_all_workers() {
		Company company = createTestCompany();
		double result = company.calculateYearlyCost();
		assertEquals(3000000.0, result, 0.01);
	}

	// Bruk Visitor-pattern
	@Test
	public void calculateAverageHourlyCost_should_calculate_based_on_150_working_hours_per_month_adjusted_for_parttime_percentage() {
		Company company = createTestCompany();
		double result = company.calculateAverageHourlyCost();
		assertEquals(594.44, result, 0.01);
	}

	private static Company createTestCompany() {
		Company company = new Company();
		company.addWorker(new Employee("Erna Solberg", "CEO", 100000, 100));
		company.addWorker(new Consultant("Bjarne Håkon Hanssen", "First House", 80000));
		company.addWorker(new Employee("Siv Jensen", "CFO", 70000, 80));
		return company;
	}
	
	private static JSONObject findWorker(JSONObject report, String name) {
        JSONArray workers = report.getJSONArray("Workers");

        for (int i = 0; i < workers.length(); i++) {
        	JSONObject worker = workers.getJSONObject(i);
        	if (name.equals(worker.getString("Name"))) {
        		return worker;
        	}
        }
		return null;
	}
}
