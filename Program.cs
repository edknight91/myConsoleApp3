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
            bool shouldRepeat = true;

            while (shouldRepeat)
            {
                Console.WriteLine("What would you like to do today");
                Console.WriteLine("Press N to create a new account");
                Console.WriteLine("Press A to list all accounts");
                Console.WriteLine("Press L to list a single account");
                Console.WriteLine("Press D to make a deposit");
                Console.WriteLine("Press W to make a withdrawal");
                Console.WriteLine("Press T to make a transfer");
                Console.WriteLine();
                Console.WriteLine("Or press Q to quit");

                var input = Console.ReadKey().Key;

                switch (input)
                {
                    case ConsoleKey.N:
                        CreateNewAccount();
                        break;

                    case ConsoleKey.A:
                        ListAllAccounts();
                        break;

                    case ConsoleKey.L:
                        ListAccountDetails();
                        break;

                    case ConsoleKey.D:
                        AddDeposit();
                        break;

                    case ConsoleKey.W:
                        EnterWithdrawal();
                        break;

                    case ConsoleKey.T:
                        EnterTransfer();
                        break;

                    case ConsoleKey.Q:
                        shouldRepeat = false;
                        break;

                    default:
                        Console.WriteLine();
                        Console.WriteLine();
                        Console.WriteLine("See ya skip");
                        Console.WriteLine();
                        Console.WriteLine();
                        break;
                }
            }

            // Add new bank account to list and assign accountName
            static void CreateNewAccount()
            {
                Console.WriteLine("Enter a name for the account");
                string givenAccountName = Console.ReadLine();

                BankAccounts.Add(new BankAccount()
                {
                    Number = BankAccounts.Count + 01,
                    Name = givenAccountName
                });
            }

            // List all accounts in the list
            static void ListAllAccounts()
            {
                Console.WriteLine("Listing all accounts...");
                BankAccounts.ForEach(bankAccount => Console.WriteLine($"Account Name: " + bankAccount.Name + " Account Number :" + bankAccount.Number + " Account Balance: £" + bankAccount.Balance + "\n"));
            }


            //method checks if the account number entered exists in the list
            static BankAccount CheckIsAccount(string inputAccountNumber)
            {
                try
                {
                    //int chosenAccountNumber = int.Parse(inputAccountNumber);
                    if (int.TryParse(inputAccountNumber, out var chosenAccountNumber) == false)
                    {
                        throw new FormatException($"The entered account number was not a number: {inputAccountNumber}");
                    }
                    return BankAccounts.FirstOrDefault(bankAccount => bankAccount.Number == chosenAccountNumber);
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


            // List the account details for a specified account number

            static void ListAccountDetails()
            {
                Console.WriteLine("Enter the account number of the account you'd like to view");
                var inputAccountNumber = Console.ReadLine();

                var bankAccount = CheckIsAccount(inputAccountNumber);

                if (bankAccount != null)
                {
                    Console.WriteLine($"Account Name: " + bankAccount.Name + " Account Number :" + bankAccount.Number + " Account Balance: £" + bankAccount.Balance + "\n");
                }
            }

            // Add a deposit to a specified account (amount must not be negative or zero)

            static void AddDeposit()
            {

                Console.WriteLine("Enter your account number");
                var inputAccountNumber = Console.ReadLine();

                var bankAccount = CheckIsAccount(inputAccountNumber);

                if (bankAccount != null)
                {
                    Console.WriteLine("How much would you like to deposit?");
                    string inputtedDepositAmount = Console.ReadLine();

                    if (double.TryParse(inputtedDepositAmount, out var depositAmount) && depositAmount > 0)
                    {
                        bankAccount.AddDeposit(depositAmount);
                        Console.WriteLine($"Your new balance is £{bankAccount.Balance}");
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
                    string inputtedWithdrawalAmount = Console.ReadLine();


                    if (double.TryParse(inputtedWithdrawalAmount, out double withdrawalAmount))
                    {
                        bankAccount.CheckBalanceIsSufficient(withdrawalAmount);
                        bankAccount.Withdrawal(withdrawalAmount);
                        Console.WriteLine($"Your new balance is {bankAccount.Balance}");

                    }
                }
            }

            // Transfer an amount between two specified accounts. Accounts can't transfer to themselves or end up with negative balances.

            static void EnterTransfer()
            {
                Console.WriteLine("Transferring between two accounts...");

                Console.WriteLine("Enter the account number you'd like to transfer from");
                var inputFromAccountNumber = Console.ReadLine();

                var fromBankAccount = CheckIsAccount(inputFromAccountNumber);

                if (fromBankAccount != null)
                {
                    Console.WriteLine("How much would you like to transfer?");
                    string inputtedTransferAmount = Console.ReadLine();

                    if (double.TryParse(inputtedTransferAmount, out double transferAmount))
                    {
                        fromBankAccount.CheckBalanceIsSufficient(transferAmount);
                        fromBankAccount.Withdrawal(transferAmount);
                    }

                    Console.WriteLine($"Enter the account number youd like to transfer {transferAmount} to");

                    string inputToAccountNumber = Console.ReadLine();

                    var toBankAccount = CheckIsAccount(inputToAccountNumber);

                    if (toBankAccount != null)
                    {
                        toBankAccount.AddDeposit(transferAmount);
                    }
                }
            }

            //Implement overdraft limit on the BankAccount class so that instead of not permitting a negative balance, 
            //it doesn’t permit the overdraft limit per account to be exceeded.
        }
    }
}