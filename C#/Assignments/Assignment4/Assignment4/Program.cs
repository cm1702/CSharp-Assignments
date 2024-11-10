using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment4
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException() : base("Insufficient balance in the account") { }
    }
    
    public class BankAccount
    {
        private decimal balance;
        public void Deposit(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Invalid amount");
            balance += amount;
        }

        public void Withdraw(decimal amount)
        {
            if (amount <= 0)
                throw new ArgumentException("Invalid amount");

            if (balance < amount)
                throw new InsufficientBalanceException();
            balance -= amount;
        }

        public decimal GetBalance()
        {
            return balance;
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            BankAccount account = new BankAccount();
            try
            {
                account.Deposit(1000);
                Console.WriteLine("Balance: " + account.GetBalance());

                account.Withdraw(500);
                Console.WriteLine("Balance: " + account.GetBalance());

                account.Withdraw(1000);
            }
            catch(InsufficientBalanceException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
            catch(ArgumentException ex)
            {
                Console.WriteLine("Error: " + ex.Message);
            }
        }
    }  
}
