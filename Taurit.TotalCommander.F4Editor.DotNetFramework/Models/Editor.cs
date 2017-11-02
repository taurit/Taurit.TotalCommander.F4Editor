using System.Runtime.Serialization;

namespace Taurit.TotalCommander.F4Editor.DotNetFramework.Models
{
    [DataContract]
    public abstract class Editor
    {
        [DataMember]
        internal string EditorPath { get; set; }
    }
}