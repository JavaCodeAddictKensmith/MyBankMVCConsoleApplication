Accounts accounts = CreateAccount.InitiateAccountCreation();

List<SavingsAccount> savings = accounts.Savings;
List<CurrentAccount> current = accounts.current;

AccoutOperations.PerformAccountOperation(savings, current);

PrintDifferentTables.DisplayDifferentTables(savings, current);