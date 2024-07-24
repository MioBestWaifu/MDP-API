using MDP.Data;
using MDP.Utils;
using MySql.Data.MySqlClient;
using MDP.Handlers.Users;

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
                try
                {
                    userIds.Add(reviewsReader.GetInt32("user"));
                }
                catch (Exception ex)
                {
                    Console.WriteLine("user column not found");
                }
                toReturn.Add(Models.Review.FromQuery(reviewsReader));
            }
            connector.CloseConnection(reviewsReader);
            List<Models.Users.User> users = await new SimpleUserListRequestHandler(connector).HandleRequest(userIds);
            for (int i = 0; i < toReturn.Count; i++)
            {
                toReturn[i].SetUser(users[i]);
            }
            return toReturn;

        }
    }
}
