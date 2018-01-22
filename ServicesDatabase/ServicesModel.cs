using FinancialManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ServicesDatabase
{
    public class ServicesModel: DbContext
    {
        public ServicesModel()
            : base("name=ServicesModel")
        {
        }

        public ServicesModel(string connectionStringName)
            : base("name=" + connectionStringName)
        {
        }

        public virtual DbSet<RecordEntity> Records { get; set; }
        public virtual DbSet<TarifEntity> Tarifs { get; set; }
        public virtual DbSet<PriceEntity> Prices { get; set; }
    }
}
