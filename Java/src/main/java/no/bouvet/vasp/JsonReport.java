package no.bouvet.vasp;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;

import com.google.common.base.Joiner;

/**
 * Rapport-strategi som genererer en rapport på JSON-format.
 *
 */
public class JsonReport implements ReportStrategy {

	public String generateReport(List<Worker> workers) {
		StringBuilder reportBuilder = new StringBuilder("{\"Workers\": [");
		List<String> workerElements = new ArrayList<String>();
		for (Worker worker : workers) {
			StringBuilder workerBuilder = new StringBuilder("{");
			List<String> reportLines = new ArrayList<String>();
			for (Map.Entry<String, String> reportLine : worker.getReportData().entrySet()) {
				reportLines.add(String.format("\"%s\": \"%s\"", reportLine.getKey(), reportLine.getValue()));
			}
			workerBuilder.append(Joiner.on(", ").join(reportLines));
			workerBuilder.append("}");
			workerElements.add(workerBuilder.toString());
		}
		reportBuilder.append(Joiner.on(", ").join(workerElements));
		reportBuilder.append("]}");
		System.out.println(reportBuilder.toString());
		return reportBuilder.toString();
	}
}
