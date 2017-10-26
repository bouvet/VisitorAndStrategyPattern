﻿using System;
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
