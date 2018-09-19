using System;
using System.Collections.Generic;
using System.Text;

namespace Company
{
    public class Company
    {
        private readonly IList<Worker> _workers;
        private IReportStrategy _reportStrategy;

        public Company()
        {
            _workers = new List<Worker>();
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
            var visitor = new ReportVisitor(_reportStrategy);
            foreach (var worker in _workers)
            {
                worker.Accept(visitor);
            }
            return visitor.Report;
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
    }
}
