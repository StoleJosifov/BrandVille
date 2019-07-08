using System.Collections.Generic;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BrandVille.Models;
using Newtonsoft.Json;

namespace BrandVille.Services
{
    public class ItemService
    {
        private const string Cookie =
            "MAN=6dnh4nn2itbsvhrpn51eoonoeh; _ga=GA1.2.532640793.1559035257; _gid=GA1.2.328681249.1559035257; _ym_uid=1559035257651588532; _ym_d=1559035257; _fbp=fb.1.1559035257358.130701804; _ym_isad=2; modal_shown=yes; _ym_visorc_48635135=w; _gat_UA-50066373-1=1";

        public async Task<Result> GetItems(string data = null, string pageNumber = "1" )
        {
            using (var httpClient = new HttpClient())
            {
                var keyValuePairs = new List<KeyValuePair<string, string>>
                {
                    new KeyValuePair<string, string>("sorts[page]", pageNumber.ToString()),
                    new KeyValuePair<string, string>("sorts[orderBy]", "1")
                };
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

                var response = await httpClient.PostAsync("https://mania.bg/razprodajba-drehi-vtora-ruka-online/products", formContent);
                var content = await response.Content.ReadAsStringAsync();
                try
                {
                    var result = JsonConvert.DeserializeObject<RootObject>(content);
                    return result.Result;
                }
                catch
                {
                    return new Result();
                }
            }
        }

        public async Task AddToBasket(string productId)
        {
            using(var httpClient = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("productId", productId)
                });
                formContent.Headers.Add("Cookie", Cookie);

                var response = await httpClient.PostAsync("https://maniastores.bg/shopping/sellout/add", formContent);
            }
        }

        public async Task RemoveFromBasket(string productId)
        {
            using(var httpClient = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("removeProductId", productId)
                });
                formContent.Headers.Add("Cookie", Cookie);

                var response = await httpClient.PostAsync("https://maniastores.bg/shopping/product/list", formContent);
            }
        }


        public async Task<ProductModelView> ProductModelView(string url)
        {
            var viewModel = new ProductModelView();
            using(var httpClient = new HttpClient())
            {
                var fullUrl = "https://maniastores.bg/razprodajba-drehi-vtora-ruka-online/pregled/" + url;
                var response = await httpClient.GetAsync(fullUrl);
                var content = await response.Content.ReadAsStringAsync();
                var dataString = Regex.Match(content, @"<div class=""product-details-container.*<div class=""products-wrapper")
                    .ToString();
                viewModel.Name = url.Split("-p")[0];
                viewModel.ProductId = url.Split("-p")[1];
                var imageUrlsMatches = Regex.Matches(dataString, "data-image=\"(.*?)\"");
                viewModel.FrontPictureSrc = imageUrlsMatches[0].Groups[1].ToString() ?? "";
                viewModel.BackPictureSrc = imageUrlsMatches[1].Groups[1].ToString() ?? "";
                viewModel.Type = Regex.Match(dataString, "product-type\">(.*?)</p>").Groups[1].ToString() ?? "";
                viewModel.Brand = Regex.Match(dataString, "product-brand text-uppercase\">(.*?)</p>").Groups[1].ToString() ?? "";
                viewModel.Status = Regex.Match(dataString, "product-details-container clearfix (.*?)\"").Groups[1].ToString() ??
                                   "";
                viewModel.Size = Regex.Match(dataString, "Размер: <strong>(.*?)</strong>").Groups[1].ToString() ?? "";
                viewModel.CurrentPrice = Regex.Match(dataString, "class=\"price\">(.*?)</div").Groups[1].ToString() ?? "";
                viewModel.StartingPrice = Regex.Match(dataString, "class=\"price old\">(.*?)</div").Groups[1].ToString() ?? "";
                viewModel.Gender = Regex.Match(dataString, "Пол: </span>(.*?)</p").Groups[1].ToString() ?? "";
                viewModel.Color = Regex.Match(dataString, "Цвят: </span>(.*?)</p").Groups[1].ToString() ?? "";
                viewModel.Season = Regex.Match(dataString, "Сезон: </span>(.*?)</p").Groups[1].ToString() ?? "";
                viewModel.Material = Regex.Match(dataString, "Състав: </span>(.*?)</p").Groups[1].ToString() ?? "";
                viewModel.Description = Regex.Match(dataString, "Описание: </span>(.*?)</p").Groups[1].ToString() ?? "";
                var condition = Regex.Match(dataString, "Състояние: <img src=\"(.*?)\"").Groups[1].ToString();
                viewModel.Condition = condition != null
                    ? condition.Contains("five")
                        ? "Mrekullueshme"
                        : "Mirë"
                    : "";
                viewModel.DiscountLimit =
                    Regex.Match(dataString, "остъпка от <span class=\"description-label\">(.*?)</span> Повече информация")
                        .Groups[1].ToString() ?? "";
                viewModel.Discount =
                    Regex.Match(dataString, "class=\"sellout-discount\" > (.*?) </div>").Groups[1].ToString() ?? "";
                viewModel.CurrentPriceInLek = viewModel.RoundInLek(viewModel.CurrentPrice.Split(" ")[0]);
                var k = viewModel.StartingPrice.Split(" ")[0];
                viewModel.StartingPriceInLek = viewModel.RoundInLek(viewModel.StartingPrice.Split(" ")[0]);

                var translationStrings = viewModel.Gender + " ? " + viewModel.Description + " ? " + viewModel.Color + " ? " + viewModel.Season + " ? " + viewModel.Material + " ? " + viewModel.Type;

                translationStrings = TranslationService.Translate(translationStrings);

                var values = translationStrings.Split("?");
                viewModel.Gender = values[0];
                viewModel.Description = values[1];
                viewModel.Color = values[2];
                viewModel.Season = values[3];
                viewModel.Material = values[4];
                viewModel.Type = values[5];
            }

            return viewModel;
        }

        public async Task<string> CheckOut()
        {
            using(var httpClient = new HttpClient())
            {
                var formContentFirst = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("deliveryType", "3"),
                    new KeyValuePair<string, string>("address-3", "57652"),
                    new KeyValuePair<string, string>("payment", "epayCard"),
                    new KeyValuePair<string, string>("step", "2"),
                    new KeyValuePair<string, string>("address", "57652"),
                    new KeyValuePair<string, string>("invoice", "0")
                });
                formContentFirst.Headers.Add("Cookie", Cookie);

                var response = await httpClient.PostAsync("https://maniastores.bg/shopping/step/save", formContentFirst);
                var content = await response.Content.ReadAsStringAsync();

                var formContentSecond = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("step", "3"),
                    new KeyValuePair<string, string>("pickUpDelay", "0"),
                    new KeyValuePair<string, string>("commonTerms", "1")
                });
                formContentSecond.Headers.Add("Cookie", Cookie);

                var responseSecond = await httpClient.PostAsync("https://maniastores.bg/shopping/step/save", formContentSecond);
                var contentSecond = await responseSecond.Content.ReadAsStringAsync();
                var result = JsonConvert.DeserializeObject<OrderCheckout>(contentSecond);


                var responseThird = await httpClient.PostAsync(result.Result.OrderProcessUrl, formContentSecond);
                var contentThird = await responseThird.Content.ReadAsStringAsync();
                var finalCheckout = JsonConvert.DeserializeObject<FinalCheckout>(contentThird);

                return finalCheckout.Result.Provider.Url;
            }
        }
    }
}
