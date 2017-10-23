using Company;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;
using Newtonsoft.Json.Linq;

namespace CompanyTests
{
    /* Et Company har flere Workers, og ønsker å kunne generere flere ansatt-rapporter.
     * Akkurat nå finnes det to rapporter, en XmlReport og en JsonReport
     * Den abstrakte klassen Worker har to implementasjoner, Employee og Consultant.
     * Oppgaven går ut på å refaktorere slik at denne logikken flyttes ut av Worker og sub-klasser uten å bryte testene.
     * Dette kan gjøres vha Strategy-pattern.
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

            var workers = jsonObject["Workers"].Select(w => w["Worker"]).ToList();

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
            var detailedReport = company.GenerateXmlReport();
            var splitUpReport = detailedReport.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(3, splitUpReport.Length);
            Assert.AreEqual("Erna Solberg is working as Employee at our company. Erna Solberg works as CEO, and has a monthly salary of 100000", splitUpReport[0]);
            Assert.AreEqual("Bjarne Håkon Hanssen is working as Consultant at our company. Bjarne Håkon Hanssen currently works for First House, for a monthy fee of 80000", splitUpReport[1]);
            Assert.AreEqual("Siv Jensen is working as Employee at our company. Siv Jensen works as CFO, and has a monthly salary of 70000", splitUpReport[2]);
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
