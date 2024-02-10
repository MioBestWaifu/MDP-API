using MDP.Data;

namespace MDP.Handlers.Link
{
    using MDP.Models;
    using MySql.Data.MySqlClient;

    public class ParticipantPersonsAsLinksRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<List<Link>>
    {
        public async Task<List<Link>> HandleRequest(int id)
        {
            Task<MySqlDataReader> linksTask = connector.ExecuteQuery(StatementPreparer.GetLinkableParticipantPersons(id));
            MySqlDataReader reader = await linksTask;
            List<Link> toReturn = new List<Link>();
        }
    }
}
