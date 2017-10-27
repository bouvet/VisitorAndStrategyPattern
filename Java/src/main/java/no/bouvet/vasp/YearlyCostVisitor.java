package no.bouvet.vasp;

public class YearlyCostVisitor implements WorkerVisitor {

	private double yearlyCost = 0.0;
	
	@Override
	public void visit(Employee employee) {
		yearlyCost += employee.getMonthlySalary() * 12;
	}

	@Override
	public void visit(Consultant consultant) {
		yearlyCost += consultant.getMonthlyFee() * 12;
	}

	public double getYearlyCost() {
		return yearlyCost;
	}
}
