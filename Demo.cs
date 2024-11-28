using System;

class InsufficientBalanceException : Exception
{
    public InsufficientBalanceException() : base("Insufficient balance") { }
}

class BankAccount
{
    public decimal Balance { get; private set; }

    public BankAccount()
    {
        Balance = 5000;
    }

    public void Withdraw(decimal amount)
    {
        if (amount > Balance)
        {
            throw new InsufficientBalanceException();
        }
        Balance -= amount;
    }
}

class Program
{
    static void Main()
    {
        BankAccount account = new BankAccount();

        Console.Write("Enter amount to withdraw: ");
        string input = Console.ReadLine();

        if (decimal.TryParse(input, out decimal amount))
        {
            try
            {
                account.Withdraw(amount);
                Console.WriteLine("Withdrawal successful. New balance: " + account.Balance);
            }
            catch (InsufficientBalanceException ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
        else
        {
            Console.WriteLine("Invalid amount.");
        }
    }
}
