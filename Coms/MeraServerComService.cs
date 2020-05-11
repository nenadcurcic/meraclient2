using System.Configuration;
using System.Collections.Specialized;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using System.Net.Http;
using System.Web;
using DTOs;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;


namespace MeraClient2.Coms
{
    internal class MeraServerComService : IComService
    {
        private readonly string URL;
        private readonly string PORT;
        #region
        private const string GET_WORDS_COUNT = "/api/words/GetWordsCount";
        private const string GET_ARTICLE_BY_SUBJECT = "/api/words/GetArticleBySubject";
        private const string GET_ARTICLES_LIST = "/api/words/GetTextsCatalog";
        #endregion

        private readonly HttpClient client;


        public MeraServerComService()
        {
            URL = ConfigurationManager.AppSettings.Get("Url");
            PORT = ConfigurationManager.AppSettings.Get("Port");
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
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<Catalog> GetArticlesList()
        {
            try
            {
                string url = URL + PORT + GET_ARTICLES_LIST;
                string responseBody = await client.GetStringAsync(url);

                dynamic jsonResponseBody = JsonConvert.DeserializeObject(responseBody);
                JArray TextSubjectsArray = jsonResponseBody.TextSubjectsList;

                Catalog response = new Catalog
                {
                    TextSubjectsList = TextSubjectsArray.ToObject<List<string>>()
                };
                return response;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return null;
            }
        }

        public async Task<int> GetWordsCount(string text)
        {
            try
            {
                var builder = new UriBuilder(URL + PORT + GET_WORDS_COUNT);
                var query = HttpUtility.ParseQueryString(builder.Query);
                query["word"] = text;
                builder.Query = query.ToString();
                string url = builder.ToString();

                string responseBody = await client.GetStringAsync(url);
                int res;
                Int32.TryParse(responseBody, out res);
                return res;
            }
            catch (HttpRequestException e)
            {
                Console.WriteLine(e.Message);
                return 0;
            }
        }
    }
}
