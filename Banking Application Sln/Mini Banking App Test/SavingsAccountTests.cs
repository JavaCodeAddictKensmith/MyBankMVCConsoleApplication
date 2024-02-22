namespace Mini_Banking_App_Test
{
    public class SavingsAccountTests
    {
        [Test]
        public void DepositFundValidTest()
        {
            var savings = new SavingsAccount(10000, DateTime.Now, "Opening Deposit");

            savings.DepositFund(2500, DateTime.Now, "Deposit");
            Assert.That(savings.Balance, Is.EqualTo(12500));
        }

        [Test]
        public void DepositFundInvalidTest()
        {
            var savings = new SavingsAccount();
            Assert.That(() => savings.DepositFund(-1000, DateTime.Now, "Opening Deposit"), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WithdrawFundValidTest()
        {
            var savings = new SavingsAccount(10000, DateTime.Now, "Opening Deposit");

            savings.WithdrawFund(5000, DateTime.Now, "Withdrawal");
            Assert.That(savings.Balance, Is.EqualTo(5000));
        }

        [Test]
        public void WithdrawFundInvalidTest1()
        {
            var savings = new SavingsAccount(10000, DateTime.Now, "Opening Deposit");
            Assert.That(() => savings.WithdrawFund(-1000, DateTime.Now, "Withdrawal"), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WithdrawFundInvalidTest2()
        {
            var savings = new SavingsAccount(10000, DateTime.Now, "Opening Deposit");
            Assert.That(() => savings.WithdrawFund(20000, DateTime.Now, "Withdrawal"), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void TransferFundValidTest()
        {
            var savings = new SavingsAccount(10000, DateTime.Now, "Opening Deposit");
            var secondSavings = new SavingsAccount(10000, DateTime.Now, "Opening Deposit");

            savings.TransferFund(2000, DateTime.Now, "Transfer", secondSavings);
            Assert.That(savings.Balance, Is.EqualTo(8000));
        }

        [Test]
        public void TransferFundValidTest2()
        {
            var savings = new SavingsAccount(10000, DateTime.Now, "Opening Deposit");
            var secondSavings = new SavingsAccount(10000, DateTime.Now, "Opening Deposit");

            savings.TransferFund(2000, DateTime.Now, "Transfer", secondSavings);
            Assert.That(secondSavings.Balance, Is.EqualTo(12000));
        }

        [Test]
        public void TransferFundInvalidTest()
        {
            var savings = new SavingsAccount(10000, DateTime.Now, "Opening Deposit");
            var secondSavings = new SavingsAccount(10000, DateTime.Now, "Opening Deposit");

            Assert.That(() => savings.TransferFund(-1000, DateTime.Now, "Transfer", secondSavings), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void TransferFundInvalidTest1()
        {
            var savings = new SavingsAccount(10000, DateTime.Now, "Opening Deposit");
            var secondSavings = new SavingsAccount(10000, DateTime.Now, "Opening Deposit");

            Assert.That(() => savings.TransferFund(12000, DateTime.Now, "Transfer", secondSavings), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void AccountNameValidTest()
        {
            var savings = new SavingsAccount()
            {
                FirstName = "chidozie",
                LastName = "osigwe"
            };

            var expected = "Chidozie Osigwe";
            Assert.That(savings.AccountName, Is.EqualTo(expected));

        }
    }
}