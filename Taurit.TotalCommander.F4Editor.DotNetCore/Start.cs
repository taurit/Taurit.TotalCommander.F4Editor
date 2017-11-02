using System.Diagnostics;
using Taurit.TotalCommander.F4Editor.Commons.Services;

namespace Taurit.TotalCommander.F4Editor.DotNetCore
{
    internal static class Start
    {
        // ReSharper disable once UnusedMember.Local
        private static void Main(string[] args)
        {
            Debug.Assert(args.Length == 2, "Expecting 2 arguments: *config file path* and *edited file path*.");
            var configFilePath = args[0];
            var fileToEditPath = args[1];

            var program = new FileOpener(new ProgramMatcher());
            program.OpenFile(configFilePath, fileToEditPath);
        }
    }
}