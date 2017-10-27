package no.bouvet.vasp;

import java.util.Map;

public abstract class Worker {
	private String name;
	private String workerType;

	public Worker(String name, String workerType) {
		this.name = name;
		this.workerType = workerType;
	}

	public String getName() {
		return name;
	}

	public String getWorkerType() {
		return workerType;
	}
	
	public abstract void accept(WorkerVisitor visitor);
}
