using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AdventOfCode2019.Solutions
{
    class Day2 : Day
    {
        public override void Part1()
        {
            int[] input = InputAsString().Split(",").Select(int.Parse).ToArray();

            input[1] = 12;
            input[2] = 2;

            //3085697

            Console.WriteLine($"\nAnswer is {RunSimulation(input)}");
        }

        int RunSimulation(int[] memory)
        {
            int instructionPointer = 0;
            while (instructionPointer < memory.Length)
            {
                switch (memory[instructionPointer])
                {
                    case 1:
                        memory[memory[instructionPointer + 3]] = memory[memory[instructionPointer + 1]] + memory[memory[instructionPointer + 2]];
                        instructionPointer += 4;
                        break;
                    case 2:
                        memory[memory[instructionPointer + 3]] = memory[memory[instructionPointer + 1]] * memory[memory[instructionPointer + 2]];
                        instructionPointer += 4;
                        break;
                    case 99:
                        goto finish;
                }
            }
        finish:
            return memory[0];
        }

        public override void Part2()
        {
            int[] input = InputAsString().Split(",").Select(int.Parse).ToArray();

            int result;
            for(int noun = 0; noun <= 99; noun++) {  
                for(int verb = 0; verb <= 99; verb++) {  
                    int[] memory = new int[input.Length];

                    input.CopyTo(memory, 0);

                    memory[1] = noun;
                    memory[2] = verb;

                    result = RunSimulation(memory);

                    if(result == 19690720)
                    {
                        Console.WriteLine(100 * noun + verb);
                    }
                }
            }
        }
    }
}
