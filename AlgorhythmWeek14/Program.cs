using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static System.Net.Mime.MediaTypeNames;

namespace AlgorhythmWeek14
{
    class Program
    {
        static Stopwatch LinearWatch = new Stopwatch();

        static Stopwatch BinaryWatch = new Stopwatch();
        static void Main(string[] args)
        {
            FileHandler fileHandler = new FileHandler();
            List<string> data = fileHandler.ReadFile("C:\\Users\\cbfbro\\Downloads\\unsorted_numbers.csv");
            List<int> newData = new List<int>();
            foreach (var item in data)
            {
                newData.Add(Int32.Parse(item));
            }

            var insertionData = performInsertionSort(newData);
            //var shellSortData = performShellSort(newData);

            long biggestNumber = LinearSearch(insertionData);
            string linearWatchTime = LinearWatch.Elapsed.TotalSeconds.ToString();
            Console.WriteLine($"Linear Time: {linearWatchTime}");

            FindIndexBinary(biggestNumber, insertionData, 0, 14999);
            string binaryWatchTime = BinaryWatch.Elapsed.TotalSeconds.ToString();
            Console.WriteLine($"Binary Time:{binaryWatchTime}");
            Console.ReadKey();
        }

        static long LinearSearch(List<int> _data)
        {
            LinearWatch.Start();
            int greatest = _data[0];
            int biggestIndex = 0;
            for (int i = 1; i < _data.Count; i++)
            {
                if (_data[i] > greatest)
                {
                    greatest = _data[i];
                    biggestIndex = i;
                }
            }
            Console.WriteLine($"Linear Biggest Number:{_data[biggestIndex]}");
            while (biggestIndex > -1)
            {
                Console.WriteLine($"Linear Recursive Count Down: {_data[biggestIndex]}");
                biggestIndex -= 1500;
            }
            LinearWatch.Stop();
            return greatest;
        }

        static long FindIndexBinary(long numberToFind, List<int> _data, int indexMin, int indexMax)
        {
            BinaryWatch.Start();
            if (indexMin > indexMax)
            {
                return -1;
            }

            int mid = ((indexMax + indexMin) / 2);
            //since the array is sorted

            if (numberToFind < _data[mid])
            {
                return FindIndexBinary(numberToFind, _data, indexMin, mid - 1);
            }

            else if (numberToFind > _data[mid])

            {
                return FindIndexBinary(numberToFind, _data, mid + 1, indexMax);
            }
            else
            {
                Console.WriteLine($"Binary Biggest Index:{_data[mid]}");
                while (mid > -1)
                {
                    Console.WriteLine($"Binary Recursive Count Down:{_data[mid]}");
                    mid -= 1500;
                }
                BinaryWatch.Stop();
                return 0;
            }
        }

        static List<int> performShellSort(List<int> array)
        {
            int n = array.Count;
            int gap = n / 2;
            int temp;

            while (gap > 0)
            {
                for (int i = 0; i + gap < n; i++)
                {
                    int j = i + gap;
                    temp = array[j];

                    while (j - gap >= 0 && temp < array[j - gap])
                    {
                        array[j] = array[j - gap];
                        j = j - gap;
                    }

                    array[j] = temp;
                }

                gap = gap / 2;
            }

            return array;
        }

        static List<int> performInsertionSort(List<int> array)
        {
            int length = array.Count;

            for (int i = 1; i < length; i++)
            {
                int j = i;

                while ((j > 0) && (array[j] < array[j - 1]))
                {
                    int k = j - 1;
                    int temp = array[k];
                    array[k] = array[j];
                    array[j] = temp;

                    j--;
                }
            }
            return array;
        }

    } 
}
