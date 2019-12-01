using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019
{
    class Day1 : Day
    {
        public override void Part1()
        {
            List<int> input = new List<int>();

            foreach (var line in InputLines())
            {
                input.Add(int.Parse(line));
            }

            Console.WriteLine($"Total fuel needed {input.Sum(i => (i/3)-2)}");
        }

        public override void Part2()
        {
            List<int> input = new List<int>();

            foreach (var line in InputLines())
            {
                input.Add(int.Parse(line));
            }

            int totalFuel = 0;
            foreach (int mass in input)
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
