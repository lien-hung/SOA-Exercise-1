using CityDB_WS.Entities;
using System.Data.SqlClient;

namespace CityDB_WS.DB
{
    public class CountryRepository
    {
        private readonly SqlConnection connection;
        public CountryRepository()
        {
            connection = ConnectDB.GetInstance();
        }

        public Country GetCountryByCode(string code)
        {
            connection.Open();
            // A parameterized SQL query
            string sql = "select * from country where Code = @Code";
            SqlCommand cmd = new SqlCommand(sql, connection);
            cmd.Parameters.Add(new SqlParameter("@Code", code));
            SqlDataReader rdr = cmd.ExecuteReader();
            Country queriedCountry = null;
            while (rdr.Read())
            {
                string name = rdr[1].ToString();
                string continent = rdr[2].ToString();
                string region = rdr[3].ToString();
                float surfaceArea = float.Parse(rdr[4].ToString());
                int indepYear = rdr[5] as int? ?? default; // Nullable column
                int population = int.Parse(rdr[6].ToString());
                float lifeExpectancy = rdr[7] as float? ?? default; // Nullable column
                float gNP = rdr[8] as float? ?? default; // Nullable column
                float gNPOld = rdr[9] as float? ?? default; // Nullable column
                string localName = rdr[10].ToString();
                string governmentForm = rdr[11].ToString();
                string headOfState = rdr[12].ToString(); // Nullable column
                int capital = rdr[13] as int? ?? default; // Nullable column
                string code2 = rdr[14].ToString();

                queriedCountry = new Country(code, name, continent, region, surfaceArea, indepYear, population, lifeExpectancy, gNP, gNPOld, localName, governmentForm, headOfState, capital, code2);
            }
            connection.Close();
            return queriedCountry;
        }
    }
}