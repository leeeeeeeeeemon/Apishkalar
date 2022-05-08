using TestApiApp.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Net.Http;
using System.Text.Json;
using System.Threading.Tasks;

namespace TestApiApp.Services
{
    public class RestService : IRestService
    {
        HttpClient client;
        RootModel rootModel { get; set; }
        public RestService()
        {
            client = new HttpClient();

        }
        public async Task<List<EntryModel>> GetDataAsync()
        {

            Uri uri = new Uri(string.Format(Constants.RestUrl, string.Empty));
            try
            {
                HttpResponseMessage responseMessage = await client.GetAsync(uri);

                if (responseMessage.IsSuccessStatusCode)
                {
                    string content = await responseMessage.Content.ReadAsStringAsync();
                    rootModel = JsonSerializer.Deserialize<RootModel>(content);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex.Message);
            }

            return rootModel.entries;
        }
    }
}