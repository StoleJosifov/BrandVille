using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using Newtonsoft.Json;

namespace BrandVille.Models
{
    public class RootObject
    {
        public Result Result { get; set; }
    }
    public class Result
    {
        public List<Product> Products { get; set; }
    }

    public class BasketItems
    {
        [Key]
        public string ProductId { get; set; }
        public string Brand { get; set; }
        public string Size { get; set; }
        public string ImageUrl { get; set; }
        public string Price { get; set; }

    }
    public class Product
    {
        public BasketItems CartProduct => new BasketItems()
        {
            ProductId = this.ProductId,
            Brand = this.Brand,
            Size = this.Size,
            ImageUrl = this.Pictures.Front.Src,
            Price = this.CurrentPrice.FullInLekRounded
        };
        public string ProductId { get; set; }
        public string Brand { get; set; }
        public string Type { get; set; }
        public string Size { get; set; }
        public string Rating { get; set; }
        public string ManiaSize { get; set; }
        public string SizeLabel { get; set; }
        public bool WithLabel { get; set; }
        public string Category { get; set; }
        public string Status { get; set; }
        public string ForAuction { get; set; }
        public Pictures Pictures { get; set; }
        public string Url { get; set; }
        public Price CurrentPrice => Prices.Where(x => x.IsLastPrice).FirstOrDefault();
        public Price StartingPrice => Prices.FirstOrDefault();
        public List<Price> Prices { get; set; }
        [JsonProperty(PropertyName = "price")]
        public PriceRange PriceRange { get; set; }
        public bool IsMultiplePrice { get; set; }
        public string FavouriteCounter { get; set; }
        public int ReservedUserId { get; set; }
    }
    public class Picture
    {
        [Key]
        public int Id { get; set; }
        public string Src { get; set; }
    }
    
    public class Pictures
    {
        [Key]
        public int Id { get; set; }
        public Picture Front { get; set; }
        public Picture Back { get; set; }
    }
    
    public class Price
    {
        [Key]
        public int Id { get; set; }
        public string Title { get; set; }
        [JsonProperty(PropertyName = "price")]
        public string CurrentPrice { get; set; }
        public string Currency { get; set; }
        public bool IsLastPrice { get; set; }
        public string FullInLek => (Convert.ToDouble(CurrentPrice) * 64 * 1.5).ToString().Split(".")[0];
        public string FullInLekRounded => FullInLek.Remove(FullInLek.Length - 1) + "0" + " Lekë";
    }
    
    public class DetailedPrice
    {
        [Key]
        public int Id { get; set; }
        public string Full { get; set; }
        public string FullInLek => (Convert.ToDouble(Full) * 64 * 1.5).ToString();
        public string FullInLekRounded => FullInLek.Remove(FullInLek.Length - 1) + "0" + " Lekë";
        public string Bill { get; set; }
        public string Coins { get; set; }
        public string Currency { get; set; }
        public string FullString { get; set; }
    }

    public class PriceRange
    {
        [Key]
        public int Id { get; set; }
        [JsonProperty(PropertyName = "price")]
        public DetailedPrice CurrentPrice { get; set; }
        public DetailedPrice SellMax { get; set; }
        public DetailedPrice SellMin { get; set; }
    }
}
