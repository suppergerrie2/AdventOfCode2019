using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Numerics;

namespace AdventOfCode2019
{
    abstract class Day
    {

        public abstract void Part1();

        public abstract void Part2();

        internal virtual string GetInputPath()
        {
            return Path.Combine("inputs", Path.ChangeExtension(GetType().Name, "txt"));
        }

        public List<string> InputLines()
        {
            return File.ReadAllLines(GetInputPath()).ToList();
        }

        public string InputAsString()
        {
            return File.ReadAllText(GetInputPath());
        }

        public IEnumerable<T> GetInputAsT<T>(Func<string,T> parse)
        {
            return InputLines().Select(parse);
        }

        public List<Vector3> InputAsVectors()
        {
            List<Vector3> vectors = new List<Vector3>();

            List<string> lines = InputLines();

            foreach(string line in lines)
            {
                string[] parts = line.Split(",");

                vectors.Add(new Vector3(
                    float.Parse(parts[0].Trim()),
                    float.Parse(parts[1].Trim()),
                    parts.Length>2?float.Parse(parts[2].Trim()):0
                 ));
            }

            return vectors;
        }
    }
}