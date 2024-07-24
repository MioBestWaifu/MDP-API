using MDP.Data;
using MDP.Models.Artifacts;
using MDP.Models.Pages;
using MySql.Data.MySqlClient;

namespace MDP.Handlers.Pages
{
    public class FavoritesPageRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<FavoritesPageModel>
    {
        public async Task<FavoritesPageModel> HandleRequest(int id)
        {
            FavoritesPageModel toReturn = new FavoritesPageModel();
            toReturn.AllFavorites = connector.UserFavoriteWorks.Where(x=> x.UserId == id).Select(x => x.Artifact).ToList();
            return toReturn;
        }

    }
}
