using System;
using FinancialManagerLibrary;
using FinancialManagerLibrary.Transactions;
using FinancialManagerLibrary.Wallets;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace FinancialManager.Tests
{
    [TestClass]
    public class TransactionsTests
    {
        private Category _category;
        private Wallet _wallet;

        [TestInitialize]
        public void Init()
        {
            _wallet = new Wallet("test wallet", 125, Currency.UAH);
            _category = new Category("food", Currency.UAH);
        }

        [TestCleanup]
        public void Clean()
        {
            _wallet = null;
            _category = null;
        }

        [TestMethod]
        public void PositiveTransaction()
        {
            var unused = new Transaction(_wallet, _category, 100, DateTime.Now, "test1");

            Assert.AreEqual(25.0, _wallet.Balance);
            Assert.AreEqual(100.0, _category.Balance);
        }

        [ExpectedException(typeof(LimitReachedException))]
        [TestMethod]
        public void NegativeTransaction()
        {
            var unused = new Transaction(_wallet, _category, 200, DateTime.Now, "test1");
        }

        [TestMethod]
        [ExpectedException(typeof(ArgumentException))]
        public void NegativeAmountTransaction()
        {
            var unused = new Transaction(_wallet, _category, -50, DateTime.Now, "test1");
        }
    }
}