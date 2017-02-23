using RevisionConsole.Globals;
using System;
using System.Text;

namespace RevisionConsole.Loops.Task16GenerateAndScrambleNumbers
{
    public class Task16GenerateAndScrambleNumbers : Task
    {
        private Random random;

        public Task16GenerateAndScrambleNumbers()
        {
            random = new Random();
        }

        private const int _id = 16;
        private const string _name = "Generate And Scramble Numbers In Pairs";

        public override int Id { get; } = _id;
        public override string Name { get; } = _name;

        public static int TaskId { get; } = _id;
        public static string TaskName { get; } = _name;

        private const int _minLength = 4;

        private const string _invalidLengthError = "Length too low, meaningful swap cannot be performed.";
        private const string _enterANumber = "Please, enter a number: ";
        private const string _originalArrayMessage = "The original array was {0}";

        public override void Run()
        {
            Console.WriteLine(Name);

            string input = null;
            var taskResult = false;

            do
            {
                Console.Write(_enterANumber);
                input = Console.ReadLine();

                taskResult = ProcessInput(input);
            }
            while (!taskResult);
        }

        /// <summary>
        /// Generates a string of numbers with a given length, then swaps the numbers in non-overlapping pairs a random number of times.
        /// </summary>
        /// <param name="input">length of array</param>
        /// <returns></returns>
        private bool ProcessInput(string input)
        {
            var lengthInitialValidation = ParseInt(input);
            if(!lengthInitialValidation.IsValid)
            {
                return false;
            }

            var arrayOfNumbers = GenerateRandomNumericArray(lengthInitialValidation.Number);

            if (arrayOfNumbers == null)
            {
                Console.WriteLine(_invalidLengthError);
                return false;
            }

            var originalArrayString = string.Join("", arrayOfNumbers);
            Console.WriteLine(_originalArrayMessage, originalArrayString);

            var resultArray = SwapElementsInPairs(arrayOfNumbers);

            if (resultArray == null)
            {
                Console.WriteLine(_invalidLengthError);
            }

            var output = string.Join("", resultArray);

            Console.WriteLine("Swapped array result: {0}",output);

            return true;
        }

        /// <summary>
        /// Returns a new array with the input elements swapped in pairs a random number of times up to a maximum.
        /// <param name="input"></param>
        /// <returns></returns>
        private int[] SwapElementsInPairs(int[] input)
        {
            var result = (int[])input.Clone();

            var maxNumberOfSwaps = random.Next(1, input.Length);
            //-1 as we swap in pairs and we should never start from the last element;
            var maxRandomSwapIndex = input.Length - 1;

            for (int i = 0; i < maxNumberOfSwaps; i++)
            {
                var firstSwapIndex = random.Next(0, maxRandomSwapIndex);
                //Ensure that pairs do not overlap
                var secondSwapIndex = 0;
                do
                {
                    secondSwapIndex = random.Next(0, maxRandomSwapIndex);
                }
                while (firstSwapIndex <= secondSwapIndex + 1 && secondSwapIndex <= firstSwapIndex + 1);


                var originalFirstNumber = result[firstSwapIndex];
                var originalSecondNumber = result[firstSwapIndex+1];

                result[firstSwapIndex] = result[secondSwapIndex];
                result[firstSwapIndex + 1] = result[secondSwapIndex + 1];

                result[secondSwapIndex] = originalFirstNumber;
                result[secondSwapIndex + 1] = originalSecondNumber;
            }

            return result;
        }

        /// <summary>
        /// Generates a string of random numbers with a given length, returns null when the length is less than 1
        /// </summary>
        /// <param name="length"></param>
        /// <returns></returns>
        private int[] GenerateRandomNumericArray(int length)
        {
            if(length < _minLength)
            {
                return null;
            }

            var result = new int[length];

            for (int i = 0; i < result.Length; i++)
            {
                result[i] = random.Next(0, 10);
            }

            return result;
        }

    }
}
