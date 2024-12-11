using MDP.Models.Companies;
using MDP.Models.Persons;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace MDP.Models.Accessory
{
    public class Role : Accessory
    {
        //All these things are useless and exist only to create a many-to-many
        [JsonIgnore]
        [ValidateNever]
        public List<PersonParticipation> PersonParticipations { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public List<CompanyParticipation> CompanyParticipations { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public List<Person> People { get; set; }
        [JsonIgnore]
        [ValidateNever]
        public List<Company> Companies { get; set; }
    }
}
