using Bank;

namespace BankNUnitTests
{
    public class BankAccountTests
    {
        private BankAccount account;

        [SetUp]
        public void SetUp()
        {
            // Arrange
            account = new BankAccount(1000);
        }

        [Test]
        public void Adding_Funds_Updates_Balance()
        {
            // Act
            account.Add(500);

            // Assert
            Assert.AreEqual(1500, account.Balance);
        }

        [Test]
        public void Adding_Negative_Funds_Throw_Exception()
        {
            // Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Add(-500));
        }

        [Test]
        public void Withdrawing_Funds_Updates_Balance()
        {
            // Act
            account.Withdraw(500);

            // Assert
            Assert.AreEqual(500, account.Balance);
        }

        [Test]
        public void Withdrawing_Negative_Funds_Throws_Exception()
        {
            // Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(-500));
        }

        [Test]
        public void Withdrawing_More_Than_Balance_Throws_Exception()
        {
            // Act + Assert
            Assert.Throws<ArgumentOutOfRangeException>(() => account.Withdraw(2000));
        }

        [Test]
        public void Transferring_Funds_Updates_BothAccount()
        {
            // Arrange
            var otherAccount = new BankAccount();

            // Act
            account.TransferFundsTo(otherAccount, 500);

            // Assert
            Assert.AreEqual(500, account.Balance);
            Assert.AreEqual(500, otherAccount.Balance);
        }

        [Test]
        public void Transferring_To_Non_Existing_Account_Throws_Exception()
        {
            // Act + Assert
            Assert.Throws<ArgumentNullException>(() => account.TransferFundsTo(null, 500));
        }
    }
}