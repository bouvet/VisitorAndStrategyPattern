﻿using System.Collections.Generic;

namespace Company
{
    public abstract class Worker
    {
        protected Worker(string name, string workerType)
        {
            Name = name;
            WorkerType = workerType;
        }

        public string Name { get; }

        public string WorkerType { get; }

        public abstract Dictionary<string, string> GetReportData();

        public abstract void Accept(IWorkerVisitor visitor);
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

        public override void Accept(IWorkerVisitor visitor)
        {
            visitor.Visit(this);
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

        public override void Accept(IWorkerVisitor visitor)
        {
            visitor.Visit(this);
        }
    }
}
