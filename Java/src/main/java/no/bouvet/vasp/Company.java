package no.bouvet.vasp;

import java.util.ArrayList;
import java.util.List;

public class Company {
	
	private List<Worker> workers;
	
	private ReportStrategy reportStrategy;

	public Company() {
		workers = new ArrayList<>();
	}

	public void addWorker(Worker worker) {
		workers.add(worker);
	}
	
	public void setReportStrategy(ReportStrategy reportStrategy) {
		this.reportStrategy = reportStrategy;
	}
	
	public String generateReport() {
		return reportStrategy.generateReport(workers);
	}

	public double calculateYearlyCost() {
		YearlyCostVisitor visitor = new YearlyCostVisitor();
		workers.forEach(worker -> worker.accept(visitor));
		return visitor.getYearlyCost();
	}

	public double calculateAverageHourlyCost() {
		if (workers.size() == 0)
			return 0.0;

		HourlyCostVisitor visitor = new HourlyCostVisitor();
		workers.forEach(worker -> worker.accept(visitor));
		return visitor.getAverageHourlyCost();
	}
}
