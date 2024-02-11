using MDP.Data;
using MDP.Utils;
using MySql.Data.MySqlClient;
using MDP.Handlers.User;

namespace MDP.Handlers.Review
{
    public class RecentWorkReviewsRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<List<Models.Review>>
    {
        public async Task<List<Models.Review>> HandleRequest(int id)
        {
            Task<MySqlDataReader> reviewsTask = connector.ExecuteQuery(StatementPreparer.GetRecentWorkReviews(id,Constants.MAX_RECENT_REVIEWS));
            List<int> userIds = [];
            List<Models.Review> toReturn = [];
            MySqlDataReader reviewsReader = await reviewsTask;
            while (reviewsReader.Read())
            {
                userIds.Add(reviewsReader.GetInt32("user"));
                toReturn.Add(Models.Review.FromQuery(reviewsReader));
            }
            List<Models.User> users = await new SimpleUserListRequestHandler(connector).HandleRequest(userIds);
            for (int i = 0; i < toReturn.Count; i++)
            {
                toReturn[i].SetUser(users[i]);
            }
            return toReturn;

        }
    }
}
