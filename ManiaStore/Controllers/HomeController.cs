using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using BrandVille.Areas.Identity.Data;
using Microsoft.AspNetCore.Mvc;
using ManiaStore.Models;
using ManiaStore.Services;
using Microsoft.AspNetCore.Identity;

namespace ManiaStore.Controllers
{
    public class HomeController : Controller
    {
        public Items ItemsService = new Items();
        private readonly UserManager<BrandVilleUser> _userManager;

        public HomeController(UserManager<BrandVilleUser> userManager)
        {
            _userManager = userManager;
        }

        public async Task<IActionResult> Index()
        {
            var user =await _userManager.GetUserAsync(this.User);
            var items = await ItemsService.GetItems(1);
            return View(items);
        }

        public async Task<IActionResult> Items(string CompleteData)
        {
            var items = await ItemsService.GetItems(2, CompleteData);
            return PartialView(items);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Add(string productId)
        {
            await AddToBasket(productId);

            return RedirectToAction("Index");
        }

        private static async Task AddToBasket(string productId)
        {
            using (var httpClient = new HttpClient())
            {
                var formContent = new FormUrlEncodedContent(new[]
                {
                    new KeyValuePair<string, string>("productId", productId)
                });
                formContent.Headers.Add("Cookie",
                    "MAN=tdqb7qtst207f1vlar2ldriaam; _fbp=fb.1.1553620306172.1890827268; _ga=GA1.2.4774605.1553620306; _gid=GA1.2.835322073.1553620306; _ym_uid=1553620306622688231; _ym_d=1553620306; _ym_isad=2; acceptedCookie=true; _ym_visorc_48635135=w");

                var response = await httpClient.PostAsync("https://maniastores.bg/shopping/sellout/add", formContent);
            }
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
