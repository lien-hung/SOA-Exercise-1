namespace CityDB_WS.Entities
{
    public class Country
    {
        public string Code { get; set; }
        public string Name { get; set; }
        public string Continent { get; set; }
        public string Region { get; set; }
        public float SurfaceArea { get; set; }
        public int IndepYear { get; set; }
        public int Population { get; set; }
        public float LifeExpectancy { get; set; }
        public float GNP { get; set; }
        public float GNPOld { get; set; }
        public string LocalName { get; set; }
        public string GovernmentForm { get; set; }
        public string HeadOfState { get; set; }
        public int Capital { get; set; }
        public string Code2 { get; set; }

        public Country() { }

        public Country(string code, string name, string continent, string region, float surfaceArea, int indepYear, int population, float lifeExpectancy, float gNP, float gNPOld, string localName, string governmentForm, string headOfState, int capital, string code2)
        {
            Code = code;
            Name = name;
            Continent = continent;
            Region = region;
            SurfaceArea = surfaceArea;
            IndepYear = indepYear;
            Population = population;
            LifeExpectancy = lifeExpectancy;
            GNP = gNP;
            GNPOld = gNPOld;
            LocalName = localName;
            GovernmentForm = governmentForm;
            HeadOfState = headOfState;
            Capital = capital;
            Code2 = code2;
        }
    }
}