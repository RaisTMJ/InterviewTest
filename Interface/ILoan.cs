namespace DefaultNamespace;


public interface  IPersonalLoanInterface
{
    public Task<LoanModel> LoanPaymentAmount(decimal loanAmount, decimal loanTerm);
    public Task<LoanModel> LoanPaymentTerm(decimal monthlyPayment, decimal principal );
    public Task<LoanModel> LoanPrincipalAmount(decimal monthlyPayment, decimal loanTerm);
}

