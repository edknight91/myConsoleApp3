using System;

namespace myConsoleApp3
{

    //Create a new class which represents a bank account, it should have several properties, at least:
    // Account Number, Account Balance, Account NAme
    public class BankAccount

    {
        public BankAccount()
        {
            Balance = 0;
            Overdraft = 10;
        }
        public string Name { get; set; }
        public int Number { get; set; }
        public double Balance { get; set; }

        public double Overdraft { get; set; }


        public void AddDeposit(double depositAmount)
        {
            Balance += depositAmount;
        }

        // Method checks balance doesn't become negative
        public bool CheckBalanceIsSufficient(double amount)
        {
            try
            {
                if (amount > (Balance + Overdraft))
                {
                    throw new InsufficientBalanceException();
                }
            }

            catch (InsufficientBalanceException ex)
            {

                Console.WriteLine($"'Insufficient funds. Exception: ${ex}");
                return false;
            }

            catch (Exception ex)
            {
                Console.WriteLine($"Exception: ${ex}");
                return false;
            }

            return true;
        }

        public void Withdrawal(double withdrawalAmount)
        {
            Balance -= withdrawalAmount;
        }
    }
}