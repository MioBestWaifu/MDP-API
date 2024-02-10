

namespace MDP.Handlers.Review
{
    using MDP.Data;
    using MDP.Models;
    using MDP.Utils;
    using System.Threading.Tasks;
    using MySql.Data.MySqlClient;
    using MDP.Handlers.User;

    public class RecentWorkReviewsRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<List<Review>>
    {
        public async Task<List<Review>> HandleRequest(int id)
        {
            Task<MySqlDataReader> reviewsTask = connector.ExecuteQuery(StatementPreparer.GetRecentWorkReviews(id,Constants.MAX_RECENT_REVIEWS));
            List<int> userIds = [];
            List<Review> toReturn = [];
            MySqlDataReader reviewsReader = await reviewsTask;
            while (reviewsReader.Read())
            {
                userIds.Add(reviewsReader.GetInt32("user"));
                toReturn.Add(Review.FromQuery(reviewsReader));
            }
            List<User> users = await new SimpleUserListRequestHandler(connector).HandleRequest(userIds);
            for (int i = 0; i < toReturn.Count; i++)
            {
                toReturn[i].SetUser(users[i]);
            }
            return toReturn;

        }
    }
}
