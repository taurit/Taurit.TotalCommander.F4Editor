using System.Diagnostics;
using System.IO;
using Newtonsoft.Json;
using Taurit.TotalCommander.F4Editor.Commons.Models;

namespace Taurit.TotalCommander.F4Editor.Commons.Services
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
            var config = JsonConvert.DeserializeObject<ConfigurationFileModel>(configFileContent);

            // find the right editor for file
            var editor = _programMatcher.GetEditorFor(filePath, config);

            // fallback scenario: open file in system default editor
            OpenFileInEditor(editor, filePath);
        }

        private void OpenFileInEditor(Editor editor, string filePath)
        {
            var processStartInfo = new ProcessStartInfo(editor.EditorPath);
            processStartInfo.Arguments = $"\"{Path.GetFileName(filePath)}\"";
            processStartInfo.UseShellExecute = true;
            processStartInfo.WorkingDirectory = Path.GetDirectoryName(filePath);
            Process.Start(processStartInfo);
        }
    }
}