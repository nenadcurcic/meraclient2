using DTOs;
using MeraClient2.Coms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeraClient2.DataInputStrategy
{
    public class InputFromDb : IDataInput
    {
        public async void GetTextFromSourceAndSendRequest(IComService comService)
        {
            Console.WriteLine("Db input strategy started!");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Geting text from db...");

            //TextContainer text = await comService.GetArticleBySubject("prvi");
            int wordsCount = await comService.GetWordsCount("kjahs kajhkjashd kajhsd");

            Console.WriteLine($"Number of words in tekst: {wordsCount}");
        }
    }
}
