﻿using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using FinancialManager.Models;
using FinancialManager.Services;
using FinancialManagerDatabase;
using FinancialManagerLibrary;
using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Utilities;
using FinancialManager.Models.OutputModels;
using FinancialManager.Models.InputModels;
using System;
using FinancialManagerLibrary.Transactions;
using FinancialManager.Models.Extentions;
using FinancialManagerLibrary.Wallets;
using FinancialManagerLibrary.Incomes;

namespace FinancialManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly FinancialService _service;

        public HomeController()
        {
            var contextName = "FinancialManagerModel";
            IFinancialDataSource source = new EntityDataSource(contextName);
            _service = new FinancialService(source);
        }

        public ActionResult Index()
        {
            ViewBag.CurrencyList = CurrencyTools.GetCurrencyList().ConvertSelectListItems();

            MainPageOutputModel model = new MainPageOutputModel
            {
                Categories = _service.GetAllCategories().Select(x => x.MapToCategoryOutputModel()),
                Wallets = _service.GetAllWallets().Select(x => x.MapToWalletOutputModel()),
                Incomes = _service.GetAllIncomes().Select(x => x.MapToIncomeOutputModel()),
                Transactions = _service.GetAllTransactions().Select(x => x.MapToTransactionOutputModel())
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryInputModel model)
        {
            if (ModelState.IsValid)
            {
                var category = new Category(model.Name, CurrencyTools.GetCurrency(model.Currency), model.PlannedAmount);
                category = _service.AddCategory(category);
                var categoryOutputModel = category.MapToCategoryOutputModel();


                return PartialView("_category", categoryOutputModel);
            }

            return new HttpStatusCodeResult(422);
        }

        [HttpPost]
        public ActionResult AddTransaction(TransactionInputModel model)
        {
            if (ModelState.IsValid)
            {
                dynamic from = null;
                switch (model.FromType)
                {
                    case TransactionItemType.Wallet:
                        from = _service.GetWallet(model.FromId);
                        break;
                    case TransactionItemType.Income:
                        from = _service.GetIncome(model.FromId);
                        break;
                }

                dynamic to = null;
                switch (model.ToType)
                {
                    case TransactionItemType.Wallet:
                        to = _service.GetWallet(model.ToId);
                        break;
                    case TransactionItemType.Category:
                        to = _service.GetCategory(model.ToId);
                        break;
                }

                if (from == null)
                    throw new ArgumentException($"Cannot find {model.FromType} with id={model.FromId}");

                if (to == null)
                    throw new ArgumentException($"Cannot find {model.ToType} with id={model.ToId}");

                var transaction = new Transaction(from, to, model.Amount, CurrencyTools.GetCurrency(model.Currency), model.Date, model.Comment);

                var newItem = _service.AddTransaction(transaction).MapToTransactionOutputModel();

                return PartialView("_transaction", newItem);
            }

            return new HttpStatusCodeResult(422);
        }

        [HttpPost]
        public ActionResult AddIncome(IncomeInputModel model)
        {
            if (ModelState.IsValid)
            {
                var income = new Income(model.Name, CurrencyTools.GetCurrency(model.Currency), model.PlannedAmount);
                var newItem = _service.AddIncome(income).MapToIncomeOutputModel(); ;
                return PartialView("_income", newItem);
            }

            return new HttpStatusCodeResult(422);
        }

        [HttpPost]
        public ActionResult AddWallet(WalletInputModel model)
        {
            if (ModelState.IsValid)
            {
                Wallet wallet;

                if (model.IsCreditCard)
                {
                    wallet = new Wallet(model.Name, model.Balance, CurrencyTools.GetCurrency(model.Currency), model.Overdraft);
                }
                else
                {
                    wallet = new Wallet(model.Name, model.Balance, CurrencyTools.GetCurrency(model.Currency));
                }
                var newItem = _service.AddWallet(wallet).MapToWalletOutputModel();


                return PartialView("_wallet", newItem);
            }

            return new HttpStatusCodeResult(422);
        }

    }

    public static class SelectListItemConverter
    {
        public static IEnumerable<SelectListItem> ConvertSelectListItems(this IEnumerable<string> list)
        {
            List<SelectListItem> _items = new List<SelectListItem>();
            foreach (var currency in list)
            {
                _items.Add(new SelectListItem()
                {
                    Value = currency,
                    Text = currency,
                });
            }

            return _items;
        }
    }
}