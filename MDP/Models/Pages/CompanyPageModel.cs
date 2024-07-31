using System.Collections.Generic;
using MDP.Models.Companies;
using MDP.Models.Persons;

namespace MDP.Models.Pages
{
    public class CompanyPageModel : BasePageModel
    {
        public Company Company { get; set; }
        public List<CompanyParticipation> Participations { get; set; } = new List<CompanyParticipation>();
        public List<CompanyPerson> Affiliates { get; set; } = new List<CompanyPerson>();
    }
}
