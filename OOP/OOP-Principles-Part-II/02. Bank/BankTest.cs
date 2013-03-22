using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Bank
{
    class BankTest
    {
        static void Main()
        {
            Bank theBank = new Bank("The Bank");
            
            Customer Hitar_Petar = new Individual("Hitar Petar");            
            Customer badCompany = new Company("Bad Comapny");
            Customer student = new Individual("Poor student");

            List<Account> newAccounts = new List<Account>();
            newAccounts.Add(new Deposit(Hitar_Petar, 1001, 1));
            newAccounts.Add(new Loan(badCompany, 10000, -1.5m));
            newAccounts.Add(new Mortgage(student, 100000, -1.2m));

            theBank.Accounts = newAccounts;

            foreach (var account in theBank.Accounts)
            {
                uint period = 10;
                Console.WriteLine("The {0}'s interest for the period of {1} months is {2}", 
                    account.Customer.Name, period, account.CalculateInterest(period));
                // interest for deposit over 10 months and 1001 bill must be 100.1
                // interest for loan for companies over 10 months with 2 gratis months should be 10000*8*-1.5% = -1200
                // interest for mortgage over 10 months for individuals with 6 gratis months should be 100000*4*-1.2% = -4800
            }
            Console.WriteLine();
            Console.WriteLine("Now withdraw 2 from Hitar Petar's deposit:");
            (theBank.Accounts[0] as Deposit).MakeWithdraw(2);
            Console.WriteLine("{0}'s interest now for 10 months is {1}.", 
                theBank.Accounts[0].Customer.Name, theBank.Accounts[0].CalculateInterest(10));
            Console.WriteLine();
            Console.WriteLine("Now Hitar Petar try to overdraft with 1000:");
            Console.WriteLine("The current balance is: {0}", theBank.Accounts[0].Balance);
            try
            {
                (theBank.Accounts[0] as Deposit).MakeWithdraw(1000);
            }
            catch (ArgumentException e)
            {
                Console.WriteLine(e.Message);
            }
        }
    }
}
