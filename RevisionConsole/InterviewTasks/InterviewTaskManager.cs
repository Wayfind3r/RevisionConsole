using RevisionConsole.Globals;
using System;
using System.Collections.Generic;

namespace RevisionConsole.InterviewTasks
{
    public class InterviewTaskManager : TaskManager
    {
        private static SortedDictionary<int, TaskModel> _availableTasks = new SortedDictionary<int, TaskModel>
        {
            {Task2RemoveDuplicatesFromSortedArray.TaskId, new TaskModel { Name = Task2RemoveDuplicatesFromSortedArray.TaskName, Create = () => new Task2RemoveDuplicatesFromSortedArray() } },
            {Task1FizzBuzz.TaskId, new TaskModel { Name = Task1FizzBuzz.TaskName, Create = () => new Task1FizzBuzz() } },

        };

        private const string _mainMenuHeader = "<< Interview Questions Menu >>";
        private const int _id = 1;
        private const string _name = "Interview Questions";
        public override int Id { get; } = _id;
        public override string Name { get; } = _name;

        public static int ManagerId { get; } = _id;
        public static string ManagerName { get; } = _name;

        protected override SortedDictionary<int, TaskModel> AvailableTasks { get; } = _availableTasks;

        public override void GenerateMenu()
        {
            Console.WriteLine(_mainMenuHeader);
            foreach (var item in _availableTasks)
            {
                Console.WriteLine("{0}. {1}", item.Key, item.Value.Name);
            }
            Console.WriteLine(_enterANumber);
        }
    }
}
