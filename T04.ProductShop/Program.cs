using System;
using System.Collections.Generic;
using System.Globalization;
using System.Threading;
namespace T04.ProductShop
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Thread.CurrentThread.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
            SortedDictionary<string, Dictionary<string,double>> dict = new SortedDictionary<string, Dictionary<string,double>>();

            string command = Console.ReadLine();
            while (command != "Revision")
            {
                string[] tokens = command.Split(", ");
                string shop = tokens[0];
                string product = tokens[1];
                double price = double.Parse(tokens[2]);

                if (!dict.ContainsKey(shop))
                {
                    dict.Add(shop, new Dictionary<string, double>());
                }
                dict[shop].Add(product, price);
                command = Console.ReadLine();
            }

            foreach (var item in dict)
            {
                Console.WriteLine($"{item.Key}->");
                foreach (var x in item.Value)
                {
                    Console.WriteLine($"Product: {x.Key}, Price: {x.Value}");
                } 
            }
        }
    }
}
