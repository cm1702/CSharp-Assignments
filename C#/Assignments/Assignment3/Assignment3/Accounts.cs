using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Assignment3
{
    class Accounts
    {
        private string accountNo;
        private string customerName;
        private string accountType;
        private decimal balance;

        public Accounts(string accountNo, string customerName, string accountType)
        {
            this.accountNo = accountNo;
            this.customerName = customerName;
            this.accountType = accountType;
            this.balance = 0; 
        }

        public void UpdateBalance(char transactionType, int amount)
        {
            if (transactionType == 'D' || transactionType == 'd')
            {
                Credit(amount);
            }
            else if (transactionType == 'W' || transactionType == 'w')
            {
                Debit(amount);
            }
            else
            {
                Console.WriteLine("Invalid transaction type. Use 'D' for Deposit or 'W' for Withdrawal.");
            }
        }

        private void Credit(int amount)
        {
            balance += amount;
            Console.WriteLine($"Deposited: {amount}. New balance: {balance}");
        }

        private void Debit(int amt)
        {
            if (amt > balance)
            {
                Console.WriteLine("Insufficient balance for withdrawal.");
            }
            else
            {
                balance -= amt;
                Console.WriteLine($"Withdrew: {amt}. New balance: {balance}");
            }
        }

        public void ShowData()
        {
            Console.WriteLine($"\nAccount No: {accountNo}");
            Console.WriteLine($"Customer Name: {customerName}");
            Console.WriteLine($"Account Type: {accountType}");
            Console.WriteLine($"Current Balance: {balance}\n");
        }
    }

    class Program
    {
        static void Main()
        {
            Console.Write("Enter Account Number: ");
            string accountNo = Console.ReadLine();

            Console.Write("Enter Customer Name: ");
            string customerName = Console.ReadLine();

            Console.Write("Enter Account Type (e.g., Saving, Current): ");
            string accountType = Console.ReadLine();

            Accounts account = new Accounts(accountNo, customerName, accountType);

            account.ShowData();

            while (true)
            {
                Console.Write("Enter transaction type (D for Deposit, W for Withdrawal, Q to Quit): ");
                char transactionType = Char.ToUpper(Console.ReadKey().KeyChar);
                Console.WriteLine(); 

                if (transactionType == 'Q')
                {
                    break; 
                }

                Console.Write("Enter amount: ");
                if (int.TryParse(Console.ReadLine(), out int amount))
                {
                    account.UpdateBalance(transactionType, amount);
                    account.ShowData(); 
                }
                else
                {
                    Console.WriteLine("Invalid amount. Please enter a valid number.");
                }
            }

        }
    }
}
