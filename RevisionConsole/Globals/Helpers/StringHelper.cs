using RevisionConsole.Globals.ResultClasses;
using System;

namespace RevisionConsole.Globals.Helpers
{
    public static class StringHelper
    {
        public static IntValidation ParseInt(string input)
        {
            //Assume that validation does not pass
            var result = new IntValidation { IsValid = false, Number = 0 };

            int number;
            if (!Int32.TryParse(input, out number))
            {
                return result;
            }

            result.IsValid = true;
            result.Number = number;

            return result;
        }
    }
}
