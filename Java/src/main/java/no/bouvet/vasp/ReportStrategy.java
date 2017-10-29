package no.bouvet.vasp;

import java.util.List;

/**
 * Grensesnitt for strategi som lager en rapport basert på en liste av Worker.
 *
 */
public interface ReportStrategy {

	String generateReport(List<Worker> workers);
}
