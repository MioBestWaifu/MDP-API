using MDP.Models.Persons;
using MDP.Models.Works;

namespace MDP.Models
{
    public interface IParticipation
    {
        public int Id { get; set; }
        protected IEntity Participant { get; set; }
        public Artifact Artifact { get; set; }
        public List<Role> Roles { get; set; }
        public string? AdditionalInformation { get; set; }
    }
}
