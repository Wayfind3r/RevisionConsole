using System;

namespace RevisionConsole.Globals.Helpers
{
    public static class ConsoleHelper
    {
        private const string _pressanyKeyToContinue = "Press any key to continue...";

        public static void PressAnyKeyToContinue()
        {
            Console.Write(_pressanyKeyToContinue);
            Console.ReadLine();
        }
    }
}
