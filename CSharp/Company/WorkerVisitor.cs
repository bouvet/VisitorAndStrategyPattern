using System;
using System.Collections.Generic;

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
        private decimal _hourlyCost;

        public void Visit(Employee employee)
        {
            var hoursPerMonth = (decimal) (37.5 * 4) * (employee.ParttimePercentage / 100);
            _hourlyCost += Math.Round(employee.MonthySalary / hoursPerMonth, 2);
        }

        public void Visit(Consultant consultant)
        {
            var hoursPerMonth = (decimal) 37.5 * 4;
            _hourlyCost += Math.Round(consultant.MonthlyFee / hoursPerMonth, 2);
        }

        public decimal HourlyCost { get { return _hourlyCost; } }
    }

    public class ReportVisitor : IWorkerVisitor
    {
        private readonly IReportStrategy _reportStrategy;

        public ReportVisitor(IReportStrategy reportStrategy)
        {
            _reportStrategy = reportStrategy;
        }

        public string Report { get; private set; }

        public void Visit(Employee employee)
        {
            var reportData = new Dictionary<string, string>();
            reportData.Add("Name", employee.Name);
            reportData.Add("WorkerType",  employee.WorkerType);
            reportData.Add("Position", employee.Position);
            reportData.Add("MonthlySalary", employee.MonthySalary.ToString());
            Report = _reportStrategy.GenerateWorkerReport(reportData);
        }

        public void Visit(Consultant consultant)
        {
            var reportData = new Dictionary<string, string>();
            reportData.Add("Name", consultant.Name);
            reportData.Add("WorkerType", consultant.WorkerType);
            reportData.Add("Company", consultant.Company);
            reportData.Add("MonthlyFee", consultant.MonthlyFee.ToString());
            Report = _reportStrategy.GenerateWorkerReport(reportData);
        }

        public string GenerateReportHeader()
        {
            return _reportStrategy.GenerateReportHeader();
        }

        public string GenerateReportFooter()
        {
            return _reportStrategy.GenerateReportFooter();
        }
    }
}
