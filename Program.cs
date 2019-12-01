using System;
using System.Diagnostics;
using System.IO;
using System.Linq;

namespace AdventOfCode2019
{
    class Program
    {
        static void Main(string[] args)
        {
            string dayToRun = "Day" + DateTime.Now.Day;
            if(args.Length != 0) {
                dayToRun = args[0];
            }

            bool checkPerformance = args.Length >= 1;

            int performanceLoops = 1;
            if (checkPerformance)
            {
                performanceLoops = int.Parse(args[1]);
            }

            Type t = Type.GetType("AdventOfCode2019.Solutions." + dayToRun);
            if (t == null)
            {
                Console.Error.WriteLine("Could not find " + dayToRun);
                return;
            }
                
            Day day = Activator.CreateInstance(t) as Day;

            if(day == null)
            {
                Console.Error.WriteLine(t + " was not a Day!");
                return;
            }

            try
            {
                //Create stopwatch to measure performance
                Stopwatch stopwatch = new Stopwatch();
                Console.WriteLine("Part 1:");
                stopwatch.Start();

                //Save default out
                TextWriter standardOut = Console.Out;
                for (int i = 0; i < performanceLoops; i++)
                {
                    if(i>0)
                    {
                        //If we have looped atleast once we change the standard out so nothing gets logged
                        Console.SetOut(TextWriter.Null);
                    }

                    day.Part1();
                }
                //Reset standard out
                Console.SetOut(standardOut);
                stopwatch.Stop();
                if(checkPerformance) Console.WriteLine($"Part 1 took {stopwatch.ElapsedMilliseconds / performanceLoops} ms");

                Console.WriteLine("\nPart 2:");
                stopwatch.Restart(); 
                for (int i = 0; i < performanceLoops; i++)
                {
                    if (i > 0)
                    {
                        //If we have looped atleast once we change the standard out so nothing gets logged
                        Console.SetOut(TextWriter.Null);
                    }

                    day.Part2();
                }
                //Reset standard out
                Console.SetOut(standardOut);
                stopwatch.Stop();
                if (checkPerformance) Console.WriteLine($"Part 2 took {stopwatch.ElapsedMilliseconds / performanceLoops} ms");
            } catch(NotImplementedException)
            {
                Console.WriteLine("A part is not implemented yet");
            }
        }
    }
}
