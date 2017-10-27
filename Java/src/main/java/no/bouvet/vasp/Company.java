package no.bouvet.vasp;

import java.util.ArrayList;
import java.util.List;

public class Company {
	
	public static final String XML_FORMAT = "xml";
	public static final String JSON_FORMAT = "json";
	
	private List<Worker> workers;
	
	private ReportStrategy reportStrategy;

	public Company() {
		workers = new ArrayList<Worker>();
	}

	public void addWorker(Worker worker) {
		workers.add(worker);
	}
	
	public void setReportFormat(String reportFormat) {
		if (JSON_FORMAT.equals(reportFormat)) {
			reportStrategy = new JsonReport();
		} else {
			reportStrategy = new XmlReport();
		}
	}
	
	public String generateReport() {
		return reportStrategy.generateReport(workers);
	}

	public double calculateYearlyCost() {
		YearlyCostVisitor visitor = new YearlyCostVisitor();
		for (Worker worker : workers) {
			worker.accept(visitor);
		}
		return visitor.getYearlyCost();
	}

	public double calculateAverageHourlyCost() {
		if (workers.size() == 0)
			return 0.0;

		HourlyCostVisitor visitor = new HourlyCostVisitor();
		for (Worker worker : workers) {
			worker.accept(visitor);
		}

		return Math.round(100 * visitor.getHourlyCost() / workers.size()) / 100.0;
	}
}
