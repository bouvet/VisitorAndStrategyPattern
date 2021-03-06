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
		// TODO: Kan evt. flyttes ut v.h.a. en kombinasjon av Strategy- og Visitor-pattern

		Map<String, String> reportData = new HashMap<>();
		
		reportData.put("Name", getName());
		reportData.put("WorkerType", getWorkerType());
		reportData.put("Position", position);
		reportData.put("MonthlySalary", String.valueOf(monthlySalary));
		
		return reportData;
	}

	@Override
	public double calculateYearlyCost() {
		// TODO: Bør flyttes ut v.h.a. Visitor-pattern

		return monthlySalary * 12;
	}

	@Override
	public double calculateHourlyCost() {
		// TODO: Bør flyttes ut v.h.a. Visitor-pattern

		double hoursPerMonth = 37.5 * 4 * (parttimePercentage / 100);
		return Math.round(100 * monthlySalary / hoursPerMonth) / 100.0;
	}
}
