using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.Extensions.Configuration;
using System.Data.SqlClient;
using WebApplication1.Models;

namespace WebApplication1.DataLayer
{
    public class SQL : iSQL
    {
        public readonly IConfiguration configuration;
        public SQL(IConfiguration config)
        {
            this.configuration = config;
        }

        public string GetConnectionString(IConfiguration configuration)
        {
            string connectionString = configuration.GetConnectionString("DefaultConnectionString");
            return connectionString;         
        }


        //getting information about countries (names, currency, etc.)//
        public List<Country> GetCountries()
        {
            SqlConnection con = new SqlConnection(GetConnectionString(configuration));
            con.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            string sql = "Select * from CountryTable";
            command = new SqlCommand(sql, con);
            dataReader = command.ExecuteReader();
            List<Country> countryList = new List<Country>();
            while (dataReader.Read())
            {
                int ID = Convert.ToInt32(dataReader.GetValue(0));
                string name = dataReader.GetValue(1).ToString();
                string currency = dataReader.GetValue(2).ToString();
                string currencySymbol = dataReader.GetValue(3).ToString();
                double CountryExchange = Convert.ToDouble(dataReader.GetValue(5));
                double CountryTax = Convert.ToDouble(dataReader.GetValue(6));

                List<Holidays> HolidayList = GetHolidays(ID);
                List<Weekend> weekendList = GetWeekends(ID);

                Country country = new Country(ID, name, currency, currencySymbol, CountryExchange, CountryTax, HolidayList, weekendList);
                countryList.Add(country);
            }
            dataReader.Close();
            command.Dispose();
            con.Close();
            return countryList;

        }

        //getting information about holidays//
       public List<Holidays> GetHolidays(int CountryID)
        {
            SqlConnection con = new SqlConnection(GetConnectionString(configuration));
            con.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            string sql = "Select * from Holidays where CountryID=@CountryID";
            command = new SqlCommand(sql, con);
            command.Parameters.AddWithValue("@CountryID",CountryID);
            dataReader = command.ExecuteReader();
            List<Holidays> holidayList = new List<Holidays>();
            while (dataReader.Read())
            {
                DateTime date = Convert.ToDateTime(dataReader.GetValue(2));

                Holidays holiday = new Holidays();
                holiday.Holiday = date;
                holidayList.Add(holiday);
            }
            dataReader.Close();
            command.Dispose();
            con.Close();
            return holidayList;
        }

        //getting information about weekends//
        public List<Weekend> GetWeekends(int CountryID)
        {
            SqlConnection con = new SqlConnection(GetConnectionString(configuration));
            con.Open();
            SqlCommand command;
            SqlDataReader dataReader;
            string sql = "Select * from Weekend where CountryID=@CountryID";
            command = new SqlCommand(sql, con);
            command.Parameters.AddWithValue("@CountryID", CountryID);
            dataReader = command.ExecuteReader();
            List<Weekend> weekendList = new List<Weekend>();
            while (dataReader.Read())
            {
                string weekend = dataReader.GetValue(0).ToString();

                Weekend weekends = new Weekend();
                weekends.WeekendDay = weekend;
                weekendList.Add(weekends);
            }
            dataReader.Close();
            command.Dispose();
            con.Close();
            return weekendList;
        }
    }
}
