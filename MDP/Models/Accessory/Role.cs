using MDP.Models.Companies;
using MDP.Models.Persons;
using System.Text.Json.Serialization;

namespace MDP.Models.Accessory
{
    public class Role : Accessory
    {
        //All these things are useless and exist only to create a many-to-many
        [JsonIgnore]
        public List<PersonParticipation> PersonParticipations { get; set; }
        [JsonIgnore]
        public List<CompanyParticipation> CompanyParticipations { get; set; }
        [JsonIgnore]
        public List<Person> People { get; set; }
        [JsonIgnore]
        public List<Company> Companies { get; set; }
    }
}
