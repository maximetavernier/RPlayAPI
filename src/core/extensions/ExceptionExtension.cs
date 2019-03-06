using System;

namespace RPlay.Core.Extensions
{
    /// <summary>
    /// Provide extension functions for the Exception class
    /// </summary>
    public static class ExceptionExtension
    {
        /// <summary>
        /// Print in console a complete message of the exception in console
        /// </summary>
        public static void PrintStackTrace(this Exception e)
        {
            Console.WriteLine($"[{e.Source}][{e.GetType()}]: {e.Message}");
            Console.WriteLine(e.StackTrace);
        }
    }
}
