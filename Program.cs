using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace XMLAnalyze
{
    class Program
    {
        static void Main(string[] args)
        {
            //Input your path
            string path = @"C:\Users\Богдан\Desktop\ТЗ Работа\XMLAnalyze\CDs.xml";

            XElement xElement = XElement.Load(path);

            JSONBuilder jSONBuilder = new JSONBuilder();

            Console.WriteLine(jSONBuilder.BuildJSON(xElement)); 
            
        }
    }
}
