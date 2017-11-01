using Newtonsoft.Json;

namespace Taurit.TotalCommander.F4Editor.Models
{
    internal abstract class Editor
    {
        [JsonProperty]
        internal string EditorPath { get; set; }
    }
}