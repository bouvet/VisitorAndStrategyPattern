package no.bouvet.vasp;

public interface WorkerVisitor {

	void visit(Employee employee);
	void visit(Consultant consultant);
}
