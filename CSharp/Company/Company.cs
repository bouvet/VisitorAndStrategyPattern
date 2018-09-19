using System;
using System.Collections.Generic;
using System.Text;

namespace Company
{
    public class Company
    {
        private readonly IList<Worker> _workers;

        public Company()
        {
            _workers = new List<Worker>();
        }

        public void AddWorker(Worker worker)
        {
            _workers.Add(worker);
        }

        public string GenerateJsonReport()
        {
            // Strategy pattern: Vi endrer oppførsel, slik at visitor vil generere en Json-rapport
            var reportVisitor = new ReportVisitor(new JsonReport());
            return GenerateReport(reportVisitor);
        }

        public string GenerateXmlReport()
        {
            // Strategy pattern: Vi endrer oppførsel, slik at visitor vil generere en Xml-rapport
            var reportVisitor = new ReportVisitor(new XmlReport());
            return GenerateReport(reportVisitor);
        }

        public decimal CalculateYearlyCost()
        {
            var visitor = new YearlyCostVisitor();
            foreach (var worker in _workers)
            {
                worker.Accept(visitor);
            }
            return visitor.YearlyCost;
        }

        public decimal CalculateAverageHourlyCost()
        {
            var visitor = new HourlyCostVisitor();
            foreach (var worker in _workers)
            {
                worker.Accept(visitor);
            }
            return visitor.AvarageHourlyCost;
        }

        private string GenerateReport(ReportVisitor reportVisitor)
        {
            var reportBuilder = new StringBuilder(reportVisitor.GenerateReportHeader());

            foreach (var worker in _workers)
            {
                worker.Accept(reportVisitor);
                reportBuilder.AppendLine(reportVisitor.Report);
            }

            reportBuilder.AppendLine(reportVisitor.GenerateReportFooter());
            return reportBuilder.ToString();
        }
    }
}
