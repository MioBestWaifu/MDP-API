

namespace MDP.Handlers.Pages
{
    using MDP.Data;
    using MDP.Handlers.Work;
    using MDP.Handlers.Link;
    using MDP.Models.Artifacts;
    using MDP.Models.Pages;
    using MDP.Models;
    using MDP.Handlers.Review;
    using MDP.Utils;
    using MySql.Data.MySqlClient;

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
            Task<List<Link>> personsTask = new ParticipantPersonsAsLinksRequestHandler(conn).HandleRequest(id);
            Task<List<Link>> companiesTask = new ParticipantCompaniesAsLinksRequestHandler(conn).HandleRequest(id);
            Task<List<Link>> newsTask = GetRecentNews(id);
            Task<List<Review>> reviewsTask = new RecentWorkReviewsRequestHandler(conn).HandleRequest(id);

            Artifact artifact = await workTask;
            WorkPageModel toReturn = new WorkPageModel();
            toReturn.Participants = [.. await companiesTask,.. await personsTask];
            toReturn.Reviews = await reviewsTask;
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
            return toReturn;
        }
    }
}
