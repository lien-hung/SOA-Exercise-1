using System.Net;
using System.Xml;

namespace CityDB_Client
{
    public partial class CityForm : Form
    {
        private void ToggleFieldsByChoice()
        {
            switch (cboChoices.SelectedIndex)
            {
                case 0:
                    txtName.Enabled = txtCountryCode.Enabled = false;
                    break;
                case 1:
                    txtName.Enabled = false; txtCountryCode.Enabled = true;
                    break;
                case 2:
                case 3:
                    txtName.Enabled = true; txtCountryCode.Enabled = false;
                    break;
            }
        }

        // DEPRECATED
        public static HttpWebRequest CreateSOAPWebRequest(string operation)
        {
            HttpWebRequest req = (HttpWebRequest)WebRequest.Create(@"https://localhost:44332/API/CityWS.asmx");
            req.Headers.Add($@"SOAPAction: ""http://tempuri.org/{operation}""");
            req.ContentType = "text/xml; charset=utf-8";
            req.Accept = "text/xml";
            req.Method = "POST";
            return req;
        }

        public static XmlDocument InvokeService(string operation, string name = "", string value = "")
        {
            // Calling CreateSOAPWebRequest method
            HttpWebRequest request = CreateSOAPWebRequest(operation);
            XmlDocument requestBody = new();
            // SOAP request body
            requestBody.LoadXml($@"<?xml version=""1.0"" encoding=""utf-8""?>
                <soap:Envelope xmlns:xsi=""http://www.w3.org/2001/XMLSchema-instance"" xmlns:xsd=""http://www.w3.org/2001/XMLSchema"" xmlns:soap=""http://schemas.xmlsoap.org/soap/envelope/"">
                    <soap:Body>
                    {((name, value) == ("", "")
                    ? $@"<{operation} xmlns=""http://tempuri.org/"" />"
                    : $@"<{operation} xmlns=""http://tempuri.org/"">
                            <{name}>{value}</{name}>
                        </{operation}>")}
                    </soap:Body>
                </soap:Envelope>");
            using Stream stream = request.GetRequestStream();
            requestBody.Save(stream);
            // Getting response from request
            XmlDocument responseBody = new();
            using (WebResponse response = request.GetResponse())
            {
                using StreamReader rd = new(response.GetResponseStream());
                // Reading stream
                var result = rd.ReadToEnd();
                responseBody.LoadXml(result);
            }
            return responseBody;
        }

        private static object[] InvokeGetAllCities()
        {
            XmlDocument response = InvokeService("GetAllCities");
            XmlNodeList cityNodes = response.GetElementsByTagName("City");
            List<object> cityRows = [];
            foreach (XmlNode city in cityNodes)
            {
                List<string> cityRow = [];
                foreach (XmlNode child in city)
                {
                    cityRow.Add(child.InnerText);
                }
                cityRows.Add(cityRow);
            }
            return [.. cityRows];
        }

        private static string[] InvokeGetCountryByCode(string code)
        {
            XmlDocument response = InvokeService("GetCountryByCode", "code", code);
            XmlNodeList countryNode = response.GetElementsByTagName("GetCountryByCodeResult");
            List<string> countryData = [];
            if (countryNode.Count == 1)
            {
                foreach (XmlNode child in countryNode[0]!)
                {
                    countryData.Add(child.InnerText);
                }
            }
            return [.. countryData];
        }

        private static string[] InvokeGetCityByName(string name)
        {
            XmlDocument response = InvokeService("GetCityByName", "name", name);
            XmlNodeList cityNode = response.GetElementsByTagName("GetCityByNameResult");
            List<string> cityData = [];
            if (cityNode.Count == 1)
            {
                foreach (XmlNode child in cityNode[0]!)
                {
                    cityData.Add(child.InnerText);
                }
            }
            return [.. cityData];
        }

        private static object[] InvokeGetCitiesFromCountry(string countryName)
        {
            XmlDocument response = InvokeService("GetCitiesFromCountry", "countryName", countryName);
            XmlNodeList cityNodes = response.GetElementsByTagName("City");
            List<object> cityRows = [];
            foreach (XmlNode city in cityNodes)
            {
                List<string> cityRow = [];
                foreach (XmlNode child in city)
                {
                    cityRow.Add(child.InnerText);
                }
                cityRows.Add(cityRow);
            }
            return [.. cityRows];
        }

        public CityForm()
        {
            InitializeComponent();
        }

        private void CityForm_Load(object sender, EventArgs e)
        {
            cboChoices.Items.AddRange([
                "Get all cities",
                "Get country by code",
                "Get city by name",
                "Get cities from a country"
            ]);
            cboChoices.SelectedIndex = 0;
            ToggleFieldsByChoice();

            dgvCities.ColumnCount = 5;
            dgvCities.Columns[0].Name = "ID";
            dgvCities.Columns[1].Name = "Name";
            dgvCities.Columns[2].Name = "Country Code";
            dgvCities.Columns[3].Name = "District";
            dgvCities.Columns[4].Name = "Population";
        }

        private void cboChoices_SelectedIndexChanged(object sender, EventArgs e)
        {
            ToggleFieldsByChoice();
        }

        private void btnFetch_Click(object sender, EventArgs e)
        {
            dgvCities.Rows.Clear();
            switch (cboChoices.SelectedIndex)
            {
                case 0: // Get all cities
                    object[] cities = InvokeGetAllCities();
                    foreach (List<string> c in cities.Cast<List<string>>())
                    {
                        dgvCities.Rows.Add([.. c]);
                    }
                    break;
                case 1: // Get country by code
                    object country = InvokeGetCountryByCode(txtCountryCode.Text);
                    if (country is not string[] ctryData || ctryData.Length == 0)
                    {
                        MessageBox.Show("Country not found.");
                        return;
                    }
                    MessageBox.Show($@"Found country:
                        - Code: {ctryData[0]}
                        - Name: {ctryData[1]}
                        - Continent: {ctryData[2]}
                        - Region: {ctryData[3]}
                        - Surface Area: {ctryData[4]}
                        - Independence Year: {ctryData[5]}
                        - Population: {ctryData[6]}
                        - Life Expectancy: {ctryData[7]}
                        - GNP: {ctryData[8]}
                        - GNP Old: {ctryData[9]}
                        - Local Name: {ctryData[10]}
                        - Government Form: {ctryData[11]}
                        - Head Of State: {ctryData[12]}
                        - Capital ID: {ctryData[13]}
                        - Code2: {ctryData[14]}");
                    break;
                case 2: // Get city by name
                    object city = InvokeGetCityByName(txtName.Text);
                    if (city is not string[] cityData || cityData.Length == 0)
                    {
                        MessageBox.Show("City not found.");
                        return;
                    }
                    MessageBox.Show($@"Found city:
                        - ID: {cityData[0]}
                        - Name: {cityData[1]}
                        - Country Code: {cityData[2]}
                        - District: {cityData[3]}
                        - Population: {cityData[4]}");
                    break;
                case 3: // Get cities from a country
                    object[] citiesFromCountry = InvokeGetCitiesFromCountry(txtName.Text);
                    if (citiesFromCountry.Length == 0)
                    {
                        MessageBox.Show("No cities found.");
                        return;
                    }
                    foreach (List<string> c in citiesFromCountry.Cast<List<string>>())
                    {
                        dgvCities.Rows.Add([.. c]);
                    }
                    break;
            }
        }
    }
}
