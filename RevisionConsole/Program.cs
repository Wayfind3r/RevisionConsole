using RevisionConsole.Globals.ResultClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using RevisionConsole.Loops;
using RevisionConsole.Globals;
using RevisionConsole.Globals.Helpers;
using RevisionConsole.InterviewTasks;

namespace RevisionConsole
{
    class Program
    {
        private static SortedDictionary<int, TaskManagerModel> mainMenuItems = new SortedDictionary<int, TaskManagerModel>
        {
           {LoopsTaskManager.ManagerId, new  TaskManagerModel {Name = LoopsTaskManager.ManagerName, Create = () => new LoopsTaskManager() } },
            {InterviewTaskManager.ManagerId, new TaskManagerModel {Name = InterviewTaskManager.ManagerName, Create = () => new InterviewTaskManager() } },

        };
        
        private const string _mainMenuHeader = "<< Main Menu >>";
        private const string _enterANumber = "<< Please enters one of the available numbers >>";

        private const string _enterANumberInline = ">> Enter a number: ";

        static void Main(string[] args)
        {
            GenerateMainMenu();

            string input = null;
            IntValidation inputValidation = null;
            do
            {
                input = Console.ReadLine();
                inputValidation = ValidateMainMenuInput(input);
            }
            while (!inputValidation.IsValid);

            var taskManager = GetTaskManager(inputValidation.Number);

            taskManager.GenerateMenu();

            inputValidation = new IntValidation { IsValid = false, Number = 0 };
            do
            {
                Console.Write(_enterANumberInline);
                input = Console.ReadLine();
                inputValidation = StringHelper.ParseInt(input);
            }
            while (!inputValidation.IsValid);

            Globals.Task task = taskManager.GenerateTask(inputValidation.Number);
            while (task == null)
            {
                Console.WriteLine(_enterANumber);
                task = taskManager.GenerateTask(inputValidation.Number);
            }

            task.Run();
        }

        private static void GenerateMainMenu()
        {
            Console.WriteLine(_mainMenuHeader);
            foreach(var item in mainMenuItems)
            {
                Console.WriteLine("{0}. {1}", item.Key, item.Value.Name);
            }
            Console.WriteLine(_enterANumber);
        }

        /// <summary>
        /// Validates a string input as valid number for the main menu
        /// </summary>
        /// <param name="input"></param>
        /// <returns></returns>
        private static IntValidation ValidateMainMenuInput(string input)
        {
            //Assume that validation does not pass
            var result = new IntValidation { IsValid = false, Number = 0 };

            int number;
            if(!Int32.TryParse(input, out number) || !mainMenuItems.ContainsKey(number))
            {
                Console.WriteLine(_enterANumber);
                return result;
            }

            result.IsValid = true;
            result.Number = number;

            return result;
        }

        private static TaskManager GetTaskManager(int itemId)
        {
            var result = mainMenuItems[itemId].Create();

            return result;
        }
    }
}
