using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;

namespace Taurit.TotalCommander.F4Editor.DotNetFramework.Models
{
    [DataContract]
    internal sealed class SpecialPurposeEditor : Editor
    {
        [DataMember]
        internal string ExtensionList { get; set; }

        /// <summary>
        ///     Set of lowercase extensions supported by this editor.
        /// </summary>
        internal ISet<string> SupportedExtensions => new HashSet<string>(ExtensionList
            .Split(';', ',')
            .Select(extension => extension.Trim().ToLowerInvariant()));
    }
}