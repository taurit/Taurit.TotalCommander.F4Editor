using System;
using System.Diagnostics;
using System.IO;
using System.Runtime.Serialization.Json;
using System.Text;
using Taurit.TotalCommander.F4Editor.DotNetFramework.Models;

namespace Taurit.TotalCommander.F4Editor.DotNetFramework.Services
{
    public class FileOpener
    {
        private readonly ProgramMatcher _programMatcher;


        public FileOpener(ProgramMatcher programMatcher)
        {
            _programMatcher = programMatcher;
        }

        public void OpenFile(string configFilePath, string filePath)
        {
            // read config file
            var configFileContent = File.ReadAllText(configFilePath);

            DataContractJsonSerializer s;

            //var config = JsonConvert.DeserializeObject<ConfigurationFileModel>(configFileContent);
            var config = Deserialize<ConfigurationFileModel>(configFileContent);

            // find the right editor for file
            var editor = _programMatcher.GetEditorFor(filePath, config);

            // fallback scenario: open file in system default editor
            OpenFileInEditor(editor, filePath);
        }

        private void OpenFileInEditor(Editor editor, string filePath)
        {
            var processStartInfo = new ProcessStartInfo(editor.EditorPath);
            processStartInfo.Arguments = $"\"{filePath}\"";
            processStartInfo.UseShellExecute = true;
            processStartInfo.WorkingDirectory = Path.GetDirectoryName(filePath);
            Process.Start(processStartInfo);
        }

        private static T Deserialize<T>(string json)
        {
            var instance = Activator.CreateInstance<T>();
            using (var ms = new MemoryStream(Encoding.Unicode.GetBytes(json)))
            {
                var serializer = new DataContractJsonSerializer(instance.GetType());
                return (T)serializer.ReadObject(ms);
            }
        }
    }
}