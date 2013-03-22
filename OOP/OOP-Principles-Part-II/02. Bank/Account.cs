using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    public abstract class Account : IDepositable
    {
        public Customer Customer { get; protected set; }
        public decimal Balance{ get; protected set; }
        public decimal InterestRate { get; protected set; }

        protected Account(Customer customer, decimal balance, decimal interestRate)
        {
            this.Customer = customer;
            this.Balance = balance;
            this.InterestRate = interestRate;            
        }

        public virtual decimal CalculateInterest(uint PeriodMonths)
        {
            return this.Balance * PeriodMonths * this.InterestRate / 100;
        }

        public virtual void MakeDeposit(decimal sum)
        {
            this.Balance += sum;
        }
    }
}
