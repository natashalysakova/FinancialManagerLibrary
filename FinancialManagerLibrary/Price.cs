using FinancialManagerLibrary.Enums;
using FinancialManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagerLibrary
{
    public class Price : IEntity<PriceEntity>
    {
        public double LowBorder { get; set; }
        public double HighBorder { get; set; }
        public decimal Amount { get; set; }
        public PriceType Type { get; set; }

        public int Id { get; set; }

        public Price()
        {

        }
        public Price(PriceEntity entity)
        {
            MapFromEntity(entity);
        }

        public void MapFromEntity(PriceEntity entity)
        {
            Id = entity.Id;
            LowBorder = entity.LowBorder;
            HighBorder = entity.HighBorder;
            Amount = entity.Price;
            Type = entity.Type;
        }

        public PriceEntity MapToEntity()
        {
            return new PriceEntity()
            {
                Id = this.Id,
                LowBorder = this.LowBorder,
                HighBorder = this.HighBorder,
                Price = this.Amount,
                Type = this.Type
            };
        }
    }
}
