using System;

namespace myConsoleApp3
{
    public class InsufficientBalanceException : Exception
    {
        public InsufficientBalanceException()
        {
            Console.WriteLine("Insufficient funds to make this transactions");
        }
    }
}