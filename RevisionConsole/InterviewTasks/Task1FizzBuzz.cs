using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using RevisionConsole.Globals;

namespace RevisionConsole.InterviewTasks
{
    public class Task1FizzBuzz : Task
    {
        private const int _id = 1;
        private const string _name = "Fizz Buzz";

        private const string _description = "<< This task will print FizzBuzz, Fizz or Buzz for all numbers up to a number >>\n>> FizzBuzz: number is divisible by 3 and 5\n>> Buzz: number is divisible by 3\n>> Fizz number is divisible by 5";

        public override int Id { get; } = _id;
        public override string Name { get; } = _name;

        public static int TaskId { get; } = _id;
        public static string TaskName { get; } = _name;


        private const string _fizzBuzz = " FizzBuzz";
        private const string _fizz = " Fizz";
        private const string _buzz = " Buzz";

        public override void Run()
        {
            Console.WriteLine(_description);

            int number;
            string input;
            do
            {
                Console.WriteLine(_intValidationFailed);
                input = Console.ReadLine();
            }
            while (!int.TryParse(input, out number));

            for(int i = 1; i<= number; i++)
            {
                var output = i % 3 == 0 ? (i % 5 == 0 ? _fizzBuzz : _buzz) : (i % 5 == 0 ? _fizz : "");
                Console.WriteLine(i + output);
            }
        }
    }

}
