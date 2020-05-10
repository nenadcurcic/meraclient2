using MeraClient2.Coms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeraClient2.DataInputStrategy
{
    public class InputFromFile : IDataInput
    {
        public async void GetTextFromSourceAndSendRequest(IComService comService)
        {
            Console.WriteLine("File input strategy started!");
            Console.WriteLine("-----------------------------");
            Console.WriteLine("Reading file:");

            //string text = await ReadFile();
            string text = "jkashd kajhsdkjahs kajsd hajhsd";

            int wordsCount = await comService.GetWordsCount(text);

            Console.WriteLine($"Number of words in tekst: {wordsCount}");
        }

        private Task<string> ReadFile()
        {
            throw new NotImplementedException();
        }
    }
}
