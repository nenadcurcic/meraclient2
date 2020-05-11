using DTOs;
using MeraClient2.Coms;
using System;
using System.Threading.Tasks;

namespace MeraClient2.DataInputStrategy
{
    public class InputFromDb : IDataInput
    {
        public async Task GetTextFromSourceAndSendRequest(IComService comService)
        {
            await Task.Run(async () =>
            {
                Console.WriteLine("Db input strategy started!");
                Console.WriteLine("-----------------------------");
                Console.WriteLine("Geting text from db...");

                Catalog catalog = await comService.GetArticlesList();
                foreach (string subject in catalog.TextSubjectsList)
                {
                    Console.WriteLine(subject);
                }

                Console.WriteLine("Select one subject from list and type its name:");
                string selectedSubject = Console.ReadLine();
                if (catalog.TextSubjectsList.Contains(selectedSubject))
                {
                    TextContainer text = await comService.GetArticleBySubject(selectedSubject);
                    Console.WriteLine($"Text body: \n {text.Text}");
                    int wordsCount = await comService.GetWordsCount(text.Text);
                    Console.WriteLine($"========================o \nNumber of words in tekst: {wordsCount}");
                } else
                {
                    Console.WriteLine($"Typed subject doesn't exist:{selectedSubject}");
                }
            });

        }
    }
}
