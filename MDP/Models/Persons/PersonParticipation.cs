using MDP.Models.Works;
using System.ComponentModel.DataAnnotations.Schema;
using System.Reflection.Metadata.Ecma335;

namespace MDP.Models.Persons
{
    public class PersonParticipation : IParticipation
    {
        public int Id { get; set; }
        public Person Participant { get; set; }
        public Artifact Artifact { get; set; }
        public List<Role> Roles { get; set; }
        public string? AdditionalInformation { get; set; }
        IEntity IParticipation.Participant
        {
            get => Participant;
            set => Participant = (Person)value;
        }
    }
}
