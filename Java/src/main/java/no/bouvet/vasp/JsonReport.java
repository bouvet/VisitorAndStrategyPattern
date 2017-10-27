package no.bouvet.vasp;

import java.util.ArrayList;
import java.util.List;
import java.util.Map;
import java.util.stream.Collectors;

import com.google.common.base.Joiner;

/**
 * Rapport-strategi som genererer en rapport på JSON-format.
 *
 */
public class JsonReport implements ReportStrategy {

	@Override
	public String generateWorkerReport(Map<String, String> reportData) {
		StringBuilder reportBuilder = new StringBuilder();

		reportBuilder.append("{");
		reportBuilder.append(Joiner.on(", ").join(reportData.entrySet().stream()
				.map(reportLine -> String.format("\"%s\": \"%s\"", reportLine.getKey(), reportLine.getValue()))
				.collect(Collectors.toList())));
		reportBuilder.append("}");

		return reportBuilder.toString();
	}

	@Override
	public String assembleReport(List<String> workerReports) {
		StringBuilder reportBuilder = new StringBuilder();

		reportBuilder.append("{\"Workers\": [");
		reportBuilder.append(Joiner.on(", ").join(workerReports));
		reportBuilder.append("]}");

		return reportBuilder.toString();
	}
}
