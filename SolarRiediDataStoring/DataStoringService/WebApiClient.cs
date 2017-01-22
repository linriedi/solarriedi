using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Threading.Tasks;

namespace Linus.SolarRiedi.DataStoringService
{
    public class WebApiClient
    {
        private readonly HttpClient client;

        public WebApiClient()
        {
            this.client = new HttpClient();
            client.BaseAddress = new Uri("http://measurementdataservice.azurewebsites.net/");
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public async Task<IEnumerable<IEnumerable<string>>> GetMeasurements(string date)
        {
            IEnumerable<IEnumerable<string>> product = null;
            HttpResponseMessage response = await client.GetAsync(string.Format("api/day/{0}",date));
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<IEnumerable<IEnumerable<string>>>();
            }

            return product;
        }

        public async Task<IEnumerable<IEnumerable<string>>> GetYearMeasurements()
        {
            IEnumerable<IEnumerable<string>> product = null;
            HttpResponseMessage response = await client.GetAsync("api/year");
            if (response.IsSuccessStatusCode)
            {
                product = await response.Content.ReadAsAsync<IEnumerable<IEnumerable<string>>>();
            }

            return product;
        }
    }
}
