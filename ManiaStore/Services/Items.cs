using ManiaStore.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using System.Web;

namespace ManiaStore.Services
{
    public class Items
    {
        public async Task<List<Product>> GetItems(int pageNumber, string data = null)
        {
            using (var httpClient = new HttpClient())
            {
                var keyValuePairs = new List<KeyValuePair<string, string>>();
                keyValuePairs.Add(new KeyValuePair<string, string>("sorts[page]", pageNumber.ToString()));
                if (data != null)
                {
                    foreach (var item in data.Split(">"))
                    {
                        var one = item.Split("=")[0];
                        var two = item.Split("=")[1];
                        keyValuePairs.Add(new KeyValuePair<string, string>(one, two));
                    }
                }
                var formContent = new FormUrlEncodedContent(keyValuePairs);
              

                var response = await httpClient.PostAsync("https://maniastores.bg/razprodajba-drehi-vtora-ruka-online/products", formContent);
                var content = await response.Content.ReadAsStringAsync();
                try
                {
                    var result = JsonConvert.DeserializeObject<RootObject>(content);
                    return result.Result.Products;
                }
                catch 
                {
                    return new List<Product>();
                }
            }
        }
    }
}
