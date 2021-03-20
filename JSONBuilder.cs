using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLAnalyze
{
    class JSONBuilder : IFinder<XElement>
    {       

        public int FindCDsCount(XElement xElement) => xElement.Descendants("CD").Count();


        public List<string> FindCountries(XElement xElement)
        {
            List<string> countries = new List<string>();
            var countryQuery = xElement.Elements("CD").GroupBy(x => x.Element("COUNTRY").Value).ToList();

            foreach (var item in countryQuery)
            {
                countries.Add(item.Key.ToString());
            }

            return countries;
        }

        public int FindMaxYear(XElement xElement) => xElement.Elements("CD").Max(x => int.Parse(x.Element("YEAR").Value));


        public int FindMinYear(XElement xElement) => xElement.Elements("CD").Min(x => int.Parse(x.Element("YEAR").Value));


        public double FindPriceSum(XElement xElement)
        {
            var priceQuery = xElement.Descendants("CD").Select(x =>
            new
            {
                Count = x.Elements("PRICE").Count(),
                Sum = x.Elements("PRICE").Select(y => (double)y).Sum()
            }
            ).ToList();

            double priceSum = 0;
            foreach (var item in priceQuery)
            {
                priceSum += item.Count * item.Sum;
            }

            return Math.Round(priceSum,3);
        }

        public string BuildJSON(XElement xElement)
        {
            CDsInfo cDsInfo = new CDsInfo();

            cDsInfo.CDsCount = FindCDsCount(xElement);
            cDsInfo.PriceSum = FindPriceSum(xElement);
            cDsInfo.Countries = FindCountries(xElement);
            cDsInfo.MinYear = FindMinYear(xElement);
            cDsInfo.MaxYear = FindMaxYear(xElement);

            string json = JsonConvert.SerializeObject(cDsInfo);

            return json;
        }
    }
}
