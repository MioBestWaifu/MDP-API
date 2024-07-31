using MDP.Models.Works;
using System.Collections.Generic;
namespace MDP.Models.Pages
{

    public class FavoritesPageModel : BasePageModel
    {
        public List<string> Groups { get; set; } = ["Media","Category","Year"];
        public List<Artifact> AllFavorites { get; set; } = new List<Artifact>();
    }
}
