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
            StringBuilder reportBuilder = new StringBuilder("{ \"Workers\" : [");

            // Strategy pattern: Vi endrer oppførsel, slik at visitor vil generere en Json-rapport
            var reportVisitor = new ReportVisitor(new JsonReport());

            foreach (var worker in _workers)
            {
                worker.Accept(reportVisitor);
                reportBuilder.AppendLine(reportVisitor.Report);
            }

            reportBuilder.RemoveLastComma();
            reportBuilder.AppendLine("]}");
            return reportBuilder.ToString();
        }

        public string GenerateXmlReport()
        {
            StringBuilder reportBuilder = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            reportBuilder.AppendLine("<Workers>");

            // Strategy pattern: Vi endrer oppførsel, slik at visitor vil generere en Xml-rapport
            var reportVisitor = new ReportVisitor(new XmlReport());

            foreach (var worker in _workers)
            {
                worker.Accept(reportVisitor);
                reportBuilder.AppendLine(reportVisitor.Report);
            }

            reportBuilder.AppendLine("</Workers>");
            return reportBuilder.ToString();
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
            if (_workers.Count == 0)
                return 0;

            var visitor = new HourlyCostVisitor();
            foreach (var worker in _workers)
            {
                worker.Accept(visitor);
            }
            return Math.Round(visitor.HourlyCost / 3, 2);
        }
    }
}
