using System;

namespace myConsoleApp3
{

    //Create a new class which represents a bank account, it should have several properties, at least: Account Name, Account Number
    // Account Number, Account Balance, Account NAme
    public class BankAccount

    {
        public BankAccount()
        {
            AccountBalance = 0;
        }
        public string AccountName { get; set; }
        public int AccountNumber { get; set; }
        public double AccountBalance { get; set; }


        public void AddDeposit(double amount)
        {
            AccountBalance += amount;
        }

        public void Withdrawal(double amount)
        {
            AccountBalance -= amount;
        }

    }
}