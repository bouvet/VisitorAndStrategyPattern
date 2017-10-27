package no.bouvet.vasp;

import static java.util.stream.Collectors.toList;

import java.util.List;
import java.util.Map;

/**
 * Rapport-strategi som genererer en XML-rapport.
 *
 */
public class XmlReport implements ReportStrategy {

	@Override
	public String generateReport(List<Worker> workers) {
		StringBuilder reportBuilder = new StringBuilder();
		List<String> workerReports = workers.stream()
				.map(XmlReport::generateWorkerReport)
				.collect(toList());

		reportBuilder.append("<?xml version=\"1.0\" encoding=\"UTF-8\"?>");
		reportBuilder.append("<Workers>");
		workerReports.forEach(reportBuilder::append);
		reportBuilder.append("</Workers>");

		return reportBuilder.toString();
	}

	private static String generateWorkerReport(Worker worker) {
		StringBuilder reportBuilder = new StringBuilder();
		Map<String, String> reportData = worker.getReportData();

		reportBuilder.append("<Worker>");
		reportData.entrySet().forEach(
				reportLine -> reportBuilder.append(
						String.format("<%s>%s</%s>", reportLine.getKey(), reportLine.getValue(), reportLine.getKey())));
		reportBuilder.append("</Worker>");

		return reportBuilder.toString();
	}
}
