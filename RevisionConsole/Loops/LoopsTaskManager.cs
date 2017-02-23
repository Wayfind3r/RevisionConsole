using RevisionConsole.Globals;
using RevisionConsole.Globals.ReturnTypes;
using System;
using System.Collections.Generic;
using Task16 = RevisionConsole.Loops.Task16GenerateAndScrambleNumbers;

namespace RevisionConsole.Loops
{
    public class LoopsTaskManager : TaskManager
    {
        private static SortedDictionary<int, TaskModel> availableTasks = new SortedDictionary<int, TaskModel>
        {
            {Task16.Task16GenerateAndScrambleNumbers.TaskId, new TaskModel { Name = Task16.Task16GenerateAndScrambleNumbers.TaskName, Create = () => new Task16.Task16GenerateAndScrambleNumbers()}  },

        };

        private const string _mainMenuHeader = "<< Loops Menu >>";

        protected override SortedDictionary<int, TaskModel> AvailableTasks { get{ return availableTasks; } }

        private const int _id = 6;
        private const string _name = "Loops";

        public override int Id { get; } = _id;

        public override string Name { get; } = _name;

        public static int ManagerId { get; } = _id;
        public static string ManagerName { get; } = _name;

        public override void GenerateMenu()
        {
            Console.WriteLine(_mainMenuHeader);
            foreach (var item in availableTasks)
            {
                Console.WriteLine("{0}. {1}", item.Key, item.Value.Name);
            }
            Console.WriteLine(_enterANumber);
        }
    }
}
