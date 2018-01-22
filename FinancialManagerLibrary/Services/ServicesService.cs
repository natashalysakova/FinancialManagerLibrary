using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Models;
using FinancialManagerLibrary.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagerLibrary.Services
{
    public class ServicesService
    {
        private readonly BaseRepository<Price, PriceEntity> _priceRepository;
        private readonly BaseRepository<Tarif, TarifEntity> _tarifRepository;
        private readonly BaseRepository<Record, RecordEntity> _recordRepository;

        public ServicesService(IFinancialDataSource service)
        {
            _priceRepository = new BaseRepository<Price, PriceEntity>(service.PriceService);
            _recordRepository = new BaseRepository<Record, RecordEntity>(service.RecordService);
            _tarifRepository = new BaseRepository<Tarif, TarifEntity>(service.TarifService);

        }
    }
}
