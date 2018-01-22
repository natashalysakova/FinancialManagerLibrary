using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using FinancialManagerLibrary;
using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Repositories;
using FinancialManagerLibrary.Utilities;
using FinancialManagerLibrary.Transactions;
using FinancialManagerLibrary.Wallets;
using FinancialManagerLibrary.Incomes;
using FinancialManagerLibrary.Models;

namespace FinancialManager.Services
{
    public class FinancialService
    {
        private readonly BaseRepository<Category, CategoryEntity> _categoryRepository;
        private readonly BaseRepository<Wallet, WalletEntity> _walletRepository;
        private readonly BaseRepository<Income, IncomeEntity> _incomeRepository;
        private readonly BaseRepository<Transaction, TransactionEntity> _transactionRepository;


        public FinancialService(IFinancialDataSource service)
        {
            _categoryRepository = new BaseRepository<Category, CategoryEntity>(service.CategoryService);
            _walletRepository = new BaseRepository<Wallet, WalletEntity>(service.WalletService);
            _incomeRepository = new BaseRepository<Income, IncomeEntity>(service.IncomeService);
            _transactionRepository = new BaseRepository<Transaction, TransactionEntity>(service.TransactionService);
        }

        public IEnumerable<(int, string)> GetSourceList(ListTypes type)
        {
            List<(int, string)> _list = new List<(int, string)>();

            switch (type)
            {
                case ListTypes.Income:
                    _list.AddRange(_incomeRepository
                        .GetAll()
                        .Select(x => (x.Id, x.Name)));
                    break;
                case ListTypes.Expences:
                    _list.AddRange(_walletRepository
                        .GetAll()
                        .Select(x => (x.Id, x.Name)));
                    break;
                case ListTypes.Transfer:
                    _list.AddRange(_walletRepository
                        .GetAll()
                        .Select(x => (x.Id, x.Name)));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return _list;
        }

        public IEnumerable<(int, string)> GetTargetList(ListTypes type)
        {
            List<(int, string)> _list = new List<(int, string)>();

            switch (type)
            {
                case ListTypes.Income:
                    _list.AddRange(_walletRepository
                        .GetAll()
                        .Select(x => (x.Id, x.Name)));
                    break;
                case ListTypes.Expences:
                    _list.AddRange(_categoryRepository
                        .GetAll()
                        .Select(x => (x.Id, x.Name)));
                    break;
                case ListTypes.Transfer:
                    _list.AddRange(_walletRepository
                        .GetAll()
                        .Select(x => (x.Id, x.Name)));
                    break;
                default:
                    throw new ArgumentOutOfRangeException(nameof(type), type, null);
            }

            return _list;
        }

        public Category EditCategory(Category model)
        {
            return _categoryRepository.Update(model);
        }

        public bool DeleteCategory(int id)
        {
            return _categoryRepository.Delete(id);
        }

        public Category AddCategory(Category category)
        {
            return _categoryRepository.Add(category);
        }

        public IEnumerable<Transaction> GetAllTransactions()
        {
            return _transactionRepository.GetAll();
        }

        public IEnumerable<Income> GetAllIncomes()
        {
            return _incomeRepository.GetAll();
        }

        public Transaction AddTransaction(Transaction transaction)
        {
            var newTransaction = _transactionRepository.Add(transaction);

            if (transaction.From is Wallet)
            {
                _walletRepository.Update(transaction.From as Wallet);
            }
            else if (transaction.From is Income)
            {
                _incomeRepository.Update(transaction.From as Income);
            }

            if (transaction.To is Wallet)
            {
                _walletRepository.Update(transaction.To as Wallet);
            }
            else if (transaction.To is Category)
            {
                _categoryRepository.Update(transaction.To as Category);
            }

            return newTransaction;
        }

        public Income GetIncome(int fromId)
        {
            return _incomeRepository.Get(fromId);
        }

        public Wallet GetWallet(int fromId)
        {
            return _walletRepository.Get(fromId);
        }

        public IEnumerable<Category> GetAllCategories()
        {
            return _categoryRepository.GetAll();
        }

        public Category GetCategory(int toId)
        {
            return _categoryRepository.Get(toId);
        }

        public Income AddIncome(Income income)
        {
            return _incomeRepository.Add(income);
        }

        public IEnumerable<Wallet> GetAllWallets()
        {
            return _walletRepository.GetAll();
        }

        public Wallet AddWallet(Wallet wallet)
        {
            return _walletRepository.Add(wallet);
        }
    }

    public enum ListTypes
    {
        Income,
        Expences,
        Transfer
    }
}