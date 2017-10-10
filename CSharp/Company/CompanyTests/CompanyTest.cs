using Company;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace CompanyTests
{
    /* Et Company har flere Workers, og ønsker å kunne generere flere ansatt-rapporter.
     * Akkurat nå finnes det to rapporter, en ShortReport og en DetailedReport
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
            company.AddWorker(new Employee("Erna Solberg", "CEO", 100000));
            company.AddWorker(new Consultant("Bjarne Håkon Hanssen", "First House", 80000));
            company.AddWorker(new Employee("Siv Jensen", "CFO", 70000));
            return company;
        }

        [TestMethod]
        public void GenerateShortWorkerReport_should_return_name_and_workertype_for_all_workers_separated_by_lineBreak()
        {
            var company = CreateTestCompany();
            var shortReport = company.GenerateShortWorkerReport();
            var splitUpReport = shortReport.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(3, splitUpReport.Length);
            Assert.AreEqual("Erna Solberg is working as Employee at our company.", splitUpReport[0]);
            Assert.AreEqual("Bjarne Håkon Hanssen is working as Consultant at our company.", splitUpReport[1]);
            Assert.AreEqual("Siv Jensen is working as Employee at our company.", splitUpReport[2]);
        }

        [TestMethod]
        public void GenerateDetailedWorkerReport_should_return_detailed_information_on_all_workers_separated_by_lineBreak()
        {
            var company = CreateTestCompany();
            var detailedReport = company.GenerateDetailedWorkerReport();
            var splitUpReport = detailedReport.Split(new[] { Environment.NewLine }, StringSplitOptions.RemoveEmptyEntries);
            Assert.AreEqual(3, splitUpReport.Length);
            Assert.AreEqual("Erna Solberg is working as Employee at our company. Erna Solberg works as CEO, and has a monthly salary of 100000", splitUpReport[0]);
            Assert.AreEqual("Bjarne Håkon Hanssen is working as Consultant at our company. Bjarne Håkon Hanssen currently works for First House, for a monthy fee of 80000", splitUpReport[1]);
            Assert.AreEqual("Siv Jensen is working as Employee at our company. Siv Jensen works as CFO, and has a monthly salary of 70000", splitUpReport[2]);
        }
    }
}
