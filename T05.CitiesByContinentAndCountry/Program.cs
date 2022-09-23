using System;
using System.Collections.Generic;
namespace T05.CitiesByContinentAndCountry
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Dictionary < string,Dictionary<string, List<string>>> continents = new Dictionary<string, Dictionary<string, List<string>>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string[] token = Console.ReadLine().Split(" ");
                string continent = token[0];
                string country = token[1];
                string town = token[2];
                if (!continents.ContainsKey(continent))
                {
                    continents.Add(continent, new Dictionary<string, List<string>>());
                }
                if (!continents[continent].ContainsKey(country))
                {
                    continents[continent].Add(country, new List<string>());
                }
                continents[continent][country].Add(town);
                               
            }
            foreach (var item in continents)
            {
                Console.WriteLine($"{item.Key}:");
                foreach (var x in item.Value)
                {
                    Console.WriteLine($"    {x.Key} -> {String.Join(", ", x.Value)}");
                }
            }
        }
    }
}
