using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Loan : Account
    {
        private uint GratisPeriod = 0;
        public Loan(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        {
            if (this.Customer is Individual)
            {
                this.GratisPeriod = 3;
            }
            else if (this.Customer is Company)
            {
                this.GratisPeriod = 2;
            }
        }
        
        public override decimal CalculateInterest(uint PeriodMonths)
        {
            if (PeriodMonths <= this.GratisPeriod)
            {
                return 0;
            }
            return base.CalculateInterest(PeriodMonths - this.GratisPeriod);
        }       
    }
}
