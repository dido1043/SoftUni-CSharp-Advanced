using System;
using System.Collections.Generic;
using System.Linq;

namespace T01.BaristaContest
{
    public class Program
    {
        static void Main(string[] args)
        {
            //Coffee quantity Queue
            int[] coffeeQty = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Queue<int> coffeeQueue = new Queue<int>(coffeeQty);
            //Milk Quantity Stack
            int[] milkQty = Console.ReadLine()
                .Split(", ", StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse)
                .ToArray();
            Stack<int> milkStack = new Stack<int>(milkQty);

            int cortado = 0;
            int espresso = 0;
            int capuccino = 0;
            int americano = 0;
            int latte = 0;
            Dictionary<string, int> dict = new Dictionary<string, int>();
            while (true)
            {
                if (milkStack.Count == 0 || coffeeQueue.Count == 0)
                {
                    break;
                }

                int currentCoffee = coffeeQueue.Peek();
                int currentMilk = milkStack.Peek();
                int sum = currentCoffee + currentMilk;

                switch (sum)
                {
                    case 50:
                        cortado++;
                        coffeeQueue.Dequeue();
                        milkStack.Pop();
                        if (!dict.ContainsKey("Cortado"))
                        {
                            dict.Add("Cortado", cortado);
                        }
                        else
                        {
                            dict["Cortado"]++;
                        }
                        break;
                    case 75:
                        espresso++;
                        coffeeQueue.Dequeue();
                        milkStack.Pop();

                        if (!dict.ContainsKey("Espresso"))
                        {
                            dict.Add("Espresso", espresso);
                        }
                        else
                        {
                            dict["Espresso"]++;
                        }
                        break;
                    case 100:
                        capuccino++;
                        coffeeQueue.Dequeue();
                        milkStack.Pop();
                        if (!dict.ContainsKey("Capuccino"))
                        {
                            dict.Add("Capuccino", capuccino);
                        }
                        else
                        {
                            dict["Capuccino"]++;
                        }

                        break;
                    case 150:
                        americano++;
                        coffeeQueue.Dequeue();
                        milkStack.Pop();

                        if (!dict.ContainsKey("Americano"))
                        {
                            dict.Add("Americano", americano);
                        }
                        else
                        {
                            dict["Americano"]++;
                        }
                        break;
                    case 200:
                        latte++;
                        coffeeQueue.Dequeue();
                        milkStack.Pop();
                        if (!dict.ContainsKey("Latte"))
                        {
                            dict.Add("Latte", latte);
                        }
                        else
                        {
                            dict["Latte"]++;
                        }
                        break;
                    default:
                        coffeeQueue.Dequeue();
                        int edited = milkStack.Pop() - 5;
                        milkStack.Push(edited);
                        break;
                }
            }

            if (coffeeQueue.Count == 0 && milkStack.Count == 0)
            {
                Console.WriteLine("Nina is going to win! She used all the coffee and milk!");
                Console.WriteLine("Coffee left: none");
                Console.WriteLine("Milk left: none");
            }
            else
            {
                Console.WriteLine("Nina needs to exercise more! She didn't use all the coffee and milk!");
                if (coffeeQueue.Count == 0)
                {
                    Console.WriteLine($"Coffee left: none");
                }
                else
                {
                Console.WriteLine($"Coffee left: {String.Join(", ", coffeeQueue)}");
                }
                if (milkStack.Count == 0)
                {
                    Console.WriteLine($"Milk left: none");
                }
                else
                {
                    Console.WriteLine($"Milk left: {String.Join(", ", milkStack)}");
                }
            }
            var orderedByNum = dict.OrderBy(y => y.Value).ThenByDescending(x => x.Key).ToList();
            
            foreach (var item in orderedByNum)
            {
                Console.WriteLine($"{item.Key}: {item.Value}");
            }
        }
    }
}
