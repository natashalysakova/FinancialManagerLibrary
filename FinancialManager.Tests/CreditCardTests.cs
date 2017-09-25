using FinancialManagerLibrary;
using FinancialManagerLibrary.Wallets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinancialManager.Tests
{
    [TestClass]
    public class CreditCardTests
    {
        [TestMethod]
        public void PositiveBalanceIncreaseTest()
        {
            var card = new Wallet("testCard", 100, Currency.UAH, 1000);
            card.IncreaseBalance(50);
            Assert.AreEqual(150, card.Balance);
        }

        [TestMethod]
        public void PositiveBalanceDecreaseTest()
        {
            var card = new Wallet("testCard", 100, Currency.UAH, 1000);
            card.DecreaseBalance(50);
            Assert.AreEqual(50, card.Balance);
        }

        [TestMethod]
        public void DecreaseInOverdraftTest()
        {
            var card = new Wallet("testCard", 0, Currency.UAH, 1000);
            card.DecreaseBalance(50);
            Assert.AreEqual(-50, card.Balance);

            card.DecreaseBalance(30);
            Assert.AreEqual(-80, card.Balance);
        }


        [TestMethod]
        public void IncreaseInOverdraftTest()
        {
            var card = new Wallet("testCard", 0, Currency.UAH, 1000);
            card.DecreaseBalance(50);
            Assert.AreEqual(-50, card.Balance);

            card.IncreaseBalance(30);
            Assert.AreEqual(-20, card.Balance);
        }

        [TestMethod]
        public void StartOverdraftTest()
        {
            var card = new Wallet("testCard", 100, Currency.UAH, 1000);
            card.DecreaseBalance(150);
            Assert.AreEqual(-50, card.Balance);
        }

        [TestMethod]
        public void CloseOverdraftTest()
        {
            var card = new Wallet("testCard", 100, Currency.UAH, 1000);
            card.DecreaseBalance(150);
            card.IncreaseBalance(75);

            Assert.AreEqual(25, card.Balance);
        }

        [TestMethod]
        [ExpectedException(typeof(OverdraftLimitReachedException))]
        public void OverdraftLimitReached()
        {
            var card = new Wallet("testCard", 100, Currency.UAH, 1000);
            card.DecreaseBalance(350);
            card.DecreaseBalance(860);
        }
    }
}