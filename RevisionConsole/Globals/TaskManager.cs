using RevisionConsole.Globals.Helpers;
using RevisionConsole.Globals.ResultClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RevisionConsole.Globals
{
    /// <summary>
    /// Base class for all task managers
    /// </summary>
    public abstract class TaskManager : BaseIdentifier
    {
        protected abstract SortedDictionary<int, TaskModel> AvailableTasks { get; }

        protected const string _enterANumber = "<< Please enters one of the available numbers >>";
        protected const string _intValidationFailed = "<< Value must be a number >>";

        public abstract void GenerateMenu();

        public Task GenerateTask(int taskId)
        {
            if (!AvailableTasks.ContainsKey(taskId))
            {
                return null;
            }

            return AvailableTasks[taskId].Create();
        }

        internal IntValidation ParseInt(string input)
        {
            var result = StringHelper.ParseInt(input);

            if (!result.IsValid)
            {
                Console.WriteLine(_intValidationFailed);
            }

            return result;
        }
    }

    public class TaskModel
    {
        public string Name { get; set; }
        public Func<Task> Create { get; set; }
    }

    public class TaskManagerModel
    {
        public string Name { get; set; }
        public Func<TaskManager> Create { get; set; }
    }
}
