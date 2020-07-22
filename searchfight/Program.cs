using Domain;
using Logical;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace searchfight
{
    class Program
    {
        static void Main(string[] args)
        { 

            if (args.Length == 0)
            {
                Console.WriteLine("Ingrese valores a buscar");
                return;
            }

            Console.WriteLine("Procesando...");
            MethodAsync(args).GetAwaiter().GetResult();
            Console.ReadLine();
        }
        static async Task MethodAsync(string[] args)
        {
            List<EngineResult> listResult = await Search.SentenceSearch(args.ToList());
            foreach (string sentence in args)
            {
                Search.PrintSentence(listResult, sentence);
            }

            Search.PrintWinnerEngine(listResult);
        }
    }
}
