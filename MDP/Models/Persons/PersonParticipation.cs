using MDP.Models.Works;

namespace MDP.Models.Persons
{
    public class PersonParticipation
    {
        public int Id { get; set; }
        public Person Person { get; set; }
        public Artifact Artifact { get; set; }
        public List<Role> Roles { get; set; }
        public string? AdditionalInformation { get; set; }
    }
}
