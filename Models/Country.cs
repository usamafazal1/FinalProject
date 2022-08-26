using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication1.Models
{
    public class Country
    {
        public int CountryID { get; set; }
        public string Name { get; set; }
        public string Currency { get; set; }
        public string currencySymbol { get; set; }
        public double countryExchange { get; set; }
        public double countryTax { get; set; }
        public List<Holidays> Holidays { get; set; }
        public List<Weekend> Weekend { get; set; }

        public Country(int CountryID, string Name, string Currency, string CurrencySymbol, double countryExchange, double countryTax, List<Holidays> Holidays, List<Weekend> Weekends)
        {
            this.CountryID = CountryID;
            this.Name = Name;
            this.Currency = Currency;
            this.currencySymbol = CurrencySymbol;
            this.countryExchange = countryExchange;
            this.countryTax = countryTax;
            this.Holidays = Holidays;
            this.Weekend = Weekends;

        }


    }
}
