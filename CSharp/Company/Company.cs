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
            // TODO: Logikken bør flyttes ut v.h.a. Strategy-pattern
            StringBuilder reportBuilder = new StringBuilder("{ \"Workers\" : [");
            foreach (var worker in _workers)
            {
                reportBuilder.AppendLine("{");
                foreach (var reportLine in worker.GetReportData())
                {
                    reportBuilder.AppendLine($"\"{reportLine.Key}\":\"{reportLine.Value}\",");
                }
                reportBuilder.RemoveLastComma();
                reportBuilder.AppendLine("},");
            }
            reportBuilder.RemoveLastComma();
            reportBuilder.AppendLine("]}");
            return reportBuilder.ToString();
        }

        public string GenerateXmlReport()
        {
            // TODO: Logikken bør flyttes ut v.h.a. Strategy-pattern
            StringBuilder reportBuilder = new StringBuilder("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
            reportBuilder.AppendLine("<Workers>");
            foreach (var worker in _workers)
            {
                reportBuilder.AppendLine("<Worker>");
                foreach (var reportLine in worker.GetReportData())
                {
                    reportBuilder.AppendLine($"<{reportLine.Key}>{reportLine.Value}</{reportLine.Key}>");
                }
                reportBuilder.AppendLine("</Worker>");
            }
            reportBuilder.AppendLine("</Workers>");
            return reportBuilder.ToString();
        }

        public decimal CalculateYearlyCost()
        {
            decimal yearlyCost = 0;
            foreach (var worker in _workers)
            {
                yearlyCost += worker.CalculateYearlyCost();
            }
            return yearlyCost;
        }

        public decimal CalculateAverageHourlyCost()
        {
            if (_workers.Count == 0)
                return 0;

            decimal sumHourlyCost = 0;
            foreach (var worker in _workers)
            {
                sumHourlyCost += worker.CalculateHourlyCost();
            }

            return Math.Round(sumHourlyCost / _workers.Count, 2);
        }
    }
}
