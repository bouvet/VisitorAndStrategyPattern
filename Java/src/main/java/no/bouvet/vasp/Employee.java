package no.bouvet.vasp;

public class Employee extends Worker {

	private String position;
	private double monthlySalary;
	private double parttimePercentage;

	public Employee(String name, String position, double monthlySalary, double parttimePercentage) {
		super(name, "Employee");
		this.position = position;
		this.monthlySalary = monthlySalary;
		this.parttimePercentage = parttimePercentage;
	}

	public String getPosition() {
		return position;
	}

	public double getMonthlySalary() {
		return monthlySalary;
	}

	public double getParttimePercentage() {
		return parttimePercentage;
	}

	@Override
	public void accept(WorkerVisitor visitor) {
		visitor.visit(this);
	}
}
