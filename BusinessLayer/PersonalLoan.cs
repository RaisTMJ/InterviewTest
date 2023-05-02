namespace DefaultNamespace;

public class PersonalLoan
{


    public LoanModel MonthlyPayment(decimal loanPrincipal, decimal loanTerm)
    {
   
            var interestRate = GetInterestRateOfPayment(loanPrincipal);
            var installment= MonthlyInstallmentCalculationEmi(loanPrincipal, loanTerm, interestRate);
            return new LoanModel
            {
                Principal = loanPrincipal,
                Rate = interestRate,
                TenureYear = loanTerm,
                Installment = Math.Round(installment, 2)
            };
   
   
    }
      public LoanModel GetPrincipalAmount(decimal installment, decimal loanTerm, int elementInterestRate)
    {
        
        List<decimal>  interestRateStage= new List<decimal>(){0.065m, 0.07m, 0.08m};

        if (elementInterestRate > 2)
        {
            return new LoanModel();
            
        }
        var check =  CalculatePrincipalFromInstallmentAmount(loanTerm, installment, interestRateStage[elementInterestRate]);
   
           if (!VerificationInterestRateOfPayment(check, interestRateStage.ElementAt(elementInterestRate)).HasValue)
           {
               return  GetPrincipalAmount(installment, loanTerm, elementInterestRate + 1);
           }
       
       return new LoanModel
         {
              Principal =  Math.Round(check, 2),
              Rate = interestRateStage.ElementAt(elementInterestRate),
              TenureYear = loanTerm,
              Installment = installment
         };

   
    }
      public LoanModel GetTenureAmount(decimal installment, decimal principal)
    {
        var interestRate = GetInterestRateOfPayment(principal);
        
        var tenure=  CalculateTenurePaymentFromInstallmentAmount(principal, installment, interestRate);
       
       return new LoanModel
         {
              Principal =  Math.Round(principal, 2),
              Rate = interestRate ,
              TenureYear = Math.Round(tenure, 2),
              Installment = installment
         };

   
    }
    

    private decimal GetInterestRateOfPayment(decimal loanAmount)
    {
        // return 0.07m;

        if (loanAmount > 100001)
        {
            throw new Exception("Loan amount is too high");
        }
        if (loanAmount > 50000)
        {
            return 0.065m;
        }
        if (loanAmount > 20000)
        {
            return 0.07m;
        }
        if (loanAmount >= 5000)
        {
            return 0.08m;
        }

        throw new Exception("Loan amount to low?");
    }
    private decimal? VerificationInterestRateOfPayment(decimal loanAmount,decimal interestRate)
    {
        // return 0.07m;

        if (loanAmount > 100001)
        {
           return null;
        }
        if (loanAmount > 50000 && interestRate == 0.065m)
        {
            return 0.065m;
        }

        if (loanAmount > 20000 && interestRate == 0.07m)
        {
            return 0.07m;
        }
      
        if (loanAmount >= 5000 && interestRate == 0.08m)
        {
            return 0.08m;
        }
        return null;
 
        
    }
    
    private decimal MonthlyInstallmentCalculationEmi(decimal loanAmount, decimal loanTerm, decimal interestRate)
    {
        // Monthly Installment (EMI) = P x r x (1 + r) / ((1 + r)n - 1)
        
        decimal monthlyEffectiveRate = interestRate / 12;
        decimal tenureInMonths = loanTerm * 12;
        decimal installment = loanAmount * monthlyEffectiveRate * (decimal) Math.Pow((double) (1 + monthlyEffectiveRate), (double) tenureInMonths) / ((decimal) Math.Pow((double) (1 + monthlyEffectiveRate), (double) tenureInMonths) - 1);
        
        // = 30,000 * (7/100/12) * ((1+ (7/100/12))^(5*12))/(( (1+(7/100/12))^(5*12))-1)
        return installment;
    }
    
    private decimal CalculateTenurePaymentFromInstallmentAmount(decimal loanAmount, decimal installment, decimal interestRate)
    {
      
        
        decimal monthlyEffectiveRate = interestRate / 12;
        decimal tenureInMonths = (decimal) Math.Log((double) (installment / (installment - loanAmount * monthlyEffectiveRate)), (double) (1 + monthlyEffectiveRate));
        decimal tenureInYears = tenureInMonths / 12;
        return tenureInYears;
    }
    
    private decimal CalculatePrincipalFromInstallmentAmount(decimal tenure, decimal installment, decimal interestRate)
    {
        // Monthly Installment (EMI) = P x r x (1 + r) / ((1 + r)n - 1)
        decimal monthlyEffectiveRate = interestRate / 12;
        decimal tenureInMonths = tenure * 12;
        decimal principal = installment / (monthlyEffectiveRate * (decimal) Math.Pow((double) (1 + monthlyEffectiveRate), (double) tenureInMonths) / ((decimal) Math.Pow((double) (1 + monthlyEffectiveRate), (double) tenureInMonths) - 1));
        return principal;

    }


}