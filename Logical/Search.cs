using Domain;
using Services.Implementation;
using Services.Interface;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Logical
{
    public static class Search
    {
     
        static List<IEngineSearch> engines;
        static Search()
        {

            IEngineSearch EngineOptionBing = new EngineSearchBing();
            IEngineSearch EngineOptionGoogle = new EngineSearchGoogle();

             engines = new List<IEngineSearch>();
            engines.Add(EngineOptionBing);
            engines.Add(EngineOptionGoogle);
        }
        public static async Task<List<EngineResult>> SentenceSearch(IList<string> arguments)
        {            
            List<EngineResult> listaResults = new List<EngineResult>();

            EngineResult oEngineResult = null;
            foreach (string phrase in arguments)
            {                                
                //se realiza la busqueda en todos los motores de busqueda que existan
                foreach (IEngineSearch oEngine in engines)
                {
                    oEngineResult = new EngineResult();
                    oEngineResult.Engine = oEngine.Name;
                    oEngineResult.sentence = phrase;
                    oEngineResult.Result = await oEngine.GetTotalResults(phrase);
                }
                listaResults.Add(oEngineResult);
            }
            return listaResults;
        }
        public static EngineResult  WinnerEngine(List<EngineResult> lista,string nomEngine) {
            /*el enunciado indica no usar librerias , pero podria haber usado LInq para mejorarlo*/
            List<EngineResult> listCandidates=new List<EngineResult>();
            foreach (var item in lista)
            {
                if (item.Engine==nomEngine) {
                    listCandidates.Add(item);
                }
            }
            listCandidates.Sort();//segun comportamiento del objeto en metodo definido CompareTo
            return listCandidates.Count==0?null: listCandidates[0];
        }
        public static void PrintSentence(List<EngineResult> lista,string sentence)
        {
            int i = 0;
            foreach (var item in lista)
            {
                if (item.sentence==sentence) {
                    if (i==0) {
                        Console.Write(item.sentence +": ");
                        i = 1;
                    }
                    Console.Write(item.Engine + " : "+item.Result);
                }
            }
            Console.WriteLine();
        }
            public static void PrintWinnerEngine(List<EngineResult> lista) {
            EngineResult objTempResult=null;
            EngineResult objTemp=null;
            long cantMax = 0;
            foreach (var oEngine in engines)
            {
                objTemp=WinnerEngine(lista,oEngine.Name);
                if (cantMax<objTemp.Result) {
                    cantMax = objTemp.Result;
                    objTempResult= objTemp;
                }
                Console.WriteLine(lista[0].Engine + " winner: " + lista[0].sentence);
            }
            Console.WriteLine("Total winner: "+ objTempResult.sentence);
        }   
    }
}
