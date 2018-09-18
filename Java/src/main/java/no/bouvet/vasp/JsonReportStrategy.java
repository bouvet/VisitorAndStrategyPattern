package no.bouvet.vasp;

import static java.util.stream.Collectors.toList;

import java.util.List;
import java.util.Map;

import com.google.common.base.Joiner;

/**
 * Rapport-strategi som genererer en rapport på JSON-format.
 *
 */
public class JsonReportStrategy implements ReportStrategy {

	@Override
	public String generateReport(List<Worker> workers) {
		StringBuilder reportBuilder = new StringBuilder();
		List<String> workerReports = workers.stream()
				.map(JsonReportStrategy::generateWorkerReport)
				.collect(toList());
		
		reportBuilder.append("{\"Workers\": [");
		reportBuilder.append(Joiner.on(", ").join(workerReports));
		reportBuilder.append("]}");

		return reportBuilder.toString();
	}

	private static String generateWorkerReport(Worker worker) {
		StringBuilder reportBuilder = new StringBuilder();
		Map<String, String> reportData = worker.getReportData();
		
		reportBuilder.append("{");
		reportBuilder.append(Joiner.on(", ").join(reportData.entrySet().stream()
				.map(reportLine -> String.format("\"%s\": \"%s\"", reportLine.getKey(), reportLine.getValue()))
				.collect(toList())));
		reportBuilder.append("}");

		return reportBuilder.toString();
	}
}
