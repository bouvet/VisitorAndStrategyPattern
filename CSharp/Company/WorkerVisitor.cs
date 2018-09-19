using System;

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
}
