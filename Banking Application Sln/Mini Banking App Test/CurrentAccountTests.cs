namespace Mini_Banking_App_Test
{
    internal class CurrentAccountTests
    {
        [Test]
        public void DepositFundValidTest()
        {
            var current = new CurrentAccount(10000, DateTime.Now, "Opening Deposit");

            current.DepositFund(2500, DateTime.Now, "Deposit");
            Assert.That(current.Balance, Is.EqualTo(12500));
        }

        [Test]
        public void DepositFundInvalidTest()
        {
            var current = new CurrentAccount();
            Assert.That(() => current.DepositFund(-1000, DateTime.Now, "Opening Deposit"), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WithdrawFundValidTest()
        {
            var current = new CurrentAccount(10000, DateTime.Now, "Opening Deposit");

            current.WithdrawFund(5000, DateTime.Now, "Withdrawal");
            Assert.That(current.Balance, Is.EqualTo(5000));
        }

        [Test]
        public void WithdrawFundInvalidTest1()
        {
            var current = new CurrentAccount(10000, DateTime.Now, "Opening Deposit");
            Assert.That(() => current.WithdrawFund(-1000, DateTime.Now, "Withdrawal"), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void WithdrawFundInvalidTest2()
        {
            var current = new CurrentAccount(10000, DateTime.Now, "Opening Deposit");
            Assert.That(() => current.WithdrawFund(20000, DateTime.Now, "Withdrawal"), Throws.TypeOf<InvalidOperationException>());
        }

        [Test]
        public void TransferFundValidTest()
        {
            var current = new CurrentAccount(10000, DateTime.Now, "Opening Deposit");
            var secondcurrent = new CurrentAccount(10000, DateTime.Now, "Opening Deposit");

            current.TransferFund(2000, DateTime.Now, "Transfer", secondcurrent);
            Assert.That(current.Balance, Is.EqualTo(8000));
        }

        [Test]
        public void TransferFundValidTest2()
        {
            var current = new CurrentAccount(10000, DateTime.Now, "Opening Deposit");
            var secondcurrent = new CurrentAccount(10000, DateTime.Now, "Opening Deposit");

            current.TransferFund(2000, DateTime.Now, "Transfer", secondcurrent);
            Assert.That(secondcurrent.Balance, Is.EqualTo(12000));
        }

        [Test]
        public void TransferFundInvalidTest()
        {
            var current = new CurrentAccount(10000, DateTime.Now, "Opening Deposit");
            var secondcurrent = new CurrentAccount(10000, DateTime.Now, "Opening Deposit");

            Assert.That(() => current.TransferFund(-1000, DateTime.Now, "Transfer", secondcurrent), Throws.TypeOf<ArgumentOutOfRangeException>());
        }

        [Test]
        public void TransferFundInvalidTest1()
        {
            var current = new CurrentAccount(10000, DateTime.Now, "Opening Deposit");
            var secondcurrent = new CurrentAccount(10000, DateTime.Now, "Opening Deposit");

            Assert.That(() => current.TransferFund(12000, DateTime.Now, "Transfer", secondcurrent), Throws.TypeOf<InvalidOperationException>());
        }
    }
}
