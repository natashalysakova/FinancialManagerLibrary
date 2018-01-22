using FinancialManagerLibrary.Enums;
using FinancialManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagerLibrary
{
    public class Record : IEntity<RecordEntity>
    {
        public int Id { get; set; }
        public RecordType Type { get; set; }

        public int Month { get; set; }
        public int Year { get; set; }
        public DateTime PayDate { get; set; }

        public Tarif Tarif { get; set; }

        public double Value { get; set; }
        public decimal Amount { get; set; }

        public Record()
        {

        }

        public void MapFromEntity(RecordEntity entity)
        {
            Id = entity.Id;
            Type = entity.Type;
            Month = entity.Month;
            Year = entity.Year;
            PayDate = entity.PayDate;
            Tarif = new Tarif(entity.Tarif);
            Value = entity.Value;
            Amount = entity.Amount;
        }

        public RecordEntity MapToEntity()
        {
            return new RecordEntity()
            {
                Id = this.Id,
                Type = this.Type,
                Month = this.Month,
                Year = this.Year,
                PayDate = this.PayDate,
                Tarif = this.Tarif.MapToEntity(),
                Value = this.Value,
                Amount = this.Amount,
            };
        }
    }
}
