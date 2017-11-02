using System.Collections.Generic;
using System.Runtime.Serialization;

namespace Taurit.TotalCommander.F4Editor.DotNetFramework.Models
{
    [DataContract]
    public class ConfigurationFileModel
    {
        [DataMember] internal GenericEditor DefaultEditor;
        [DataMember] internal List<SpecialPurposeEditor> EditorConfigurations;
    }
}