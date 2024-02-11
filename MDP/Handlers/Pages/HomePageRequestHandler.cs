using MDP.Data;
using MDP.Models;
using MDP.Models.Artifacts;
using MDP.Models.Pages;
using MDP.Utils;
using MySql.Data.MySqlClient;

namespace MDP.Handlers.Pages
{
    public class HomePageRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<HomePageModel>
    {
        public async Task<HomePageModel> HandleRequest(int id)
        {
            HomePageModel toReturn = new HomePageModel();
            toReturn.Artifacts = [];
            Task<MySqlDataReader> artifactsTask = connector.ExecuteQuery(StatementPreparer.GetFirstWorks());
            Task<MySqlDataReader> newsTask = connector.ExecuteQuery(StatementPreparer.GetLinkableRecentGlobalNews(Constants.MAX_RECENT_NEWS));
            MySqlDataReader artifactsReader = await artifactsTask;
            while (artifactsReader.Read())
            {
                toReturn.Artifacts.Add(Artifact.FromQuery(artifactsReader));
            }
            MySqlDataReader newsReader = await newsTask;
            toReturn.NewsAndHighlights = [];
            while (newsReader.Read())
            {
                toReturn.NewsAndHighlights.Add(Link.FromLinkableNews(newsReader));
            }
            return toReturn;
        }
    }
}
