using FinancialManagerLibrary.Incomes;
using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Wallets;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagerLibrary.Strategies
{
    interface ITransactionStrategy<S,T>
    {
        IRepository<S> Source { get; }
        IRepository<T> Target { get; }

        void UpdateSource();
        void UpdateTarget();

        void Execute(ITransactionItem transaction);
    }



    class IncomeToWalletStrategy : ITransactionStrategy<Income, Wallet>
    {
        public IRepository<Income> Source
        {
            get;
        }

        public IRepository<Wallet> Target
        {
            get;
        }

        public IncomeToWalletStrategy(IRepository<Income> income, IRepository<Wallet> wallet)
        {
            Source = income;
            Target = wallet;
        }

        public void Execute(ITransactionItem transaction)
        {
            throw new NotImplementedException();
        }

        public void UpdateSource()
        {
            throw new NotImplementedException();
        }

        public void UpdateTarget()
        {
            throw new NotImplementedException();
        }
    }
}
