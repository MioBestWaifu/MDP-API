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
            toReturn.AllFavorites = await GetFavorites(id);
            return toReturn;
        }

        private async Task<List<Artifact>> GetFavorites(int id)
        {
            Task<MySqlDataReader> favoritesTask = connector.ExecuteQuery(StatementPreparer.GetUserFavoriteWorks(id));
            MySqlDataReader reader = await favoritesTask;
            List<Artifact> toReturn = new List<Artifact>();
            while (reader.Read())
            {
                Artifact toAdd = Artifact.FromQuery(reader);
                try
                {
                    toAdd.CardImgUrl = reader.GetString("url");
                } catch (Exception ex)
                {
                    Console.WriteLine("url column not found");
                }
                toReturn.Add(toAdd);
            }
            connector.CloseConnection(reader);
            return toReturn;
        }
    }
}
