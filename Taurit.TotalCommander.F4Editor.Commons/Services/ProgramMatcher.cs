using System.Diagnostics;
using System.IO;
using System.Linq;
using JetBrains.Annotations;
using Taurit.TotalCommander.F4Editor.Commons.Models;

namespace Taurit.TotalCommander.F4Editor.Commons.Services
{
    public class ProgramMatcher
    {
        [NotNull]
        public Editor GetEditorFor(string filePath, ConfigurationFileModel config)
        {
            var fileExtensionLowercase = new FileInfo(filePath).Extension.ToLowerInvariant().TrimStart('.');
            Debug.Assert(!fileExtensionLowercase.StartsWith("."), "File extension without a dot is expected");

            // there might be many entries for the same file type in case configuration file is shared between systems with different editors installed.
            var editorsThatSupportThisExtension = config
                .EditorConfigurations
                .Where(editor => editor.SupportedExtensions.Contains(fileExtensionLowercase));

            // first editor in order is preferred. 
            var preferredEditor =
                editorsThatSupportThisExtension.FirstOrDefault(editor => File.Exists(editor.EditorPath));

            return (Editor) preferredEditor ?? config.DefaultEditor;
        }
    }
}