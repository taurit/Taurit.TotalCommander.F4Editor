using System.Collections.Generic;
using Newtonsoft.Json;

namespace Taurit.TotalCommander.F4Editor.Models
{
    internal class ConfigurationFileModel
    {
        [JsonProperty] internal List<Editor> EditorConfigurations;
    }
}