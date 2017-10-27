package no.bouvet.vasp;

public class HourlyCostVisitor implements WorkerVisitor {

	private double hourlyCost = 0.0;
	
	public void visit(Employee employee) {
		double hoursPerMonth = 37.5 * 4 * (employee.getParttimePercentage() / 100);
		hourlyCost += Math.round(100 * employee.getMonthlySalary() / hoursPerMonth) / 100.0;
	}

	public void visit(Consultant consultant) {
		double hoursPerMonth = 37.5 * 4;
		hourlyCost += Math.round(100 * consultant.getMonthlyFee() / hoursPerMonth) / 100.0;
	}
	
	public double getHourlyCost() {
		return hourlyCost;
	}
}
