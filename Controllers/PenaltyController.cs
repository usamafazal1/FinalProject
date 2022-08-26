using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using WebApplication1.DataLayer;
using WebApplication1.Models;
using WebApplication1.BusinessLayer;


namespace WebApplication1.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class PenaltyController : ControllerBase
    {
        public readonly iPenCalculator penaltyCalculator;

        public PenaltyController(iPenCalculator _penaltyCalculator)
        {
            this.penaltyCalculator = _penaltyCalculator;
        }

        [Route("GetCountry")]
        [HttpGet]
        public List<Country> Get()
        {
            List<Country> countryList = this.penaltyCalculator.ShowCountries(); /*ShowCountries() exists in the PenCalculator in business layer*/
            return countryList;
        }

        [Route("GetPenalty")]
        [HttpPost]
        public outputGiven Post([FromBody] input input)
        {
            List<Country> countryList = this.penaltyCalculator.ShowCountries(); /*ShowCountries() exists in the PenCalculator in business layer*/
            Country country = new Country(0, "", "", "", 0, 00, null, null);
            for(int i=0;i<countryList.Count;i++)
            {
                if(input.id==countryList[i].CountryID)
                {
                    country = countryList[i];
                }
            }
            outputGiven output = this.penaltyCalculator.ShowPenalty(country,input);
            return output;
        }


    }
}
