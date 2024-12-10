using MDP.Data;
using MDP.Models.Pages;

namespace MDP.Handlers.Pages
{
    public class FavoritesPageRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<FavoritesPageModel>
    {
        public async Task<FavoritesPageModel> HandleRequest(int id)
        {
            FavoritesPageModel toReturn = new FavoritesPageModel();
            toReturn.AllFavorites = connector.UserFavoriteWorks.Where(x=> x.User.Id == id)
                .Join(connector.Artifacts, uw => uw.Artifact.Id, a => a.Id, (uw, a) => a).ToList();
            return toReturn;
        }

    }
}
