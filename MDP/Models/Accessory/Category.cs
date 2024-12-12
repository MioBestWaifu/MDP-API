using MDP.Models.Works;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace MDP.Models.Accessory
{
    public class Category : Accessory
    {
        //To create a Many-to-Many, otherwise useless.
        [JsonIgnore]
        [ValidateNever]
        public List<Artifact> Artifacts { get; set; }
    }
}
