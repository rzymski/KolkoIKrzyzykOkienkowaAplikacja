using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace KolkoIKrzyzykOkienkowaAplikacja
{
    [Serializable]
    public class NecessaryData
    {
        public int[,] board { get; set; }
        public int pchessSize { get; set; }
        public int psymbolValue { get; set; }
        public int pmoveCount { get; set; }
    }
}
