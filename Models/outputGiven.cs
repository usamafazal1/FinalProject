using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using WebApplication1.DataLayer;
using WebApplication1.Models;

namespace WebApplication1.Models
{
    public class outputGiven
    {
        public double penalty { get; set; }
        public string currencySymbol { get; set; }

        public outputGiven(double penalty, string currencySymbol)
        {
            this.penalty = penalty;
            this.currencySymbol = currencySymbol;
        }
    }
}
