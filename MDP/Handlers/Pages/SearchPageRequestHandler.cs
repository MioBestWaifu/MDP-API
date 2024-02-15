using MDP.Data;
using MDP.Models.Artifacts;
using MDP.Models.Pages;
using MySql.Data.MySqlClient;

namespace MDP.Handlers.Pages
{
    public class SearchPageRequestHandler(DatabaseConnector conn) : Handler(conn), ISearchHandler<SearchPageModel>
    {
        public async Task<SearchPageModel> HandleSearch(string query, int page = 0)
        {
            Task<MySqlDataReader> artifactsTask = connector.ExecuteQuery(StatementPreparer.SearchWorks(query, page));
            SearchPageModel toReturn = new SearchPageModel();
            MySqlDataReader reader = await artifactsTask;
            while (reader.Read())
            {
                toReturn.Artifacts.Add(Artifact.FromQuery(reader));
            }
            connector.CloseConnection(reader);
            return toReturn;
        }
    }
}
