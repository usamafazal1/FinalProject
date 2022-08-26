using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataLayer;
using WebApplication1.Models;

namespace WebApplication1.BusinessLayer
{
    public interface iPenCalculator
    {
        public int GetBusinessDays(Country Country, input input);
        public double CalculatePenalty(Country country, input input);
        public outputGiven ShowPenalty(Country country,input input);
        public List<Country> ShowCountries();
    }
}
