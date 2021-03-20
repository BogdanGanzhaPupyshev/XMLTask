using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XMLAnalyze
{
    interface IFinder<T>
    {
        int FindCDsCount(T xElement);
        double FindPriceSum(T xElement);
        List<string> FindCountries(T xElement);
        int FindMinYear(T xElement);
        int FindMaxYear(T xElement);
    }
}
