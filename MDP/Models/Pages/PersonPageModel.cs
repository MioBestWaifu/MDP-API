namespace MDP.Models.Pages
{
    using System.Collections.Generic;

    public class PersonPageModel : BasePageModel
    {
        public Person Person { get; set; }
        public List<Link> ArtifactParticipations { get; set; } = new List<Link>();
        public List<Link> CompanyAffiliations { get; set; } = new List<Link>();
    }
}
