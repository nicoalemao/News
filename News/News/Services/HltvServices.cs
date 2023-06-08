using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Security;
using System.Text;
using System.Threading.Tasks;
using News.Models;
using Xamarin.Essentials;

namespace News.Services
{
    public class HltvServices
    {
        public async Task<HltvResult> GetArticles(HltvScope scope)
        {
            string url = GetUrl(scope);
            
            var webclient = new WebClient();
            /*
            webclient.Headers["User-Agent"] =
                "Mozilla/4.0 (Compatible; Windows NT 5.1; MSIE 6.0) (compatible; MSIE 6.0; Windows NT 5.1; .NET CLR 1.1.4322; .NET CLR 2.0.50727)";
            */
            ServicePointManager.ServerCertificateValidationCallback = 
                new RemoteCertificateValidationCallback(
                   delegate { return true; }
                );
            
            string ret = string.Empty;
            List<HltvArticle> myDeserializedClass = new List<HltvArticle>();

            try
            {
                ret = await webclient.DownloadStringTaskAsync(url);
                myDeserializedClass = Newtonsoft.Json.JsonConvert.DeserializeObject<List<HltvArticle>>(ret);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }


            HltvResult result = new HltvResult();
            result.HltvArticles = myDeserializedClass;
                       
            return result;            
        }

        private string GetUrl(HltvScope scope)
        {
            return scope switch
            {
                HltvScope.HltvArticle => HltvArticle,
                _ => throw new Exception("Undefined scope")
            };
        }

        private string HltvArticle => "https://hltv-api.vercel.app/api/news.json";
    }

   
}
