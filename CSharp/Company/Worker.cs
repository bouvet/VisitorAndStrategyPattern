using System;
using System.Collections.Generic;

namespace Company
{
    public abstract class Worker
    {
        public Worker(string name, string workerType)
        {
            Name = name;
            WorkerType = workerType;
        }

        public string Name { get; }

        public string WorkerType { get; }

        public abstract decimal CalculateYearlyCost();
        public abstract decimal CalculateHourlyCost();
        public abstract Dictionary<string, string> GetReportData();
    }

    public class Employee : Worker
    {
        public Employee(string name, string position, decimal monthlySalary, decimal parttimePercentage)
            : base(name, "Employee")
        {
            Position = position;
            MonthySalary = monthlySalary;
            ParttimePercentage = parttimePercentage;
        }

        public string Position { get; private set; }
        public decimal MonthySalary { get; private set; }
        public decimal ParttimePercentage { get; private set; }
        public override Dictionary<string, string> GetReportData()
        {
            var reportData = new Dictionary<string, string>();
            reportData.Add("Name", Name);
            reportData.Add("WorkerType", WorkerType);
            reportData.Add("Position", Position);
            reportData.Add("MonthlySalary", MonthySalary.ToString());
            return reportData;
        }

        public override decimal CalculateYearlyCost()
        {
            return MonthySalary * 12;
        }

        public override decimal CalculateHourlyCost()
        {
            var hoursPerMonth = (decimal)37.5 * 4 * (ParttimePercentage / 100);
            return Math.Round(MonthySalary / hoursPerMonth, 2);
        }
    }

    public class Consultant : Worker
    {
        public Consultant(string name, string company, decimal monthlyFee)
            : base(name, "Consultant")
        {
            Company = company;
            MonthlyFee = monthlyFee;
        }

        public string Company { get; private set; }
        public decimal MonthlyFee { get; private set; }

        public override Dictionary<string, string> GetReportData()
        {
            var reportData = new Dictionary<string, string>();
            reportData.Add("Name", Name);
            reportData.Add("WorkerType", WorkerType);
            reportData.Add("Company", Company);
            reportData.Add("MonthlyFee", MonthlyFee.ToString());
            return reportData;
        }

        public override decimal CalculateYearlyCost()
        {
            return MonthlyFee * 12;
        }

        public override decimal CalculateHourlyCost()
        {
            var hoursPerMonth = (decimal) (37.5 * 4);
            return Math.Round(MonthlyFee / hoursPerMonth, 2);
        }
    }
}
