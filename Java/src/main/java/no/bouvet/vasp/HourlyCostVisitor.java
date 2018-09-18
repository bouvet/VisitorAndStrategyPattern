package no.bouvet.vasp;

public class HourlyCostVisitor implements WorkerVisitor {

	private double sumHourlyCost = 0.0;
	private int numberOfWorkers = 0;

	@Override
	public void visit(Employee employee) {
		double hoursPerMonth = 37.5 * 4 * (employee.getParttimePercentage() / 100);
        sumHourlyCost += Math.round(100 * employee.getMonthlySalary() / hoursPerMonth) / 100.0;
        numberOfWorkers++;
	}

	@Override
	public void visit(Consultant consultant) {
		double hoursPerMonth = 37.5 * 4;
        sumHourlyCost += Math.round(100 * consultant.getMonthlyFee() / hoursPerMonth) / 100.0;
        numberOfWorkers++;
	}

	public double getAverageHourlyCost() {
		return Math.round(100 * sumHourlyCost / numberOfWorkers) / 100.0;
	}
}
