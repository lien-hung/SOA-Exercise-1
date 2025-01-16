using CityDB_WS.Entities;
using System.Collections.Generic;
using System.Data.SqlClient;

namespace CityDB_WS.DB
{
    public class CityRepository
    {
        private readonly SqlConnection connection;
        public CityRepository()
        {
            connection = ConnectDB.GetInstance();
        }

        public List<City> GetAllCities()
        {
            List<City> cities = new List<City>();
            // Connect to the database
            connection.Open();
            string sql = "select * from city";
            SqlCommand cmd = new SqlCommand(sql, connection);
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int id = int.Parse(rdr[0].ToString());
                string name = rdr[1].ToString();
                string countryCode = rdr[2].ToString();
                string district = rdr[3].ToString();
                int population = int.Parse(rdr[4].ToString());

                City city = new City(id, name, countryCode, district, population);
                cities.Add(city);
            }
            connection.Close();
            return cities;
        }

        public City GetCityByName(string name)
        {
            connection.Open();
            string sql = "select * from city where Name = @Name";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.Add(new SqlParameter("@Name", name));
            SqlDataReader rdr = cmd.ExecuteReader();
            City queriedCity = null;
            while (rdr.Read())
            {
                int id = int.Parse(rdr[0].ToString());
                string countryCode = rdr[2].ToString();
                string district = rdr[3].ToString();
                int population = int.Parse(rdr[4].ToString());

                queriedCity = new City(id, name, countryCode, district, population);
            }
            connection.Close();
            return queriedCity;
        }

        public List<City> GetCitiesFromCountry(string countryName)
        {
            List<City> cities = new List<City>();
            connection.Open();
            string sql = @"select *
                           from city as ci
                           inner join country as co
                           on ci.CountryCode = co.Code
                           where co.Name = @CountryName";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.Add(new SqlParameter("@CountryName", countryName));
            SqlDataReader rdr = cmd.ExecuteReader();
            while (rdr.Read())
            {
                int id = int.Parse(rdr[0].ToString());
                string name = rdr[1].ToString();
                string countryCode = rdr[2].ToString();
                string district = rdr[3].ToString();
                int population = int.Parse(rdr[4].ToString());

                City city = new City(id, name, countryCode, district, population);
                cities.Add(city);
            }
            connection.Close();
            return cities;
        }
    }
}