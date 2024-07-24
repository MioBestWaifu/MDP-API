namespace MDP.Models.Pages
{
    using MDP.Models.Works;
    using System.Collections.Generic;

    public class FavoritesPageModel : BasePageModel
    {
        public List<string> Groups { get; set; } = ["Media","Category","Year"];
        public List<Artifact> AllFavorites { get; set; } = new List<Artifact>();
    }
}
