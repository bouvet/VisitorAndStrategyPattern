using System.Collections.Generic;
using System.Xml.Linq;

namespace Company
{
    public class Company
    {
        private readonly IList<IWorker> _workers;

        public Company()
        {
            _workers = new List<IWorker>();
        }

        public void AddWorker(IWorker worker)
        {
            _workers.Add(worker);
        }

        public decimal YearlyWorkerCost
        {
            get
            {
                var visitor = new YearlyCostVisitor();
                foreach (var worker in _workers)
                    worker.accept(visitor);
                return visitor.YearlyCost;
            }
        }

        public string WorkerReport
        {
            get
            {
                var visitor = new WorkerReportVisitor();
                foreach(var worker in _workers)
                    worker.accept(visitor);
                return visitor.Report;
            }
        }
    }
}
