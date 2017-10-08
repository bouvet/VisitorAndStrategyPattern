using Company;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CompanyTests
{
    /* Den abstrakte klassen Worker har to implementasjoner, Employee og Consultant.
     * Begge disse klassene implementerer metodene ReportPlainText og ReportJson.
     * Oppgaven går ut på å refaktorere slik at denne logikken flyttes ut av Worker og sub-klasser uten å bryte testene.
     * Dette kan gjøres vha Visitor- og/eller Strategy-pattern.
     * http://www.oodesign.com/visitor-pattern.html
     * http://www.oodesign.com/strategy-pattern.html
     */

    [TestClass]
    public class CompanyTest
    {
        private Company.Company CreateTestCompany()
        {
            var company = new Company.Company();
            company.AddWorker(new Employee("Erna Solberg", "CEO", 100000));
            company.AddWorker(new Consultant("Bjarne Håkon Hanssen", "First House", 80000));
            company.AddWorker(new Employee("Siv Jensen", "CFO", 70000));
            return company;
        }

        [TestMethod]
        public void WorkerReportPlainText_should_return_information_on_all_workers_separated_by_lineBreak()
        {
            var company = CreateTestCompany();
            var result = company.GeneratePlainTextWorkerReport().Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual("Erna Solberg is working as Employee at our company.", result[0]);
            Assert.AreEqual("Bjarne Håkon Hanssen is working as Consultant at our company.", result[1]);
            Assert.AreEqual("Siv Jensen is working as Employee at our company.", result[2]);
        }

        [TestMethod]
        public void WorkerReportJson_should_return_information_on_all_workers_by_json()
        {
            var company = CreateTestCompany();
            var result = company.GenerateJsonWorkerReport();
            var expected = "[" +
                @"{ ""workerType"": ""Employee"", ""name"": ""Erna Solberg"" }," +
                @"{ ""workerType"": ""Consultant"", ""name"": ""Bjarne Håkon Hanssen"" }," +
                @"{ ""workerType"": ""Employee"", ""name"": ""Siv Jensen"" }" +
                "]";

            Assert.AreEqual(expected, result);
        }
    }
}
