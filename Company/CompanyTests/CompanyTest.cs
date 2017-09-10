using Company;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Linq;

namespace CompanyTests
{
    /* 
     * The abstract base-class Worker forces sub-classes to calculate YearlyCost and Report.
     * This however, violates the Open-Closed principle, as we need to change the Worker class and sub-classes if new functionality like this should be added.
     * 
     * So, we would like to rewrite the Worker-class to use the visitor-pattern so that it is open for new types of report in the future.
     * http://www.oodesign.com/visitor-pattern.html
     * 
     * 1. Make the Worker-classes accept a visitor. 
     * 2. Rewrite the existing yearly-cost and report functionality as visitors without breaking the tests.
     * 
     * */
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
                @"{ ""workerType"": ""Employee"", ""name"": ""Erna Solberg"", ""position"": ""CEO"", ""monthlySalary"": 100000 }" +
                @"{ ""workerType"": ""Consultant"", ""name"": ""Bjarne Håkon Hanssen"", ""company"": ""First House"", ""monthlyFee"": 80000 }" +
                @"{ ""workerType"": ""Employee"", ""name"": ""Siv Jensen"", ""position"": ""CFO"", ""monthlySalary"": 70000 }" +
                "]";

            Assert.AreEqual(expected, result);
        }
    }
}
