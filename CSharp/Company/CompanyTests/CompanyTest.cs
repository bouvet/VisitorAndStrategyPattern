using Company;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Linq;
using System.Xml.Linq;
using Newtonsoft.Json.Linq;

namespace CompanyTests
{
    /* Den abstrakte klassen Worker har to implementasjoner, Employee og Consultant.
     * Begge disse klassene implementerer metodene ReportPlainText, ReportJson, CalculateYearlyCost og CalculateHourlyCost.
     * Oppgaven går ut på å refaktorere slik at denne logikken flyttes ut av Worker og sub-klasser uten å bryte testene.
     * Bruk Strategy til å generere rapporter og Visitor til å beregne årlig kost og gjennomsnittlig timekost.
     * http://www.oodesign.com/visitor-pattern.html
     * http://www.oodesign.com/strategy-pattern.html
     */

    [TestClass]
    public class CompanyTest
    {
        private Company.Company CreateTestCompany()
        {
            var company = new Company.Company();
            company.AddWorker(new Employee("Erna Solberg", "CEO", 100000, 100));
            company.AddWorker(new Consultant("Bjarne Håkon Hanssen", "First House", 80000));
            company.AddWorker(new Employee("Siv Jensen", "CFO", 70000, 80));
            return company;
        }

        // Bruk strategy-pattern
        [TestMethod]
        public void GenerateJsonReport_should_return_all_properties_of_all_workers_as_Json()
        {
            var company = CreateTestCompany();
            var jsonReport = company.GenerateJsonReport();

            // Using Newtonsoft.Json to parse generated json
            var jsonObject = JObject.Parse(jsonReport);

            var workers = jsonObject["Workers"].Children().ToList();

            var erna = workers.First(w => w["Name"].ToString() == "Erna Solberg");
            Assert.AreEqual(erna["Position"], "CEO");

            var bjarne = workers.First(w => w["Name"].ToString() == "Bjarne Håkon Hanssen");
            Assert.AreEqual(bjarne["Company"], "First House");

            var siv = workers.First(w => w["Name"].ToString() == "Siv Jensen");
            Assert.AreEqual(siv["Position"], "CFO");
        }

        // Bruk strategy-pattern
        [TestMethod]
        public void GenerateXmlReport_should_return_all_properties_of_all_workers_as_Xml()
        {
            var company = CreateTestCompany();
            var xmlReport = company.GenerateXmlReport();

            var xmlElement = XElement.Parse(xmlReport);
            var workers = xmlElement.Elements("Worker").ToList();

            var erna = workers.First(x => (string)x.Element("Name") == "Erna Solberg");
            Assert.AreEqual(erna.Element("Position")?.Value, "CEO");

            var bjarne = workers.First(x => (string)x.Element("Name") == "Bjarne Håkon Hanssen");
            Assert.AreEqual(bjarne.Element("Company")?.Value, "First House");

            var siv = workers.First(x => (string)x.Element("Name") == "Siv Jensen");
            Assert.AreEqual(siv.Element("Position")?.Value, "CFO");
        }

        // Bruk Visitor-pattern.
        [TestMethod]
        public void CalculateYearlyCost_should_calculate_yearly_cost_for_all_workers()
        {
            var company = CreateTestCompany();
            var result = company.CalculateYearlyCost();
            Assert.AreEqual(3000000, result);
        }

        // Bruk Visitor-pattern
        [TestMethod]
        public void CalculateAverageHourlyCost_should_calculate_based_on_150_working_hours_per_month_adjusted_for_parttime_percentage()
        {
            var company = CreateTestCompany();
            var result = company.CalculateAverageHourlyCost();
            Assert.AreEqual((decimal)594.44, result);
        }
    }
}
