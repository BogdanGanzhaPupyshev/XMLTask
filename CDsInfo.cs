using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLAnalyze
{
    class CDsInfo
    {
        public int CDsCount { get; set; }
        public double PriceSum { get; set; }
        public List<string> Countries { get; set; }
        public int MinYear { get; set; }
        public int MaxYear { get; set; }
    }
}
