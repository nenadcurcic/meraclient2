using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using DTOs;

namespace MeraClient2.Coms
{
    internal class MeraServerComService : IComService
    {
        
        private const string URL = "http://localhost:";
        private const string PORT = "44555";
        //private const string PORT = "44312";

        #region
        private const string GET_WORDS_COUNT = "/api/words/GetWordsCount";
        #endregion

        private readonly HttpClient client;


        public MeraServerComService()
        {
            client = new HttpClient();
            Console.WriteLine("Selected Mera Server");
            Console.WriteLine($"URL: {URL}");
            Console.WriteLine($"Port: {PORT}");
        }

        public async Task<TextContainer> GetArticleBySubject(string subject)
        {
            throw new NotImplementedException();
        }

        public async Task<Catalog> GetArticlesList()
        {
            throw new NotImplementedException();
        }

        public async Task<int> GetWordsCount(string text)
        {
            int res = 0;
            try
            {
                var builder = new UriBuilder(URL+PORT+ GET_WORDS_COUNT);
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["word"] = text;
                builder.Query = query.ToString();
                string url = builder.ToString();

                string responseBody = await client.GetStringAsync(url);
                Int32.TryParse(responseBody, out res);
                return res;
            }
            catch (HttpRequestException e)
            {

                return 0;
            }
        }
    }
}
