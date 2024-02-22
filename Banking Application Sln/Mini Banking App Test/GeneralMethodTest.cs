namespace Mini_Banking_App_Test
{
    internal class GeneralMethodTest
    {
        [Test]
        public void FirstCharacterUpperValidTest()
        {
            var actual = CreateAccount.FirstCharacterUpper("chidozie");
            var expected = "Chidozie";

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void FirstCharacterUpperInValidTest()
        {
            var actual = CreateAccount.FirstCharacterUpper("chidozie");
            var expected = "chidozie";

            Assert.That(actual, Is.Not.EqualTo(expected));
        }

        [Test]
        public void ValidatePhoneNumberValidTest()
        {
            var actual = CreateAccount.ValidatePhoneNumber("07062746869");
            var expected = true;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ValidatePhoneNumberInValidTest()
        {
            var actual = CreateAccount.ValidatePhoneNumber("0706246869");
            var expected = false;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void EmailValidTest()
        {
            var savings = new SavingsAccount()
            {
                Email = "chivy4gud@gmail.com"
            };

            Assert.That(CreateAccount.IsEmailValid(savings.Email), Is.EqualTo(true));
        }

        [Test]
        public void EmailInValidTest()
        {
            var savings = new SavingsAccount()
            {
                Email = "chivy4gudgmail.com"
            };

            Assert.That(CreateAccount.IsEmailValid(savings.Email), Is.Not.EqualTo(true));
        }

        [Test]
        public void ValidateNameValidTest()
        {
            var actual = CreateAccount.ValidateName("Dozie");
            var expected = true;

            Assert.That(actual, Is.EqualTo(expected));
        }

        [Test]
        public void ValidateNameInValidTest()
        {
            var actual = CreateAccount.ValidateName("D@ozie");
            var expected = false;

            Assert.That(actual, Is.EqualTo(expected));
        }
    }
}
