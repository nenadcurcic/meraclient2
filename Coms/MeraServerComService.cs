using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using DTOs;
using Newtonsoft.Json;

namespace MeraClient2.Coms
{
    internal class MeraServerComService : IComService
    {
        
        private const string URL = "https://localhost:";
        //private const string PORT = "44555";
        private const string PORT = "44312";

        #region
        private const string GET_WORDS_COUNT = "/api/words/GetWordsCount";
        private const string GET_ARTICLE_BY_SUBJECT = "/api/words/GetArticleBySubject";
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
            try
            {
                var builder = new UriBuilder(URL + PORT + GET_ARTICLE_BY_SUBJECT);
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["subject"] = subject;
                builder.Query = query.ToString();
                string url = builder.ToString();

                string responseBody = await client.GetStringAsync(url);

                dynamic jsonResponseBody = JsonConvert.DeserializeObject(responseBody);
                TextContainer response = new TextContainer
                {
                    Subject = jsonResponseBody.Subject,
                    Text = jsonResponseBody.Text,
                };
                return response;
            }
            catch (HttpRequestException e)
            {
                return null;
            }
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
