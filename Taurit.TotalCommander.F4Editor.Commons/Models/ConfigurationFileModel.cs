using System.Collections.Generic;
using Newtonsoft.Json;

namespace Taurit.TotalCommander.F4Editor.Commons.Models
{
    public class ConfigurationFileModel
    {
        [JsonProperty] internal GenericEditor DefaultEditor;
        [JsonProperty] internal List<SpecialPurposeEditor> EditorConfigurations;
    }
}