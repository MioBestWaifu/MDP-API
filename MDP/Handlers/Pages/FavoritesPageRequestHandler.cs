using MDP.Data;
using MDP.Models.Works;
using MDP.Models.Pages;
using MySql.Data.MySqlClient;

namespace MDP.Handlers.Pages
{
    public class FavoritesPageRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<FavoritesPageModel>
    {
        public async Task<FavoritesPageModel> HandleRequest(int id)
        {
            FavoritesPageModel toReturn = new FavoritesPageModel();
            toReturn.AllFavorites = connector.UserFavoriteWorks.Where(x=> x.UserId == id)
                .Join(connector.Artifacts, uw => uw.ArtifactId, a => a.Id, (uw, a) => a).ToList();
            return toReturn;
        }

    }
}
