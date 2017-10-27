package no.bouvet.vasp;

import java.util.HashMap;
import java.util.Map;

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
	public Map<String, String> getReportData() {
		Map<String, String> reportData = new HashMap<String, String>();
		reportData.put("Name", getName());
		reportData.put("WorkerType", getWorkerType());
		reportData.put("Position", position);
		reportData.put("MonthlySalary", String.valueOf(monthlySalary));
		return reportData;
	}

	@Override
	public void accept(WorkerVisitor visitor) {
		visitor.visit(this);
	}
}
