using System.Text.RegularExpressions;

public static class CreateAccount
{
    public static Accounts InitiateAccountCreation()
    {
        List<SavingsAccount> savings = new List<SavingsAccount>();
        List<CurrentAccount> current = new List<CurrentAccount>();
        string? firstName = string.Empty;
        string? lastName = string.Empty;
        string? email = string.Empty;
        string? phoneNumber = string.Empty;
        string? input = string.Empty;
        decimal amount = 0;
        string[] yesOrNo = { "yes", "no" };
        var type = string.Empty;

        Console.WriteLine("***********************************Welcome To ABC Bank Plc********************************");

        while (true)
        {
            Options1();
            input = Console.ReadLine();

            while (true)
            {
                Console.Write("Enter your firstname:  ");
                firstName = Console.ReadLine().Trim();

                if (ValidateName(firstName))
                    break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{firstName} has a wrong format. Enter the right format without any special characters or numbers");
                Console.ResetColor();
            }

            while (true)
            {
                Console.Write("Enter your lastname:  ");
                lastName = Console.ReadLine().Trim();

                if (ValidateName(lastName))
                    break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{lastName} has a wrong format. Enter the right format without any special characters or numbers");
                Console.ResetColor();
            }

            // Check if the customer already has that type of account
            var accountExits = false;

            if (savings.Count > 0)
            {
                if (input == "1")
                {
                    foreach (var account in savings)
                    {
                        if (account.AccountName.ToLower() == firstName + " " + lastName)
                        {
                            Console.WriteLine("You already have a savings account, open a current account instead");
                            accountExits = true;
                        }

                    }
                }
            }

            if (current.Count > 0)
            {
                if (input == "2")
                {
                    foreach (var account in current)
                    {
                        if (account.AccountName.ToLower() == firstName + " " + lastName)
                        {
                            Console.WriteLine("You already have a current account, open a savings account instead");
                            accountExits = true;
                        }

                    }
                }
            }

            if (accountExits)
                continue;

            while (true)
            {
                Console.Write("Enter your email address:  ");
                email = Console.ReadLine().Trim();

                if (IsEmailValid(email))
                    break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{email} has a wrong format. Enter the right format eg: chivy4gud@gmail.com");
                Console.ResetColor();
            }

            while (true)
            {
                Console.Write("Enter your eleven digit phone number, eg: 07062746869:  ");
                phoneNumber = Console.ReadLine().Trim(); ;

                if (ValidatePhoneNumber(phoneNumber))
                    break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"{phoneNumber} has a wrong format. Enter the right format must be eleven digits");
                Console.ResetColor();
            }

            while (true)
            {
                Console.Write("How much do you want to open account with; Minimum opening balance is 1000: ");
                var n = Console.ReadLine().Trim();

                var isValid = decimal.TryParse(n, out amount);

                if (ValidAmount(amount))
                    break;

                Console.ForegroundColor = ConsoleColor.Red;
                Console.WriteLine($"Amount cannot be 0 or negative number");
                Console.ResetColor();
            }


            switch (input)
            {
                case "1":
                    SavingsAccount savingsAccount = new SavingsAccount(amount, DateTime.Now, $"Opened a saving account with {amount} opening balance");

                    savingsAccount.AccountType = AccountType.Savings.ToString();
                    savingsAccount.Email = email;
                    savingsAccount.FirstName = firstName;
                    savingsAccount.LastName = lastName;
                    savingsAccount.PhoneNumber = phoneNumber;

                    savings.Add(savingsAccount);

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Your savings account has been successfully opened.Below are your account details");
                    Console.WriteLine($"Account Name\tAcoount Number\tOpening Bal\tEmail\t\tAccountType\tPhoneNumber\n{savingsAccount.AccountName}\t{savingsAccount.AccountNumber}\t{savingsAccount.Balance}\t\t{email}\t{savingsAccount.AccountType}\t\t{phoneNumber}");
                    Console.ResetColor();
                    Console.WriteLine();

                    break;
                case "2":
                    CurrentAccount currentAccount = new CurrentAccount(amount, DateTime.Now, $"Opened a current account with {amount} opening balance\n")
                    {
                        AccountType = AccountType.Current.ToString(),
                        Email = email,
                        FirstName = firstName,
                        LastName = lastName,
                        PhoneNumber = phoneNumber,
                    };

                    current.Add(currentAccount);

                    Console.WriteLine();
                    Console.ForegroundColor = ConsoleColor.Green;
                    Console.WriteLine($"Your savings account has been successfully opened.Below are your account details");
                    Console.WriteLine($"Account Name\tAcoount Number\tOpening Bal\tEmail\t\tAccountType\tPhoneNumber\n{currentAccount.AccountName}\t{currentAccount.AccountNumber}\t{currentAccount.Balance}\t\t{email}\t{currentAccount.AccountType}\t\t{phoneNumber}");
                    Console.ResetColor();
                    Console.WriteLine();

                    break;
                default:
                    break;
            }

            Console.WriteLine("Would you like to open another account: ");

            var decision = string.Empty;
            while (true)
            {
                Console.WriteLine("Enter \"yes\" to open another account or \"no\" to continue: ");
                decision = Console.ReadLine().Trim().ToLower();

                if (yesOrNo.Contains(decision))
                    break;
            }

            if (decision == "yes")
                continue;

            if (decision == "no")
                break;
        }
        Accounts accounts = new Accounts()
        {
            Savings = savings,
            current = current
        };

        return accounts;
    }

    private static void Options1()
    {
        var options = @"Select one option to continue
Enter 1 To Open a Savings Account
Enter 2 To Open a Current Account";

        Console.WriteLine("\n" + options);
    }

    public static bool ValidateName(string name)
    {
        var regex = @"^[\p{L} \.\-]+$";
        Regex newRegex = new Regex(regex);

        if (!newRegex.IsMatch(name))
            return false;

        return true;
    }

    //private static bool ValidateName(string name)
    //{

    //    if ((!Regex.IsMatch(name, @"^[\p{L}\p{M}' \.\-]+$")))
    //        return false;

    //    return true;
    //}

    public static bool ValidatePhoneNumber(string number)
    {
        if (number == null || number.Length != 11)
            return false;

        return true;
    }

    public static bool ValidAmount(decimal amount)
    {
        if (amount < 1000)
            return false;

        return true;
    }

    public static string FirstCharacterUpper(string input)
    {
        var name = input[0].ToString().ToUpper();

        for (int i = 1; i < input.Length; i++)
            name += input[i];

        return name;
    }

    public static bool IsEmailValid(string email)
    {
        string emailRegex = "^[0-9A-Za-z]+[_+.-]{0,1}[0-9A-Za-z]+[@][a-zA-Z]+[.][A-Za-z]{2,3}([.][a-zA-Z]{2,3}){0,1}$";

        return Regex.IsMatch(email, emailRegex);
    }
}