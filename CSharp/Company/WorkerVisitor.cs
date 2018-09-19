using System;
using System.Collections.Generic;
using System.Text;

namespace Company
{
    public interface IWorkerVisitor
    {
        void Visit(Employee employee);
        void Visit(Consultant consultant);
    }

    public class YearlyCostVisitor : IWorkerVisitor
    {
        private decimal _yearlyCost;

        public void Visit(Employee employee)
        {
            _yearlyCost += (employee.MonthySalary * 12);
        }

        public void Visit(Consultant consultant)
        {
            _yearlyCost += (consultant.MonthlyFee * 12);
        }

        public decimal YearlyCost { get { return _yearlyCost; } }
    }

    public class HourlyCostVisitor : IWorkerVisitor
    {
        private decimal _sumHourlyCost;
        private int _numberOfWorkers;

        public void Visit(Employee employee)
        {
            var hoursPerMonth = (decimal) (37.5 * 4) * (employee.ParttimePercentage / 100);
            _sumHourlyCost += Math.Round(employee.MonthySalary / hoursPerMonth, 2);
            _numberOfWorkers++;
        }

        public void Visit(Consultant consultant)
        {
            var hoursPerMonth = (decimal) 37.5 * 4;
            _sumHourlyCost += Math.Round(consultant.MonthlyFee / hoursPerMonth, 2);
            _numberOfWorkers++;
        }

        public decimal AvarageHourlyCost { get { return _numberOfWorkers == 0 ? 0 : Math.Round(_sumHourlyCost / _numberOfWorkers, 2); } }
    }

    public class ReportVisitor : IWorkerVisitor
    {
        private readonly IReportStrategy _reportStrategy;
        private List<string> _workerReports = new List<string>();

        public ReportVisitor(IReportStrategy reportStrategy)
        {
            _reportStrategy = reportStrategy;
        }

        public string Report
        {
            get
            {
                var reportBuilder = new StringBuilder(_reportStrategy.GenerateReportHeader());
                foreach (var workerReport in _workerReports)
                {
                    reportBuilder.Append(workerReport);
                }
                reportBuilder.Append(_reportStrategy.GenerateReportFooter());
                return reportBuilder.ToString();
            }
        }

        public void Visit(Employee employee)
        {
            var reportData = new Dictionary<string, string>();
            reportData.Add("Name", employee.Name);
            reportData.Add("WorkerType",  employee.WorkerType);
            reportData.Add("Position", employee.Position);
            reportData.Add("MonthlySalary", employee.MonthySalary.ToString());
            _workerReports.Add(_reportStrategy.GenerateWorkerReport(reportData));
        }

        public void Visit(Consultant consultant)
        {
            var reportData = new Dictionary<string, string>();
            reportData.Add("Name", consultant.Name);
            reportData.Add("WorkerType", consultant.WorkerType);
            reportData.Add("Company", consultant.Company);
            reportData.Add("MonthlyFee", consultant.MonthlyFee.ToString());
            _workerReports.Add(_reportStrategy.GenerateWorkerReport(reportData));
        }
    }
}
