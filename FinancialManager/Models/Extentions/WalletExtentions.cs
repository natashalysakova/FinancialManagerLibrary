using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FinancialManagerLibrary.Utilities;
using FinancialManagerLibrary.Wallets;
using FinancialManager.Models.OutputModels;

namespace FinancialManager.Models.Extentions
{
    public static class WalletExtentions
    {
        public static WalletOutputModel MapToWalletOutputModel(this Wallet wallet)
        {
            var model = new WalletOutputModel()
            {
                Name = wallet.Name,
                Id = wallet.Id,
                Balance = wallet.Balance,
                Overdraft = wallet.Overdraft,
                IsCreditCard = wallet.IsCreditCard,
                Currency = CurrencyTools.GetCurrencySymbol(wallet.Currency),
            };

            return model;
        }
    }
}