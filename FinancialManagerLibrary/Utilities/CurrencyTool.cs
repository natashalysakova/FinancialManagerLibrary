using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace FinancialManagerLibrary.Utilities
{
    public static class CurrencyTools
    {
        private static readonly IDictionary<string, string> Map;
        private static readonly IEnumerable<string> Currency;
        static Dictionary<Currency, double> ConvertationList;


        static CurrencyTools()
        {
            Map = CultureInfo
                .GetCultures(CultureTypes.AllCultures)
                .Where(c => !c.IsNeutralCulture)
                .Select(culture =>
                {
                    try
                    {
                        return new RegionInfo(culture.LCID);
                    }
                    catch
                    {
                        return null;
                    }
                })
                .Where(ri => ri != null)
                .GroupBy(ri => ri.ISOCurrencySymbol)
                .ToDictionary(x => x.Key, x => x.First().CurrencySymbol);

            Currency = Enum.GetNames(typeof(Currency));

            //TODO: do something with this shit
            ConvertationList = new Dictionary<Currency, double>();
            ConvertationList.Add(FinancialManagerLibrary.Currency.USD, 1);
            ConvertationList.Add(FinancialManagerLibrary.Currency.UAH, 25.90);
            ConvertationList.Add(FinancialManagerLibrary.Currency.EUR, 1.19);
        }

        public static string GetCurrencySymbol(Currency currency)
        {
            string isoCurrencySymbol = currency.ToString();
            string symbol;
            if (Map.TryGetValue(isoCurrencySymbol, out symbol))
            {
                return symbol;
            }

            return isoCurrencySymbol;
        }

        public static Currency GetCurrency(string symbol)
        {
            Currency currency;
            foreach (KeyValuePair<string, string> keyValuePair in Map)
            {
                if (keyValuePair.Value == symbol || keyValuePair.Key == symbol)
                {
                    if (Enum.TryParse(keyValuePair.Key, out currency))
                    {
                        return currency;
                    }
                }
            }

            throw new InvalidOperationException($"Cannot found currency with symbol or code = '{symbol}'");
        }


        internal static double Convert(double amount, Currency from, Currency to)
        {
            var dollarExchange = ConvertationList[from];
            double inUSD = amount * dollarExchange;
            var toTargetCurrency = ConvertationList[to];
            double inTarget = inUSD * toTargetCurrency;

            return inTarget;
        }

        public static IEnumerable<string> GetCurrencyList()
        {
            return Currency;
        }
    }
}
