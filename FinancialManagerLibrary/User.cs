using System.Collections.Generic;
using FinancialManagerLibrary.Transactions;
using FinancialManagerLibrary.Wallets;
using FinancialManagerLibrary.Incomes;

namespace FinancialManagerLibrary
{
    public class User
    {
        public User()
        {
            Incomes = new List<Income>();
            Wallets = new List<Wallet>();
            Categories = new List<Category>();
            Transactions = new List<Transaction>();
        }

        public int Id { get; }

        public List<Income> Incomes { get; }
        public List<Wallet> Wallets { get; }
        public List<Category> Categories { get; }
        public List<Transaction> Transactions { get; }

        public void AddIncome(Income income)
        {
            Incomes.Add(income);
        }

        public void AddCategory(Category category)
        {
            Categories.Add(category);
        }

        public void AddWallet(Wallet wallet)
        {
            Wallets.Add(wallet);
        }

        public void AddTransaction(Transaction transaction)
        {
            Transactions.Add(transaction);
        }
    }
}