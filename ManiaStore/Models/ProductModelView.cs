using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Runtime.InteropServices.WindowsRuntime;
using System.Threading.Tasks;

namespace BrandVille.Models
{
    public class ProductModelView
    {
        [Key]
        public string ProductId { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public string StartingPrice { get; set; }
        public string CurrentPrice { get; set; }
        public string StartingPriceInLek { get; set; }
        public string CurrentPriceInLek { get; set; }
        public string Condition { get; set; }
        public string Url { get; set; }
        public string Name { get; set; }
        public string Discount { get; set; }
        public string Status { get; set; }
        public string FrontPictureSrc { get; set; }
        public string BackPictureSrc { get; set; }
        public string Gender { get; set; }
        public string Color { get; set; }
        public string Season { get; set; }
        public string Material { get; set; }
        public string Description { get; set; }
        public string DiscountLimit { get; set; }

        public string RoundInLek(string priceInLeva)
        {
            if (priceInLeva == "") return priceInLeva;
            var priceInLek = (Convert.ToDouble(priceInLeva) * 64 * 1.5).ToString().Split(".")[0];
            var fullInLekRounded = priceInLek.Remove(priceInLek.Length - 1) + "0" + " Lekë";
            return fullInLekRounded;
        }
    }
}
