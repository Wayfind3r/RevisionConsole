using RevisionConsole.Globals.Helpers;
using RevisionConsole.Globals.ResultClasses;
using System;

namespace RevisionConsole.Globals
{
    /// <summary>
    /// Base class for all tasks
    /// </summary>
    public abstract class Task : BaseIdentifier
    {
        public Task(){}

        internal const string _intValidationFailed = "<< Value must be a number >>";

        internal IntValidation ParseInt(string input)
        {
            var result = StringHelper.ParseInt(input);

            if(!result.IsValid)
            {
                Console.WriteLine(_intValidationFailed);
            }

            return result;
        }

        /// <summary>
        /// Runs until the task is complete
        /// </summary>
        public abstract void Run();
    }
}
