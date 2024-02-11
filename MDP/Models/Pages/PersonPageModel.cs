namespace MDP.Models.Pages
{
    using System.Collections.Generic;

    public class UserPageModel : BasePageModel
    {
        public Person Person { get; set; }
        public List<Link> ArtifactParticipations { get; set; } = [];
        public List<Link> CompanyAffiliations { get; set; } = [];
    }
}
