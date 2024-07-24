namespace MDP.Models.Pages
{
    using MDP.Models.Artifacts;
    using MDP.Models.News;
    using System.Collections.Generic;

    public class WorkPageModel : BasePageModel
    {
        public Artifact Work { get; set; }
        public List<News> NewsAndHighlights { get; set; } = new List<News>();
    }
}
