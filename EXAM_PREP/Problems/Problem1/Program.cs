using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string[] meals = Console.ReadLine().Split(" ");
            int[] calories = Console.ReadLine().Split(" ").Select(int.Parse).ToArray();
            Queue<string> mealsQueue = new Queue<string>(meals);
            Stack<int> caloriesStack = new Stack<int>(calories);
            //Solution

            int currentCalories = 0;
            string currentMeal = "";
            int edited = 0;
            int counter = 0;
            int diff = 0;

            bool isHaveFood = true;
            while (mealsQueue.Count >= 0 && caloriesStack.Count > 0)
            {
                currentCalories = caloriesStack.Pop() - Math.Abs(diff);
                if (mealsQueue.Count == 0)
                {
                    caloriesStack.Push(currentCalories);
                    break;
                }
                while (currentCalories > 0)
                {
                    currentMeal = mealsQueue.Peek();
                    if (currentMeal == "salad")
                    {
                        currentCalories -= 350;
                        mealsQueue.Dequeue();
                    }
                    else if (currentMeal == "soup")
                    {
                        currentCalories -= 490;
                        mealsQueue.Dequeue();
                    }
                    else if (currentMeal == "pasta")
                    {
                        currentCalories -= 680;
                        mealsQueue.Dequeue();
                    }
                    else if (currentMeal == "steak")
                    {
                        currentCalories -= 790;
                        mealsQueue.Dequeue();
                    }
                    
                    counter++;
                }
                diff = currentCalories;
                currentCalories = 0;
            }
            if (mealsQueue.Count == 0)
            {
                Console.WriteLine($"John had {counter} meals. \n" +
                $"For the next few days, he can eat {string.Join(", ", caloriesStack)} calories.");
                return;
            }

            if (caloriesStack.Count == 0)
            {
                Console.WriteLine($"John ate enough, he had {counter} meals. \n" +
                                  $"Meals left: {string.Join(", ", mealsQueue)}.");

                return;
            }
        }
    }
}
