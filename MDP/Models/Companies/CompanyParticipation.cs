using MDP.Models.Persons;
using MDP.Models.Works;
using System.ComponentModel.DataAnnotations.Schema;

namespace MDP.Models.Companies
{
    public class CompanyParticipation : IParticipation
    {
        public int Id { get; set; }
        public Company Participant { get; set; }
        public Artifact Artifact { get; set; }
        public List<Role> Roles { get; set; }
        public string? AdditionalInformation { get; set; }
        //Expects a Company
        IEntity IParticipation.Participant
        {
            get => Participant;
            set => Participant = (Company)value;
        }
    }
}
