

using DefaultNamespace;

public class PersonalLoanService: IPersonalLoanInterface
{
    readonly PersonalLoan _personalLoan = new PersonalLoan();
    

    
    public Task<LoanModel> LoanPaymentAmount(decimal loanAmount, decimal loanTerm)
    {

        return Task.FromResult(_personalLoan.MonthlyPayment(loanAmount, loanTerm)) ;

    }

    public Task<LoanModel> LoanPaymentTerm(decimal installment, decimal principal)
    {

        return Task.FromResult(_personalLoan.GetTenureAmount(installment, principal)) ;

    }

    public Task<LoanModel> LoanPrincipalAmount(decimal monthlyPayment, decimal loanTerm )
    {
        
        return  Task.FromResult(_personalLoan.GetPrincipalAmount(monthlyPayment, loanTerm,0));
    }


}