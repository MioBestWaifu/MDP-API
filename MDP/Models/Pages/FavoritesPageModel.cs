namespace MDP.Models.Pages
{
    using MDP.Models.Artifacts;
    using System.Collections.Generic;

    public class FavoritesPageModel : BasePageModel
    {
        public List<string> Groups { get; set; } = new List<string>();
        public List<Artifact> AllFavorites { get; set; } = new List<Artifact>();
    }
}
