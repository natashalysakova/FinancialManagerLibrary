using System;
using System.Collections.Generic;
using System.Linq;
using FinancialManager.Models;
using FinancialManager.Models.Extentions;
using FinancialManagerLibrary;
using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Repositories;
using FinancialManagerLibrary.Utilities;

namespace FinancialManager.Services
{
    public class BuisnessService
    {
        private readonly CategoryRepository _categoryRepository;
        private readonly WalletRepository _walletRepository;
        private readonly IncomeRepository _incomeRepository;
        private readonly TransactionRepository _transactionRepository;



        public BuisnessService(IFinancialDataSource service)
        {
            _categoryRepository = new CategoryRepository(service.CategoryService);
            _walletRepository = new WalletRepository(service.WalletService);
            _incomeRepository = new IncomeRepository(service.IncomeService);
            _transactionRepository = new TransactionRepository(service.TransactionService);
        }


        public CategoryOutputModel AddCategory(CategoryInputModel model)
        {
            var category = new Category(model.Name, CurrencyTools.GetCurrency(model.Currency), model.PlannedAmount);
            category = _categoryRepository.Add(category);
            return category.MapToCategoryOutputModel();
        }

        internal IEnumerable<IncomeOutputModel> GetAllIncomes()
        {
            var incomes = _incomeRepository.GetAll();
            var outputModel = incomes.Select(x => x.MapToIncomeOutputModel());
            return outputModel;
        }

        public IEnumerable<CategoryOutputModel> GetAllCategories()
        {
            var categories = _categoryRepository.GetAll();
            var outputModels = categories.Select(x => x.MapToCategoryOutputModel());
            return outputModels;
        }

        public IEnumerable<WalletOutputModel> GetAllWallets()
        {
            var wallets = _walletRepository.GetAll();
            var outputModels = wallets.Select(x => x.MapToWalletOutputModel());
            return outputModels;
        }
    }
}