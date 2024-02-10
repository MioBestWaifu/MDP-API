
namespace MDP.Handlers.Link
{
    using MDP.Models;
    using MDP.Data;
    using MySql.Data.MySqlClient;

    public class CurrentAffiliatesAsLinksRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<List<Link>>
    {
        public async Task<List<Link>> HandleRequest(int id)
        {
            Task<MySqlDataReader> linksTask = connector.ExecuteQuery(StatementPreparer.GetLinkableCurrentAffiliates(id));
            MySqlDataReader reader = await linksTask;
            List<Link> toReturn = new List<Link>();
            while (reader.Read())
            {
                toReturn.Add(Link.FromLinkableAffiliation(reader));
            }
            return toReturn;
        }
    }
}
