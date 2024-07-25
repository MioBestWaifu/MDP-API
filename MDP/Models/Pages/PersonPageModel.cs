using System.Collections.Generic;
using MDP.Models.Companies;
using MDP.Models.Persons;

namespace MDP.Models.Pages
{
    public class PersonPageModel : BasePageModel
    {
        public Person Person { get; set; }
        public List<PersonParticipation> Participations { get; set; }
        public List<CompanyPerson> Affiliations { get; set; }
    }
}
