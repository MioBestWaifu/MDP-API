using MDP.Models.Companies;
using MDP.Models.Information;
using MDP.Models.Persons;
using MDP.Models.Works;
using System.Collections.Generic;
namespace MDP.Models.Pages
{
    public class WorkPageModel : BasePageModel
    {
        public Artifact Work { get; set; }
        public List<News> NewsAndHighlights { get; set; } = new List<News>();
        public List<PersonParticipation> ParticipantPersons { get; set; } = new List<PersonParticipation>();
        public List<CompanyParticipation> ParticipantCompanies { get; set; } = new List<CompanyParticipation>();
    }
}
