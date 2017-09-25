using System.Data.Entity;
using FinancialManagerLibrary.Models;

namespace FinancialManagerDatabase
{
    public class FinancialManagerModel : DbContext
    {
        // Your context has been configured to use a 'FinancialManagerModel' connection string from your application's 
        // configuration file (App.config or Web.config). By default, this connection string targets the 
        // 'FinancialManager.Models.FinancialManagerModel' database on your LocalDb instance. 
        // 
        // If you wish to target a different database and/or database provider, modify the 'FinancialManagerModel' 
        // connection string in the application configuration file.
        public FinancialManagerModel()
            : base("name=FinancialManagerModel")
        {
        }

        public FinancialManagerModel(string connectionStringName)
            : base("name=" + connectionStringName)
        {
        }

        // Add a DbSet for each entity type that you want to include in your model. For more information 
        // on configuring and using a Code First model, see http://go.microsoft.com/fwlink/?LinkId=390109.

        // public virtual DbSet<MyEntity> MyEntities { get; set; }

        //public virtual DbSet<UserEntity> Users { get; set; }
        //public virtual DbSet<WalletEntity> Wallets { get; set; }
        //public virtual DbSet<IncomeEntity> Incomes { get; set; }
        public virtual DbSet<CategoryEntity> Categories { get; set; }
        public virtual DbSet<WalletEntity> Wallets { get; set; }
        public virtual DbSet<TransactionEntity> Transactions { get; set; }
        public virtual DbSet<IncomeEntity> Incomes { get; set; }

    }
}