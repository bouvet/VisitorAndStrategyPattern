package no.bouvet.vasp;

public class Consultant extends Worker {

    private String company;
    private double monthlyFee;

    public Consultant(String name, String company, double monthlyFee) {
        super(name, "Consultant");
        this.company = company;
        this.monthlyFee = monthlyFee;
    }

    public String getCompany() {
        return company;
    }

    public double getMonthlyFee() {
        return monthlyFee;
    }

    @Override
    public void accept(WorkerVisitor visitor) {
        visitor.visit(this);
    }
}
