// See https://aka.ms/new-console-template for more information

public class CurrentAccount : BankInfo, IBankTransactions
{
    public CurrentAccount()
    {

    }
    public CurrentAccount(decimal amount, DateTime date, string narration)
        :base()
    {
        DepositFund(amount, date, narration);
    }
    public void DepositFund(decimal amount, DateTime date, string narration)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot be 0 or less than 0");
        }

        var transaction = new Transactions(amount, date, narration);
        Transactions.Add(transaction);
    }

    public void TransferFund(decimal amount, DateTime date, string narration, SavingsAccount account)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot be less than 1");
        }

        if (Balance - amount <= 1000)
        {
            throw new InvalidOperationException("Insufficient Fund");
        }

        var savingsTransaction = new Transactions(amount, date, narration);
        var currentTransaction = new Transactions(-amount, date, narration);

        Transactions.Add(currentTransaction);
        account.Transactions.Add(savingsTransaction);
    }

    public void TransferFund(decimal amount, DateTime date, string narration, CurrentAccount account)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot be less than 1");
        }

        if (Balance - amount <= 1000)
        {
            throw new InvalidOperationException("Insufficient Fund");
        }

        var savingsTransaction = new Transactions(amount, date, narration);
        var currentTransaction = new Transactions(-amount, date, narration);

        Transactions.Add(currentTransaction);
        account.Transactions.Add(savingsTransaction);
    }

    public void WithdrawFund(decimal amount, DateTime date, string narration)
    {
        if (amount <= 0)
        {
            throw new ArgumentOutOfRangeException(nameof(amount), "Amount cannot be 0 or less than 0");
        }

        if (Balance - amount < 0)
        {
            throw new InvalidOperationException("Insufficient Fund");
        }

        var transaction = new Transactions(-amount, date, narration);
        Transactions.Add(transaction);
    }
}
