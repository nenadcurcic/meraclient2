using MeraClient2.Coms;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeraClient2.DataInputStrategy
{
    public class InputFromFile : IDataInput
    {
        const string FILE_LOCATION = @"\TextFiles\TextInput.txt";
        public async Task GetTextFromSourceAndSendRequest(IComService comService)
        {
            await Task.Run(async () =>
            {
                Console.WriteLine("File input strategy started!");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Reading file:");

                string text = await ReadFile();

                Console.WriteLine($"Text body: \n {text}");
                int wordsCount = await comService.GetWordsCount(text);

                Console.WriteLine($"Number of words in tekst: {wordsCount}");
            });
        }

        private async Task<string> ReadFile()
        {
            string text = string.Empty;
            string dir = Path.GetDirectoryName(System.Reflection.Assembly.GetExecutingAssembly().Location);
  
            await Task.Run(() =>
            {
                var fileStream = new FileStream(dir + FILE_LOCATION, FileMode.Open, FileAccess.Read);
                using (var streamReader = new StreamReader(fileStream, Encoding.UTF8))
                {
                    text = streamReader.ReadToEnd();
                }
            });
            return text;
         
        }
    }
}
