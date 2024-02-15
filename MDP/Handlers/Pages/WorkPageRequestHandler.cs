
using MDP.Data;
using MDP.Handlers.Work;
using MDP.Models.Artifacts;
using MDP.Models.Pages;
using MDP.Models;
using MDP.Handlers.Review;
using MDP.Utils;
using MySql.Data.MySqlClient;

namespace MDP.Handlers.Pages
{

    public class WorkPageRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<WorkPageModel>
    {
        /// <summary>
        /// Falta adicionar reviews, related works, news and highlights e fractions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WorkPageModel> HandleRequest(int id)
        {
            Task<Artifact> workTask = new WorkRequestHandler(conn).HandleRequest(id);
            Task<List<Link>> personsTask = GetParticipantPersons(id);
            Task<List<Link>> companiesTask = GetParticipantCompanies(id);
            Task<List<Link>> newsTask = GetRecentNews(id);
            //Task<List<Models.Review>> reviewsTask = new RecentWorkReviewsRequestHandler(conn).HandleRequest(id);

            Artifact artifact = await workTask;
            WorkPageModel toReturn = new WorkPageModel();
            toReturn.Participants = [.. await companiesTask,.. await personsTask];
            //toReturn.Reviews = await reviewsTask;
            toReturn.NewsAndHighlights = await newsTask;
            toReturn.Work = artifact;
            return toReturn;
        }

        private async Task<List<Link>> GetRecentNews(int id)
        {
            Task<MySqlDataReader> newsTask = connector.ExecuteQuery(StatementPreparer.GetLinkableRecentWorkNews(id, Constants.MAX_RECENT_NEWS));
            MySqlDataReader reader = await newsTask;
            List<Link> toReturn = new List<Link>();
            while (reader.Read())
            {
                toReturn.Add(Link.FromLinkableNews(reader));
            }
            connector.CloseConnection(reader);
            return toReturn;
        }

        public async Task<List<Link>> GetParticipantPersons(int id)
        {
            Task<MySqlDataReader> linksTask = connector.ExecuteQuery(StatementPreparer.GetLinkablePersonParticipationsByWork(id));
            MySqlDataReader reader = await linksTask;
            List<Link> toReturn = new List<Link>();
            while (reader.Read())
            {
                toReturn.Add(Link.FromLinkablePerson(reader));
            }
            connector.CloseConnection(reader);
            return toReturn;
        }

        public async Task<List<Link>> GetParticipantCompanies(int id)
        {
            Task<MySqlDataReader> linksTask = connector.ExecuteQuery(StatementPreparer.GetLinkableCompanyParticipationsByWork(id));
            MySqlDataReader reader = await linksTask;
            List<Link> toReturn = new List<Link>();
            while (reader.Read())
            {
                toReturn.Add(Link.FromLinkableCompany(reader));
            }
            connector.CloseConnection(reader);
            return toReturn;
        }
    }
}
