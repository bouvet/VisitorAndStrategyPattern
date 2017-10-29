using System;
using System.Collections.Generic;

namespace Company
{
    public class Company
    {
        private readonly IList<Worker> _workers;
        private IReportStrategy _reportStrategy;

        public Company()
        {
            _workers = new List<Worker>();
            _reportStrategy = new XmlReportStrategy();  // Default strategy
        }

        public void AddWorker(Worker worker)
        {
            _workers.Add(worker);
        }

        public void SetReportStrategy(IReportStrategy reportStrategy)
        {
            _reportStrategy = reportStrategy;
        }

        public string GenerateReport()
        {
            return _reportStrategy.GenerateReport(_workers);
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
            return Math.Round(visitor.HourlyCost / _workers.Count, 2);
        }
    }
}
