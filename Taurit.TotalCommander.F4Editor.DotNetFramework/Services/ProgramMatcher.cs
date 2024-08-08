using System;
using System.Diagnostics;
using System.IO;
using System.Linq;
using Taurit.TotalCommander.F4Editor.DotNetFramework.Models;

namespace Taurit.TotalCommander.F4Editor.DotNetFramework.Services
{
    public class ProgramMatcher
    {
        public Editor GetEditorFor(string filePath, ConfigurationFileModel config)
        {
            var fileInfo = new FileInfo(filePath);
            var fileExtensionLowercase = String.IsNullOrEmpty(fileInfo.Extension)
                ? fileInfo.Name.ToLowerInvariant()
                : fileInfo.Extension.ToLowerInvariant().TrimStart('.');
            Debug.Assert(!fileExtensionLowercase.StartsWith("."), "File extension without a dot is expected");

            // there might be many entries for the same file type in case configuration file is shared between systems with different editors installed.
            var editorsThatSupportThisExtension = config
                .EditorConfigurations
                .Where(editor => editor.SupportedExtensions.Contains(fileExtensionLowercase));

            // first editor in order is preferred. 
            var preferredEditor =
                editorsThatSupportThisExtension.FirstOrDefault(editor => File.Exists(editor.EditorPath));

            return (Editor)preferredEditor ?? config.DefaultEditor;
        }
    }
}