using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Mortgage : Account
    {
        public Mortgage(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        { 
        }
        public override decimal CalculateInterest(uint PeriodMonths)
        {
            if( this.Customer is Company) 
            {
                if (PeriodMonths <= 12)
                {
                    return base.CalculateInterest(PeriodMonths) / 2; // 1/2 interest if the period is <= 12 monts
                }
                return base.CalculateInterest(PeriodMonths) - base.CalculateInterest(12) / 2; // base interest - 1/2 interest for the first 12 months
            }
            else if (this.Customer is Individual)
            {
                if (PeriodMonths <= 6)
                {
                    return 0; // no interest for the first 6 months
                }
                return base.CalculateInterest(PeriodMonths - 6); 
            }
            return base.CalculateInterest(PeriodMonths);
        }
        
    }
}
