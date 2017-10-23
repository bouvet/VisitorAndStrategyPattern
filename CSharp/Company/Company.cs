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
            foreach (var worker in _workers)
            {
                // Strategy pattern: Vi endrer oppførsel, slik at worker.Report() vil generere en Json-rapport
                worker.SetReportStrategy(new JsonReport());
                var jsonReport = worker.Report();
                reportBuilder.AppendLine(jsonReport);
            }
            reportBuilder.RemoveLastComma();
            reportBuilder.AppendLine("]}");
            return reportBuilder.ToString();
        }

        public string GenerateXmlReport()
        {
            StringBuilder reportBuilder = new StringBuilder();
            foreach (var worker in _workers)
            {
                // Strategy pattern: Vi endrer oppførsel, slik at worker.Report() vil generere en Xml-rapport
                worker.SetReportStrategy(new XmlReport());
                var xmlReport = worker.Report();
                reportBuilder.AppendLine(xmlReport);
            }
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
