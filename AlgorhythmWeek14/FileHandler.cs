using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Linq;
using System.Runtime.CompilerServices;

namespace AlgorhythmWeek14
{
    public class FileHandler
    {

        public FileHandler() { }

        public List<string> ReadFile(string filePath)
        {

            return File.ReadAllLines(filePath).ToList<string>();

        }
    }
}
