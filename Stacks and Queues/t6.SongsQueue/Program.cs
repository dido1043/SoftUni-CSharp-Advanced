using System;
using System.Collections.Generic;
using System.Linq;

namespace t6.SongsQueue
{
    internal class Program
    {
        public static object Show { get; private set; }

        static void Main(string[] args)
        {
            string[] songs = Console.ReadLine().Split(", ");
            Queue<string> queue = new Queue<string>(songs);
            
            while (queue.Count > 0)
            {
                var input = Console.ReadLine().Split(" ");
                if (input[0] == "Add")
                {
                    var songsToAdd = String.Join(" ", input.Skip(1));
                    Add(queue, songsToAdd);
                }
                else if (input[0] == "Play")
                {
                    Play(queue);
                }
                else if (input[0] == "Show")
                {
                    Console.WriteLine(String.Join(", ", queue));
                }
            }
            if (queue.Count <= 0)
            {
                Console.WriteLine("No more songs!");
            }
        }
        public static void Play(Queue<string> songsQueue)
        {
            songsQueue.Dequeue();

        }
        public static void Add(Queue<string> songsQueue, string song)
        {
            if (songsQueue.Contains(song))
            {
                Console.WriteLine($"{song} is already contained!");
            }
            else
            {
                songsQueue.Enqueue(song);
            }
        }
    }
}
