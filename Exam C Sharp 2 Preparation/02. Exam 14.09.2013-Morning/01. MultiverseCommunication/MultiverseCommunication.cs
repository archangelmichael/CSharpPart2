using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _01.MultiverseCommunication
{
    class MultiverseCommunication
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();
        Dictionary<string, double> codes = new Dictionary<string, double>()
        {
            {"CHU",0},    {"TEL",1},    {"OFT",2},    {"IVA",3},    {"EMY",4},    {"VNB",5},    {"POQ",6},    {"ERI",7},
            {"CAD",8},    {"K-A",9},    {"IIA",10}, {"YLO",11}, {"PLA",12}};
 
        int baseLenght = 3;
        double digit = (input.Length / baseLenght ) - 1;
        double decimalResult = 0;
        int baseNumber = 13;
 
        for (int i = 0; i < input.Length; i += baseLenght )
        {
            string currentdigit = input.Substring(i, baseLenght );
            if (codes.ContainsKey(currentdigit))
            {
                decimalResult = decimalResult + (codes[currentdigit] * Math.Pow(baseNumber, digit));
            }
            digit--;
        }
        Console.WriteLine(decimalResult);
        }
    }
}
