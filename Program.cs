using MeraClient2.Coms;
using MeraClient2.DataInputStrategy;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MeraClient2
{
    class Program
    {
        static async Task Main(string[] args)
        {

            Console.WriteLine("Client started...");
            
            Console.WriteLine("Selecting server:");
            IComService selectedServer = ComServiceFactory.GetComService("mera");

            Console.WriteLine("---------------------");

            int inputSelection = SelectUserInput();

            DataInputContext inputContext;

            switch (inputSelection)
            {
                case 1:
                    inputContext = new DataInputContext(new InputFromUser());
                    break;
                case 2:
                    inputContext = new DataInputContext(new InputFromDb());
                    break;
                case 3:
                    inputContext = new DataInputContext(new InputFromFile());
                    break;
                default:
                    inputContext = null;
                    break;
            }
            await inputContext.RunSelectedDataInput(selectedServer);
            Console.ReadKey();
        }

        static private int SelectUserInput()
        {
            string userinput = "from user";
            string dbinput = "from db";
            string fileinput = "from file";
            Console.WriteLine($"Select method (type number 1, 2, 3):\n -1 {userinput} \n -2 {dbinput} \n -3 {fileinput}");
            int x;
          
            do
            {
                int.TryParse(Console.ReadLine(), out x);
            } while (x > 3 || x < 0);

            switch (x)
            {
                case 1: 
                    Console.WriteLine($"You selected input {userinput}");
                    break;
                case 2:
                    Console.WriteLine($"You selected input {dbinput}");
                    break;
                case 3:
                    Console.WriteLine($"You selected input {fileinput}");
                    break;
                default:
                    break;
            }
            return x;
        }
    }
}
