using FinancialManagerLibrary.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagerLibrary
{
    public class Tarif : IEntity<TarifEntity>
    {
        public int Id { get; set; }
        IEnumerable<Price> Prices { get; set; }
        public DateTime Started { get; set; }
        public DateTime Finished { get; set; }

        public Tarif()
        {

        }

        public Tarif( TarifEntity entity)
        {
            MapFromEntity(entity);
        }

        public void MapFromEntity(TarifEntity entity)
        {
            Id = entity.Id;
            Started = entity.Started;
            Finished = entity.Finished;
            Prices = entity.Prices.Select(x => new Price(x));
        }

        public TarifEntity MapToEntity()
        {
            return new TarifEntity()
            {
                Id = this.Id,
                Started = this.Started,
                Finished = this.Finished,
                Prices = this.Prices.Select(x => x.MapToEntity())
            };
        }
    }
}
