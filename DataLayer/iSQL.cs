using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WebApplication1.Models;


namespace WebApplication1.DataLayer
{
    public interface iSQL
    {
        public string GetConnectionString(IConfiguration configuration);
        public List<Country> GetCountries();
        List<Holidays> GetHolidays(int countryID);
        public List<Weekend> GetWeekends(int CountryID);
    }
}
