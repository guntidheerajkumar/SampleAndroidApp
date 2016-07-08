using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace SampleAndroidApp.PCL
{
    public class CountriesViewModel
    {
        const string url = "http://country.io/names.json";

        public async Task<Dictionary<string, string>> GetCountriesData()
        {
            try
            {
                var httpClient = new HttpClient();
                var countries = await httpClient.GetStringAsync(url);
                var countriesList = JsonConvert.DeserializeObject<Dictionary<string,string>>(countries);
                return countriesList;
            }
            catch 
            {
                return new Dictionary<string, string>();
            }
        }
    }
}
