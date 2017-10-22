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

        public string WorkerReportPlainText
        {
            get
            {
                StringBuilder builder = new StringBuilder();
                foreach (var worker in _workers)
                {
                    if (builder.Length > 0)
                        builder.Append(Environment.NewLine);
                    builder.Append(worker.ReportPlainText);
                }
                return builder.ToString();
            }
        }

        public string WorkerReportJson
        {
            get
            {
                StringBuilder builder = new StringBuilder("[");
                foreach (var worker in _workers)
                {
                    if (builder.Length > 1)
                        builder.Append(",");
                    builder.Append(worker.ReportJson);
                }
                builder.Append("]");
                return builder.ToString();
            }
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
