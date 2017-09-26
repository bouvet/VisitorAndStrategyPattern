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
            var result = company.WorkerReportPlainText.Split(new[] { Environment.NewLine }, StringSplitOptions.None);
            Assert.AreEqual(3, result.Length);
            Assert.AreEqual("Employee Erna Solberg works as CEO and earns 100000 per month.", result[0]);
            Assert.AreEqual("Consultant Bjarne Håkon Hanssen from First House costs 80000 per month.", result[1]);
            Assert.AreEqual("Employee Siv Jensen works as CFO and earns 70000 per month.", result[2]);
        }

        [TestMethod]
        public void WorkerReportJson_should_return_information_on_all_workers_by_json()
        {
            var company = CreateTestCompany();
            var result = company.WorkerReportJson;
            var expected = "[" +
                @"{ ""workerType"": ""Employee"", ""name"": ""Erna Solberg"", ""position"": ""CEO"", ""monthlySalary"": 100000 }," +
                @"{ ""workerType"": ""Consultant"", ""name"": ""Bjarne Håkon Hanssen"", ""company"": ""First House"", ""monthlyFee"": 80000 }," +
                @"{ ""workerType"": ""Employee"", ""name"": ""Siv Jensen"", ""position"": ""CFO"", ""monthlySalary"": 70000 }" +
                "]";

            Assert.AreEqual(expected, result);
        }
    }
}
