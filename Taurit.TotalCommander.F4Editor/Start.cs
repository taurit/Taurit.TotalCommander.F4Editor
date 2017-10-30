using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.IO;
using System.Text;
using Newtonsoft.Json;
using Taurit.TotalCommander.F4Editor.Models;
using Taurit.TotalCommander.F4Editor.Services;

namespace Taurit.TotalCommander.F4Editor
{
    static class Start
    {
        private static void Main(string[] args)
        {
            Debug.Assert(args.Length == 2, "Expecting 2 arguments: *config file path* and *edited file path*.");
            var configFilePath = args[0];
            var fileToEditPath = args[1];

            var program = new FileOpener(new ProgramMatcher());
            program.OpenFile(configFilePath, fileToEditPath);
        }

        // ReSharper disable once UnusedMember.Local - used occasionally in development
        private static void GenerateExampleConfigFile(string path)
        {
            File.WriteAllText("d:/example.json", JsonConvert.SerializeObject(new ConfigurationFileModel()
            {
                EditorConfigurations = new List<Editor>()
                {
                    new Editor()
                    {
                        EditorPath = "notepad.exe",
                        ExtensionList = "txt;xml"
                    }
                }
            }));
        }

    }
}
