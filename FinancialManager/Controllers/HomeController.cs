using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography.X509Certificates;
using System.Web.Mvc;
using FinancialManager.Models;
using FinancialManager.Services;
using FinancialManagerDatabase;
using FinancialManagerLibrary;
using FinancialManagerLibrary.Interfaces;
using FinancialManagerLibrary.Utilities;

namespace FinancialManager.Controllers
{
    public class HomeController : Controller
    {
        private readonly BuisnessService _service;

        public HomeController()
        {
            var contextName = "FinancialManagerModel";
            IFinancialDataSource source = new EntityDataSource(contextName);
            _service = new BuisnessService(source);
        }

        public ActionResult Index()
        {
            ViewBag.CurrencyList = CurrencyTools.GetCurrencyList().ConvertSelectListItems();

            MainPageOutputModel model = new MainPageOutputModel
            {
                Categories = _service.GetAllCategories(),
                Wallets =  _service.GetAllWallets(),
                Incomes = _service.GetAllIncomes()
            };

            return View(model);
        }

        [HttpPost]
        public ActionResult AddCategory(CategoryInputModel model)
        {
            if (ModelState.IsValid)
            {
                var newCategory = _service.AddCategory(model);
                return PartialView("_category", newCategory);
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