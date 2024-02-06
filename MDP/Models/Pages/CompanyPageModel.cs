namespace MDP.Models.Pages
{
    using System.Collections.Generic;

    public class CompanyPageModel : BasePageModel
    {
        public Company Company { get; set; }
        public List<Link> ArtifactParticipations { get; set; } = new List<Link>();
        public List<Link> Affiliates { get; set; } = new List<Link>();
    }
}
