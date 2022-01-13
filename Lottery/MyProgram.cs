using System;
using System.Collections.Generic;
using System.Text;

namespace Lottery
{
    class MyProgram
    {
        public int entryNumAmount = 7;
        public int highestEntry = 35;

        Random r = new Random();

        public void Run() {
            bool running = true;
            while (running) { // Create loop so program doesn't have to be reopened to try again
                
                // Generate a sequence of numbers
                List<int> numbers = new List<int>();
                for (int i = 0; i < entryNumAmount; i++)
                    numbers.Add(r.Next(1, highestEntry));
                numbers.Sort(); // Sort smallest -> highest

                // Write information about the generated numbers
                Console.Write("Generated numbers");
                for (int i = 0; i < numbers.Count; i++)
                    Console.Write(" " + numbers[i]);
                Console.Write("\n");

                DateTime startTime = DateTime.Now;
                int tries = 0;
                bool foundReplica = false;
                while (!foundReplica) {
                    tries++;
                    
                    // Generate a new random sequence of numbers
                    List<int> numbers2 = new List<int>();
                    for (int i = 0; i < entryNumAmount; i++)
                        numbers2.Add(r.Next(1, highestEntry));
                    numbers2.Sort(); // Sort smallest -> highest
                    
                    // Since we sorted them we can loop through each digit and compare the numbers on the same position
                    bool found = true;
                    for (int i = 0; i < entryNumAmount; i++)
                        if (numbers[i] != numbers2[i])
                            found = false;
                    
                    // If it was indeed found, exit loop
                    foundReplica = found;
                }

                Console.WriteLine("Found same numbers after {0} tries!", tries);
                Console.WriteLine("Action took {0} milliseconds", (DateTime.Now - startTime).TotalMilliseconds);

                Console.WriteLine("\nPress any key to run again...\n");
                Console.ReadKey();
            }
        }
    }
}
