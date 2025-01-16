namespace CityDB_WS.Entities
{
    public class City
    {
        public int ID { get; set; }
        public string Name { get; set; }
        public string CountryCode { get; set; }
        public string District { get; set; }
        public int Population { get; set; }

        public City() { }

        public City(int id, string name, string countryCode, string district, int population)
        {
            ID = id;
            Name = name;
            CountryCode = countryCode;
            District = district;
            Population = population;
        }
    }
}