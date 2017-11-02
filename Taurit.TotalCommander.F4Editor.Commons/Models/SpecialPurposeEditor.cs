using System.Collections.Generic;
using System.Linq;
using Newtonsoft.Json;

namespace Taurit.TotalCommander.F4Editor.Commons.Models
{
    internal sealed class SpecialPurposeEditor : Editor
    {
        [JsonProperty]
        internal string ExtensionList { get; set; }

        /// <summary>
        ///     Set of lowercase extensions supported by this editor.
        /// </summary>
        internal ISet<string> SupportedExtensions => new HashSet<string>(ExtensionList
            .Split(';', ',')
            .Select(extension => extension.Trim().ToLowerInvariant()));
    }
}