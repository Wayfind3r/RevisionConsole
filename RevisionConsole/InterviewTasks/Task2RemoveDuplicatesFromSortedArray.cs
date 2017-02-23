using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RevisionConsole.Globals;
using System.Threading.Tasks;
using System.Diagnostics;
using RevisionConsole.Globals.Helpers;

namespace RevisionConsole.InterviewTasks
{
    public class Task2RemoveDuplicatesFromSortedArray : Globals.Task
    {
        private const string _name = "Remove duplicates from a sorted array";
        private const int _id = 2;

        private static int[] _array = new int[] { 1, 2, 2, 3, 4, 4, 4, 5, 5, 5, 6, 8, 9, 13, 13, 13, 13, 18, 18, 21, 21, 21, 24 };

        private const string _enterOneOfTheNumbers = "Enter one of the available numbers...";
        private const string _linqDistinctHeaderIEnumerable = ">> Using LINQ and .Distinct() without .ToArray()";
        private const string _linqDistinctHeaderArray = ">> Using LINQ and .Distinct() with .ToArray()";
        private const string _hashSetHeader = ">> Using HashSet casting";
        private const string _customAlgorithm = ">> Using a custom algorithm with basic logic";
        private const string _elapsedTime = ">> Elapsed time: {0} ticks";
        private const string _resultArray = ">> Result array is: {0}";
        private const string _targetArray = ">> Targer arrays is: {0}";
        private const string _stopExecution = ">> Stop Execution";

        private Dictionary<int, string> menuItems = new Dictionary<int, string>
        {
            {1, _linqDistinctHeaderIEnumerable },
            {2,  _linqDistinctHeaderArray},
            {3, _hashSetHeader },
            {4, _customAlgorithm },
            {0,  _stopExecution}
        };

        private Stopwatch stopwatch;

        public Task2RemoveDuplicatesFromSortedArray()
        {
            stopwatch = new Stopwatch();
        }

        public override int Id { get; } = _id;
        public override string Name { get; } = _name;

        public static int TaskId { get; } = _id;
        public static string TaskName { get; } = _name;

        public override void Run()
        {
            var number = GenerateMenuAndGetSelectedItemId();

            switch (number)
            {
                case 1:
                    UseLinqDistinctNoArrayCast();
                    break;
                case 2:
                    UseLinqDistinctWithArrayCast();
                    break;
                case 3:
                    UseHashSet();
                    break;
                case 4:
                    UseCustomAlgorithm();
                    break;
                case 0://Stop execution
                    return;
            }

            ConsoleHelper.PressAnyKeyToContinue();

            Run();
        }

        /// <summary>
        /// Generates the menu and returns the appropriate selection Id when complete.
        /// </summary>
        /// <returns></returns>
        private int GenerateMenuAndGetSelectedItemId()
        {
            Console.WriteLine(_name);

            foreach (var item in menuItems)
            {
                Console.WriteLine("{0}. {1}", item.Key, item.Value);
            }

            int number;
            string input;
            do
            {
                Console.WriteLine(_enterOneOfTheNumbers);
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out number) || !menuItems.ContainsKey(number));

            return number;
        } 

        private void PrintStartArray()
        {
            Console.WriteLine(_targetArray, string.Join(",", _array));
        }

        private void PrintResult(IEnumerable<int> resultArray)
        {
            var resultString = string.Join(",", resultArray);
            Console.WriteLine(_resultArray, resultString);
        }

        private void UseLinqDistinctNoArrayCast()
        {
            PrintStartArray();

            Console.WriteLine(_linqDistinctHeaderIEnumerable);
            stopwatch.Start();

            var resultArray = _array.Distinct();

            stopwatch.Stop();
            Console.WriteLine(_elapsedTime, stopwatch.ElapsedTicks);

            PrintResult(resultArray);
        }

        private void UseLinqDistinctWithArrayCast()
        {
            PrintStartArray();

            Console.WriteLine(_linqDistinctHeaderArray);
            stopwatch.Start();

            var resultArray = _array.Distinct().ToArray();

            stopwatch.Stop();
            Console.WriteLine(_elapsedTime, stopwatch.ElapsedTicks);

            PrintResult(resultArray);
        }

        private void UseHashSet()
        {
            PrintStartArray();

            Console.WriteLine(_hashSetHeader);
            stopwatch.Start();

            var hashset = new HashSet<int>(_array);
            var resultArray = new int[hashset.Count];
            hashset.CopyTo(resultArray);

            stopwatch.Stop();
            Console.WriteLine(_elapsedTime, stopwatch.ElapsedTicks);

            PrintResult(resultArray);
        }

        private void UseCustomAlgorithm()
        {
            PrintStartArray();
            //We will work with a single array without initializing a second collections
            var newArray = (int[])_array.Clone();

            Console.WriteLine(_hashSetHeader);
            stopwatch.Start();

            var currentPost = 0;
            for(int i = 0; i < _array.Length; i++)
            {
                newArray[currentPost] = newArray[i];
                currentPost++;
                for (int current = i+1; current < newArray.Length; current++)
                {
                    if (newArray[current] == newArray[i])
                    {
                        i = current;
                    }
                    else
                    {
                        break;
                    }
                }
            }
            //Get new sub-set
            var resultArray = new int[currentPost];
            Array.Copy(newArray, resultArray, currentPost);

            stopwatch.Stop();
            Console.WriteLine(_elapsedTime, stopwatch.ElapsedTicks);

            PrintResult(resultArray);
        }
    }
}
