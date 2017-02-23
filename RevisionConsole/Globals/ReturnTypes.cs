using System;
/// <summary>
/// Contains return types that can be used across the application
/// </summary>
namespace RevisionConsole.Globals.ReturnTypes
{
    public class ValidationResult
    {
        public bool IsValid { get; set; }
    }

    public class IntValidation : ValidationResult
    {
        public int Number { get; set; }
    }
}
