using MeraClient2.Coms;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeraClient2.DataInputStrategy
{
    public class InputFromUser : IDataInput
    {
        public async Task GetTextFromSourceAndSendRequest(IComService comService)
        {
            await Task.Run(async () =>
             {
                 Console.WriteLine("User input strategy started!");
                 Console.WriteLine("-----------------------------");
                 Console.WriteLine("Enter text for word counter to count:");
                 string text = Console.ReadLine();

                 int wordsCount = await comService.GetWordsCount(text);

                 Console.WriteLine($"Number of words in tekst: {wordsCount}");
             });
        }
    }
}
