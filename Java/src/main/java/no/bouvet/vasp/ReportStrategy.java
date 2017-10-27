package no.bouvet.vasp;

import java.util.List;
import java.util.Map;

/**
 * Grensesnitt for strategi som lager en rapport.
 *
 */
public interface ReportStrategy {

	String generateWorkerReport(Map<String, String> reportData);

	String assembleReport(List<String> workerReports);
}
