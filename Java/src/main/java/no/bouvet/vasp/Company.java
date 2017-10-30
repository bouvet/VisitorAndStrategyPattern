package no.bouvet.vasp;

import java.util.ArrayList;
import java.util.List;
import java.util.stream.Collectors;

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
		ReportVisitor reportVisitor = new ReportVisitor(reportStrategy);

		List<String> workerReports = workers.stream()
				.map(worker -> {
					worker.accept(reportVisitor);
					return reportVisitor.getReport();
				})
				.collect(Collectors.toList());

		return reportStrategy.assembleReport(workerReports);
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

		return Math.round(100 * visitor.getHourlyCost() / workers.size()) / 100.0;
	}
}
