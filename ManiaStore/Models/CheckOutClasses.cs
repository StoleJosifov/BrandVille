using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BrandVille.Models
{
    public class OrderAddress
    {
        public string AddressId { get; set; }
        public string CityId { get; set; }
        public string PostCode { get; set; }
        public string DistrictId { get; set; }
        public string Street { get; set; }
        public string StreetType { get; set; }
        public string StreetId { get; set; }
        public string StreetNumber { get; set; }
        public string Building { get; set; }
        public string Entrance { get; set; }
        public int IsActive { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string AddressType { get; set; }
        public int OfficeId { get; set; }
        public string CreatedDate { get; set; }
        public string ModificateDate { get; set; }
        public string CityName { get; set; }
        public string Municipality { get; set; }
        public string CityType { get; set; }
    }

    public class CheckOutResult
    {
        public string OrderId { get; set; }
        public string OrderProcessUrl { get; set; }
        public string OrderDeliveryType { get; set; }
        public OrderAddress OrderAddress { get; set; }
        public bool Success { get; set; }
    }

    public class CustomerProductCounts
    {
        public int Observes { get; set; }
        public int Favorites { get; set; }
        public int ShoppingCart { get; set; }
        public int WonAuctions { get; set; }
    }
    [JsonObject(Title = "RootObject")]
    public class OrderCheckout
    {
        public CheckOutResult Result { get; set; }
        public CustomerProductCounts CustomerProductCounts { get; set; }
    }
}
