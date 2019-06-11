using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Net.Http;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using BrandVille.Areas.Identity.Data;
using BrandVille.Models;
using BrandVille.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace BrandVille.Controllers
{
    public class HomeController : Controller
    {
        public ItemService ItemsService = new ItemService();
        private readonly UserManager<BrandVilleUser> _userManager;
        private readonly BrandVilleContext _dbContext;

        public HomeController(UserManager<BrandVilleUser> userManager, BrandVilleContext dbContext)
        {
            _userManager = userManager;
            _dbContext = dbContext;
        }

        public async Task<IActionResult> Index()
        {
            var items = await ItemsService.GetItems();
            return View(items);
        }

        public async Task<IActionResult> Items(string completeData, string pageNumber = "1")
        {
            var items = await ItemsService.GetItems(completeData,pageNumber);
            return PartialView(items);
        }

        public IActionResult GetCartItems()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = _dbContext.Users.Include(x => x.BasketItems).Single(x => x.Id == userId);
            return PartialView(user.BasketItems);
        }
        public IActionResult ViewCart()
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = _dbContext.Users.Include(x => x.BasketItems).Single(x => x.Id == userId);
            return View(user.BasketItems);
        }

        public async Task<IActionResult> CheckOut()
        {
            var redirectUrl =await ItemsService.CheckOut();
            return Redirect(redirectUrl);
        }

        public IActionResult Privacy()
        {
            return View();
        }

        public async Task<IActionResult> Add(BasketItems product)
        {
            var userId = _userManager.GetUserId(HttpContext.User);
            if(userId==null) return Redirect("/Identity/Account/Register");

            await ItemsService.AddToBasket(product.ProductId);
            var user = _dbContext.Users.Include(x=>x.BasketItems).Single(x => x.Id == userId);
            if (user.BasketItems == null)
            {
                user.BasketItems = new List<BasketItems>()
                {
                    product
                };
            }
            else
            {
                user.BasketItems.Add(product);
            }

            var result =await _userManager.UpdateAsync(user);
            return RedirectToAction("Index");
        }
        public async Task<IActionResult> Remove(string productId)
        {
            await ItemsService.RemoveFromBasket(productId);
            var userId = _userManager.GetUserId(HttpContext.User);
            var user = _dbContext.Users.Include(x => x.BasketItems).Single(x => x.Id == userId);
            if(user.BasketItems == null)
            {
                return RedirectToAction("Index");
            }
            else
            {
                var product = user.BasketItems.FirstOrDefault(x=>x.ProductId==productId);
                user.BasketItems.Remove(product);
                var res = _dbContext.BasketItems.Remove(product);
                var resd = await _dbContext.SaveChangesAsync();
            }
            
            var result = await _userManager.UpdateAsync(user);
            
            return RedirectToAction("Index");
        }

        public async Task<IActionResult> ViewItem(string url)
        {
            var viewModel = await ItemsService.ProductModelView(url);

            return View(viewModel);
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
