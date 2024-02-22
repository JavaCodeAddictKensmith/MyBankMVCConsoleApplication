public class BankInfo
{
    public string? FirstName { get; set; }
    public string? LastName { get; set; }
    public string Email { get; set; }
    public string AccountType { get; set; }
    public List<Transactions> Transactions { get; private set; }
    public string AccountNumber { get; }

    private string phoneNumber;
    public string PhoneNumber
    {
        get
        {
            return phoneNumber;
        }
        set
        {
            if (value.Length == 11)
                phoneNumber = value;
        }
    }

    public decimal Balance
    {
        get
        {
            decimal balance = 0;
            foreach (var item in Transactions)
            {
                balance += item.Amount;
            }
            return balance;
        }
    }

    public string AccountName
    {
        get
        {

            return $"{CreateAccount.FirstCharacterUpper(FirstName)} {CreateAccount.FirstCharacterUpper(LastName)}";
        }
    }

    public BankInfo()
    {
        Transactions = new List<Transactions>();
        AccountNumber = AccountGenerator();
    }

    private string AccountGenerator()
    {
        var random = new Random();

        string accountNumber = string.Empty;
        for (int i = 0; i < 10; i++)
            accountNumber = String.Concat(accountNumber, random.Next(10).ToString());
        return accountNumber;
    }
}

