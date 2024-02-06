namespace MDP.Models.Pages
{
    using MDP.Models.Artifacts;
    using System.Collections.Generic;

    public class WorkPageModel : BasePageModel
    {
        public Artifact Work { get; set; }
        public List<Interaction> Reviews { get; set; } = new List<Interaction>();
        public List<Link> Participants { get; set; } = new List<Link>();
        public List<Link> RelatedWorks { get; set; } = new List<Link>();
        public List<Link> NewsAndHighlights { get; set; } = new List<Link>();
        public List<Link> Fractions { get; set; } = new List<Link>();
    }
}
