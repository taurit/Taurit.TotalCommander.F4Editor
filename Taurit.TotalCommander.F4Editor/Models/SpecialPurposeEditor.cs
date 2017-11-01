using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Taurit.TotalCommander.F4Editor.Models
{
    internal class SpecialPurposeEditor : Editor
    {
        [JsonProperty]
        internal string ExtensionList { get; set; }

        /// <summary>
        ///     Set of lowercase extensions supported by this editor.
        /// </summary>
        internal ISet<string> SupportedExtensions => ExtensionList
            .Split(';', ',')
            .Select(extension => extension.Trim().ToLowerInvariant())
            .ToHashSet();
    }
}