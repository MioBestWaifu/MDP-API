using MDP.Data;
using MySql.Data.MySqlClient;
using MDP.Models;
using MDP.Models.Pages;
using MDP.Handlers.Company;

namespace MDP.Handlers.Pages
{
    public class CompanyPageRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<CompanyPageModel>
    {
        public async Task<CompanyPageModel> HandleRequest(int id)
        {
            Task<List<Link>> affiliatesTask = GetCurrentAffiliates(id);
            Task<List<Link>> workParticipationsTask = GetWorkParticipations(id);
            Models.Company company = await new CompanyRequestHandler(conn).HandleRequest(id);
            CompanyPageModel toReturn = new CompanyPageModel();
            toReturn.Company = company;
            toReturn.Affiliates = await affiliatesTask;
            toReturn.ArtifactParticipations = await workParticipationsTask;
            return toReturn;
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

        public async Task<List<Link>> GetWorkParticipations(int id)
        {
            Task<MySqlDataReader> linksTask = connector.ExecuteQuery(StatementPreparer.GetLinkableCompanyParticipationsByCompany(id));
            MySqlDataReader reader = await linksTask;
            List<Link> toReturn = new List<Link>();
            while (reader.Read())
            {
                toReturn.Add(Link.FromLinkableWork(reader));
            }
            return toReturn;
        }
    }
}
