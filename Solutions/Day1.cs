using System;
using System.Collections.Generic;
using System.Linq;

namespace AdventOfCode2019.Solutions
{
    class Day1 : Day
    {
        public override void Part1()
        {
            Console.WriteLine($"Total fuel needed {GetInputAsT(int.Parse).Sum(i => (i / 3) - 2)}");
        }

        public override void Part2()
        {
            int totalFuel = 0;
            foreach (int mass in GetInputAsT(int.Parse))
            {
                int moduleFuel = (mass / 3) - 2;

                int i = (moduleFuel / 3) - 2;
                while (i > 0)
                {
                    moduleFuel += i;
                    i = i / 3 - 2;
                }
                totalFuel += moduleFuel;
            }

            Console.WriteLine($"Total fuel needed {totalFuel}");
        }
    }
}
