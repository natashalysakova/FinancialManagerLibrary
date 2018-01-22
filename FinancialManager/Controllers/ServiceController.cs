using FinancialManager.Services;
using FinancialManagerDatabase;
using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace FinancialManager.Controllers
{
    public class ServiceController : Controller
    {
        private readonly ServicesService _service;

        public ServiceController()
        {
            var contextName = "FinancialManagerModel";
            IFinancialDataSource source = new EntityDataSource(contextName);
            _service = new ServicesService(source);
        }
        // GET: Service
        public ActionResult Index()
        {
            return View();
        }
    }
}