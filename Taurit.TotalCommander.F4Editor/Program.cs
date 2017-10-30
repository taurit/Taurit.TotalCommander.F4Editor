using System.Diagnostics;
using System.IO;

namespace Taurit.TotalCommander.F4Editor
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Debug.Assert(args.Length == 1, "Expecting 1 argument which is a full path to the file we want to edit.");
            var fileToEditPath = args[0];
            var program = new Program();
            program.OpenFileInDefaultEditor(fileToEditPath);
        }

        private void OpenFileInDefaultEditor(string fileToEditPath)
        {
            var pi = new ProcessStartInfo(fileToEditPath);
            pi.Arguments = Path.GetFileName(fileToEditPath);
            pi.UseShellExecute = true;
            pi.WorkingDirectory = Path.GetDirectoryName(fileToEditPath);
            pi.FileName = fileToEditPath;
            pi.Verb = "EDIT";
            Process.Start(pi);
        }
    }
}