using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public class Deposit : Account, IWithdrawable
    {
        public Deposit(Customer customer, decimal balance, decimal interestRate)
            : base(customer, balance, interestRate)
        { 
        }
        public override decimal CalculateInterest(uint PeriodMonths)
        {
            if (this.Balance > 0 && this.Balance < 1000)
            {
                return 0;
            }
            return base.CalculateInterest(PeriodMonths);
        }

        public void MakeWithdraw(decimal sum)
        {
            if (sum <= this.Balance)
            {
                this.Balance -= sum;
            }
            else throw new ArgumentException("Can't withdraw more than deposit balance!");
        }
    }
}
