using System;
using System.Collections.Generic;
using System.Linq;

namespace Masterchef
{
    internal class Program
    {
        static void Main(string[] args)
        {
            //ingredient -> queue
            int[] ingredients = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> ingredientsQueue = new Queue<int>(ingredients);
            //freshness level  -> stack

            int[] freshnessLevels = Console.ReadLine()
                .Split(" ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> fLevelStack = new Stack<int>(freshnessLevels);

            int dippingSauceCount = 0;
            int greenSaladCount = 0;
            int chocolateCakeCount = 0;
            int lobstersCount = 0;

            SortedDictionary<string, int> dict = new SortedDictionary<string, int>();
            while (true)
            {
                if (ingredientsQueue.Count == 0 || fLevelStack.Count == 0)
                {
                    break;
                }
                int ingredient = ingredientsQueue.Peek();
                int level = fLevelStack.Peek();

                if (ingredient == 0)
                {
                    ingredientsQueue.Dequeue();
                    continue;
                }
                int multiplication = ingredient * level;
                if (multiplication == 150)
                {
                    dippingSauceCount++;
                    ingredientsQueue.Dequeue();
                    fLevelStack.Pop();
                    if (!dict.ContainsKey("Dipping sauce"))
                    {
                        dict.Add("Dipping sauce", dippingSauceCount);
                    }
                    else
                    {
                        dict["Dipping sauce"]++;
                    }

                }
                else if (multiplication == 250)
                {
                    greenSaladCount++;
                    ingredientsQueue.Dequeue();
                    fLevelStack.Pop();

                    if (!dict.ContainsKey("Green salad"))
                    {
                        dict.Add("Green salad", greenSaladCount);
                    }
                    else
                    {
                        dict["Green salad"]++;
                    }
                }
                else if (multiplication == 300)
                {
                    chocolateCakeCount++;
                    ingredientsQueue.Dequeue();
                    fLevelStack.Pop();
                    if (!dict.ContainsKey("Chocolate cake"))
                    {
                        dict.Add("Chocolate cake", chocolateCakeCount);
                    }
                    else
                    {
                        dict["Chocolate cake"]++;
                    }
                }
                else if (multiplication == 400)
                {
                    lobstersCount++;
                    ingredientsQueue.Dequeue();
                    fLevelStack.Pop();
                    if (!dict.ContainsKey("Lobster"))
                    {
                        dict.Add("Lobster", lobstersCount);
                    }
                    else
                    {
                        dict["Lobster"]++;
                    }

                }
                else
                {
                    var forEdit = ingredientsQueue.Dequeue() + 5;
                    ingredientsQueue.Enqueue(forEdit);
                    fLevelStack.Pop();
                }
            }
            if (dict.Count == 4)
            {
                Console.WriteLine("Applause! The judges are fascinated by your dishes!");
            }
            else
            {
                Console.WriteLine("You were voted off. Better luck next year.");

            }

            if (ingredientsQueue.Count > 0)
            {
                Console.WriteLine($"Ingredients left: {ingredientsQueue.Sum()}");
            }
            foreach (var item in dict)
            {
                Console.WriteLine($" # {item.Key} --> {item.Value}");
            }
        }
    }
}
