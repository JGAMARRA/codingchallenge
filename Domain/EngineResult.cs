using System;

namespace Domain
{
    public class EngineResult:IComparable
    {
        public string sentence { get; set; }
        public string Engine { get; set; }
        public long Result { get; set; }

        public int CompareTo(object obj)
        {
            EngineResult temp = (EngineResult)obj;
            if (Result>temp.Result) {
                return 1;
            }
            if (Result < temp.Result)
            {
                return -1;
            }
            return 0;
        }
    }
}
