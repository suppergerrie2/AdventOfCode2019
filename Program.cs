using System;

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

            Type t = Type.GetType("AdventOfCode2019." + dayToRun);
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
                Console.WriteLine("Part 1:");
                day.Part1();

                Console.WriteLine("\nPart 2:");
                day.Part2();
            } catch(NotImplementedException)
            {
                Console.WriteLine("A part is not implemented yet");
            }
        }
    }
}
