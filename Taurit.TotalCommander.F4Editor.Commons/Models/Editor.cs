using Newtonsoft.Json;

namespace Taurit.TotalCommander.F4Editor.Commons.Models
{
    public abstract class Editor
    {
        [JsonProperty]
        internal string EditorPath { get; set; }
    }
}