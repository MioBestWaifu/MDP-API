using MDP.Models.Works;
using System.Text.Json.Serialization;

namespace MDP.Models.Accessory
{
    public class Demographic : Accessory
    {
        //To create a Many-to-Many, otherwise useless.
        [JsonIgnore]
        public List<Artifact> Artifacts { get; set; }
    }
}
