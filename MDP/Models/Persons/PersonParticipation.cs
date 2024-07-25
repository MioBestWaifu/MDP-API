using MDP.Models.Works;

namespace MDP.Models.Persons
{
    public class PersonParticipation
    {
        public int Id { get; set; }
        public int PersonId { get; set; }
        public int ArtifactId { get; set; }
        public List<Role> Roles { get; set; }
        public string? AdditionalInformation { get; set; }
    }
}
