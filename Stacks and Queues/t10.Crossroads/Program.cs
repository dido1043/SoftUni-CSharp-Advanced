using System;
using System.Collections.Generic;
using System.Linq;

namespace t10.Crossroads
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Queue<string> queue = new Queue<string>();
            Stack<string> stack = new Stack<string>();
            int greenlightDuration = int.Parse(Console.ReadLine());
            int freeWindowDuration = int.Parse(Console.ReadLine());
            int passedCars = 0;
            var command = Console.ReadLine();
            while (command != "END")
            {
                if (command == "green")
                {
                    int glDuration = greenlightDuration;
                    int fwDuration = freeWindowDuration;
                    int count = queue.Count;

                    for (int i = 0; i < count; i++)
                    {
                        if (glDuration >= queue.Peek().Length && queue.Any())
                        {
                            glDuration -= queue.Peek().Length;
                            stack.Push(queue.Dequeue());
                        }
                        else if (glDuration < queue.Peek().Length && queue.Any())
                        {
                            int totalTimeLeft = glDuration + fwDuration;

                            if (glDuration <= 0)
                            {
                                continue;
                            }
                            else if (totalTimeLeft > 0 && totalTimeLeft >= queue.Peek().Length)
                            {
                                totalTimeLeft -= queue.Peek().Length;
                                stack.Push(queue.Dequeue());
                                glDuration = 0;
                                fwDuration = 0;
                                passedCars++;
                            }
                            else if (totalTimeLeft <= 0 && totalTimeLeft < queue.Peek().Length)
                            {
                                Console.WriteLine("A crash happened!");
                                Console.WriteLine($"{queue.Peek()} was hit at {queue.Peek()[totalTimeLeft]}.");

                                return;
                            }
                        }
                    }
                }
                else
                {
                    queue.Enqueue(command);
                }
                
                command = Console.ReadLine();
            }
            Console.WriteLine("Everyone is safe.");
            Console.WriteLine($"{stack.Count} total cars passed the crossroads.");

        }
    }
}
