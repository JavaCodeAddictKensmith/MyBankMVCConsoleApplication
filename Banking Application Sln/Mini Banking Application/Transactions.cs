// See https://aka.ms/new-console-template for more information
public class Transactions
{
    public decimal Amount { get; }
    public DateTime Date { get; }
    public string Narration { get; }

    public Transactions(decimal amount, DateTime date, string narration)
    {
        Amount = amount;
        Date = date;
        Narration = narration;
    }
}
