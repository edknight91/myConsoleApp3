using System;
using System.Collections.Generic;
using System.Linq;

namespace myConsoleApp3
{
    class Program
    {
        public static List<BankAccount> BankAccounts = new List<BankAccount>();
        public static void Main(string[] args)
        {
            Console.WriteLine("Press any key to create a new account");
            Console.ReadLine();
            CreateNewAccount();
            ListAllAccounts();
        }

        // Add new bank account to list and assign accountName
        static void CreateNewAccount()
        {
            Console.WriteLine("Enter a name for the account");
            string givenAccountName = Console.ReadLine();

            BankAccounts.Add(new BankAccount()
            {
                AccountNumber = BankAccounts.Count + 10000001,
                AccountName = givenAccountName
            });


        }
        // List all accounts in the list
        static void ListAllAccounts()
        {
            Console.WriteLine("Listing all accounts...");
            BankAccounts.ForEach(bankAccount => Console.WriteLine($"Account Name: " + bankAccount.AccountName + " Account Number :" + bankAccount.AccountNumber + " Account Balance: £" + bankAccount.AccountBalance + "\n"));
        }

        // List the account details for a specified account number

        static void ListAccountDetails()
        {

        }

        //method checks if the account number entered exists in the list
        public static BankAccount CheckIsAccount(string inputAccountNumber)
        {
            try
            {
                //int chosenAccountNumber = int.Parse(inputAccountNumber);
                if (int.TryParse(inputAccountNumber, out var chosenAccountNumber) == false)
                {
                    throw new FormatException($"The entered account number was not a number: {inputAccountNumber}");
                }

                //bool isAccount = BankAccounts.Exists(BankAccount => BankAccount.AccountNumber == chosenAccountNumber);

                // this will return null if not found, otherwise the first b/a with a matching number
                return BankAccounts.FirstOrDefault(bankAccount => bankAccount.AccountNumber == chosenAccountNumber);
                //return isAccount;
            }
            catch (FormatException ex)
            {
                Console.WriteLine($"'{inputAccountNumber}' is not an account number. Exception: ${ex}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"Exception: ${ex}");
            }

            return null;
        }


        // Add a deposit to a specified account ( amount must not be negative or zero)

        static void AddDeposit()
        {

            Console.WriteLine("Enter your account number");
            var inputAccountNumber = Console.ReadLine();

            var bankAccount = CheckIsAccount(inputAccountNumber);

            if (bankAccount != null)
            {
                Console.WriteLine("How much would you like to deposit?");
                var depositAmountString = Console.ReadLine();

                if (double.TryParse(depositAmountString, out var depositAmount))
                {
                    bankAccount.AddDeposit(depositAmount);
                }
            }

        }

        // Subtract an amount from specified account (accounts must not have negative balances)

        static void EnterWithdrawal()
        {

            Console.WriteLine("Enter your account number");
            var inputAccountNumber = Console.ReadLine();

            var bankAccount = CheckIsAccount(inputAccountNumber);

            if (bankAccount != null)
            {
                Console.WriteLine("How much would you like to withdraw?");
                var withdrawalAmountString = Console.ReadLine();

                if (double.TryParse(withdrawalAmountString, out var withdrawalAmount))
                {
                    bankAccount.Withdrawal(withdrawalAmount);
                }
            }
        }

        // Transfer an amount between two specified accounts. Accounts canm't transfer to themselves or end up with negative balances.

        static void EnterTransfer()
        {
            Console.WriteLine("Transferring between two accounts...");
        }

        //Implement overdraft limit on the BankAccount class so that instead of not permitting a negative balance, 
        // it doesn’t permit the overdraft limit per account to be exceeded
    }
}