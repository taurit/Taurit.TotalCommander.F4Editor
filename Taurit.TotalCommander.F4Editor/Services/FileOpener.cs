using System.Diagnostics;
using System.IO;
using JetBrains.Annotations;
using Newtonsoft.Json;
using Taurit.TotalCommander.F4Editor.Models;

namespace Taurit.TotalCommander.F4Editor.Services
{
    internal class FileOpener
    {
        private readonly ProgramMatcher _programMatcher;


        public FileOpener(ProgramMatcher programMatcher)
        {
            _programMatcher = programMatcher;
        }

        internal void OpenFile(string configFilePath, string filePath)
        {
            // read config file
            var configFileContent = File.ReadAllText(configFilePath);
            var config = JsonConvert.DeserializeObject<ConfigurationFileModel>(configFileContent);

            // find the right editor for file
            var editor = _programMatcher.GetEditorFor(filePath, config);

            // fallback scenario: open file in system default editor
            if (editor == null)
                OpenFileInNotepad(filePath);
            else
                OpenFileInEditor(editor, filePath);
        }

        private void OpenFileInNotepad(string filePath)
        {
            var processStartInfo = new ProcessStartInfo("notepad.exe");
            processStartInfo.Arguments = Path.GetFileName(filePath);
            processStartInfo.UseShellExecute = true;
            processStartInfo.WorkingDirectory = Path.GetDirectoryName(filePath);
            processStartInfo.Verb = "OPEN";
            Process.Start(processStartInfo);
        }

        private void OpenFileInEditor(Editor editor, string filePath)
        {
            var processStartInfo = new ProcessStartInfo(editor.EditorPath);
            processStartInfo.Arguments = Path.GetFileName(filePath);
            processStartInfo.UseShellExecute = true;
            processStartInfo.WorkingDirectory = Path.GetDirectoryName(filePath);
            processStartInfo.Verb = "OPEN";
            Process.Start(processStartInfo);
        }

        /// <summary>
        ///     This is risky, because system doesn't have association for all filetypes (eg. .json is unlikely to have any
        ///     association)
        /// </summary>
        /// <param name="filePath"></param>
        private void OpenFileInDefaultEditor([NotNull] string filePath)
        {
            var processStartInfo = new ProcessStartInfo(filePath);
            processStartInfo.Arguments = Path.GetFileName(filePath);
            processStartInfo.UseShellExecute = true;
            processStartInfo.WorkingDirectory = Path.GetDirectoryName(filePath);
            processStartInfo.FileName = filePath;
            processStartInfo.Verb = "EDIT";
            Process.Start(processStartInfo);
        }
    }
}