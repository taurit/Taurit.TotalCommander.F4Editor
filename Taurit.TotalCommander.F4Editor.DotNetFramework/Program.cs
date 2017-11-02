using System;
using System.Runtime.InteropServices;
using Taurit.TotalCommander.F4Editor.DotNetFramework.Services;

namespace Taurit.TotalCommander.F4Editor.DotNetFramework
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            if (args.Length != 2)
            {
                DisplayError(
                    $"Expected 2 arguments, found {args.Length}. Correct usage: f4editor config.json fileToEdit");
                return;
            }
            var configFilePath = args[0];
            var fileToEditPath = args[1];

            try
            {
                var program = new FileOpener(new ProgramMatcher());
                program.OpenFile(configFilePath, fileToEditPath);
            }
            catch (Exception unhandledException)
            {
                // global handler for exceptions that have not been predicted
                DisplayError($"Unhandled exception: {unhandledException.Message}");
            }
        }

        private static void DisplayError(string message)
        {
            MessageBox((IntPtr) 0, message, "f4editor: error", 0);
        }

        /// <summary>
        ///     Selected import to avoid using large Windows Forms dependency
        /// </summary>
        [DllImport("User32.dll", CharSet = CharSet.Unicode)]
        private static extern int MessageBox(IntPtr h, string m, string c, int type);
    }
}