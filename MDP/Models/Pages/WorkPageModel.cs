namespace MDP.Models.Pages
{
    using MDP.Models.Information;
    using MDP.Models.Works;
    using System.Collections.Generic;

    public class WorkPageModel : BasePageModel
    {
        public Artifact Work { get; set; }
        public List<News> NewsAndHighlights { get; set; } = new List<News>();
    }
}
