using MDP.Data;
using MDP.Handlers.Work;
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
                //Isso tá uma merda, otimizar criando uma view no futuro
                Artifact artifact = Artifact.FromQuery(artifactsReader);
                try
                {
                    await new WorkRequestHandler(conn).GetAcessoryInformation(artifact);
                } catch (Exception ex)
                {
                    Console.WriteLine($"Artifact {artifact.Id} não conseguiu ser completado");
                }
                toReturn.Artifacts.Add(artifact);
            }
            MySqlDataReader newsReader = await newsTask;
            toReturn.NewsAndHighlights = [];
            while (newsReader.Read())
            {
                toReturn.NewsAndHighlights.Add(Link.FromLinkableNews(newsReader));
            }
            connector.CloseConnection(artifactsReader);
            connector.CloseConnection(newsReader);
            return toReturn;
        }
    }
}
