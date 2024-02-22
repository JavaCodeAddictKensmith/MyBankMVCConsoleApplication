public interface IBankTransactions
{
    void DepositFund(decimal amount, DateTime date, string narration);
    void WithdrawFund(decimal amount, DateTime date, string narration);
}


