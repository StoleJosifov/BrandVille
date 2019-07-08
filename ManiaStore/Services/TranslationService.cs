using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Web;

namespace BrandVille.Services
{
    public class TranslationService
    {
        public static string Translate(string text)
        {
            string url = $"http://translate.google.com/translate_a/t?client=j&text={HttpUtility.UrlEncode(text)}&hl=en&sl=bg&tl=sq";

            // Retrieve Translation with HTTP GET call
            string html = null;
            try
            {
                WebClient web = new WebClient();

                // MUST add a known browser user agent or else response encoding doen't return UTF-8 (WTF Google?)
                web.Headers.Add(HttpRequestHeader.UserAgent, "Mozilla/5.0");
                web.Headers.Add(HttpRequestHeader.AcceptCharset, "UTF-8");

                // Make sure we have response encoding to UTF-8
                web.Encoding = Encoding.UTF8;
                html = web.DownloadString(url);
            }
            catch (Exception ex)
            {
                return null;
            }

            // Extract out trans":"...[Extracted]...","from the JSON string
            string result = html.Replace("\"","");

            if (string.IsNullOrEmpty(result))
            {
                return null;
            }

            //return WebUtils.DecodeJsString(result);

            // Result is a JavaScript string so we need to deserialize it properly
            return result;
        }
    }
}
