using MDP.Models.Persons;
using MDP.Models.Works;

namespace MDP.Models.Companies
{
    public class CompanyParticipation
    {
        public int Id { get; set; }
        public int CompanyId { get; set; }
        public int ArtifactId { get; set; }
        public List<Role> Roles { get; set; }
        public string? AdditionalInformation { get; set; }
    }
}
