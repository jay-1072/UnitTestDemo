using BankAccountNS;

namespace BankTests
{
    [TestClass]
    public class BankAccountTests
    {
        #region Debit Amount Test

        #region Debit With Valid Amount Test

        [TestMethod]
        public void Debit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 4.55;
            double expected = 7.44;

            BankAccount account = new BankAccount("Jay Koshti", beginningBalance);

            // Act
            account.Debit(debitAmount);

            // Assert
            double actual = account.Balance;
            Assert.AreEqual(expected, actual, 0.001, "Account not debited correctly");
        }
        #endregion

        #region Debit With Amount Less Than Zero Test
        [TestMethod]
        public void Debit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = -20.00;

            BankAccount account = new BankAccount("Jay Koshti", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, BankAccount.DebitAmountLessThanZeroMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }
        #endregion

        #region Debit With Amount More Than Balance

        [TestMethod]
        public void Debit_WhenAmountIsMoreThanBalance_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double debitAmount = 20.00;

            BankAccount account = new BankAccount("Jay Koshti", beginningBalance);

            // Act
            try
            {
                account.Debit(debitAmount);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, BankAccount.DebitAmountExceedsBalanceMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }
        #endregion

        #endregion

        #region Credit Amount Test

        #region Credit With Valid Amount Test

        [TestMethod]
        public void Credit_WithValidAmount_UpdatesBalance()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = 20.00;

            BankAccount account = new BankAccount("Jay Koshti", beginningBalance);

            // Act
            try
            {
                account.Credit(creditAmount);
                return;
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, BankAccount.CreditAmountLessThanZeroMessage);
            }

            Assert.Fail("The expected exception was not thrown.");
        }
        #endregion

        #region Credit With Amount Less Than Zero Test

        [TestMethod]
        public void Credit_WhenAmountIsLessThanZero_ShouldThrowArgumentOutOfRange()
        {
            // Arrange
            double beginningBalance = 11.99;
            double creditAmount = -20.00;

            BankAccount account = new BankAccount("Jay Koshti", beginningBalance);

            // Act
            try
            {
                account.Credit(creditAmount);
            }
            catch (ArgumentOutOfRangeException ex)
            {
                // Assert
                StringAssert.Contains(ex.Message, BankAccount.CreditAmountLessThanZeroMessage);
                return;
            }

            Assert.Fail("The expected exception was not thrown.");
        }
        #endregion

        #endregion
    }
}