using MDP.Data;
using MySql.Data.MySqlClient;
using MDP.Models;
using MDP.Models.Pages;

namespace MDP.Handlers.Pages
{
    public class CompanyPageRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<CompanyPageModel>
    {
        public Task<CompanyPageModel> HandleRequest(int id)
        {
            throw new NotImplementedException();
        }
        public async Task<List<Link>> GetCurrentAffiliates(int id)
        {
            Task<MySqlDataReader> linksTask = connector.ExecuteQuery(StatementPreparer.GetLinkableAffiliationsByCompany(id));
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
