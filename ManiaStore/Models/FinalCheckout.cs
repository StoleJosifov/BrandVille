using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Newtonsoft.Json;

namespace BrandVille.Models
{
    public class Params
    {
        public string Min { get; set; }
        public string Page { get; set; }
        public string Encoded { get; set; }
        public string Lang { get; set; }
        public string Checksum { get; set; }
        public string UrlOk { get; set; }
        public string UrlCancel { get; set; }
    }

    public class Provider
    {
        public string Name { get; set; }
        public bool IsOnlinePayment { get; set; }
        public string RequestMethod { get; set; }
        public string Url { get; set; }
        public Params Params { get; set; }
    }

    public class FinalCheckoutResult
    {
        public Provider Provider { get; set; }
        public bool Success { get; set; }
    }
    [JsonObject(Title = "RootObject")]
    public class FinalCheckout
    {
        public FinalCheckoutResult Result { get; set; }
    }
}
