using MDP.Data;
using MDP.Utils;
using MySql.Data.MySqlClient;
using MDP.Handlers.Users;
using MDP.Models;

namespace MDP.Handlers.Reviews
{
    public class RecentWorkReviewsRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<List<Review>>
    {
        public async Task<List<Review>> HandleRequest(int id)
        {
            throw new NotImplementedException();
        }
    }
}
