
using MDP.Models;
using MDP.Data;
using MySql.Data.MySqlClient;
namespace MDP.Handlers.User
{
    public class SimpleUserListRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<List<Models.User>>
    {
        public Task<List<Models.User>> HandleRequest(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Models.User>> HandleRequest(List<int> ids)
        {
            Task<MySqlDataReader> usersTask = connector.ExecuteQuery(StatementPreparer.GetListOfSimpleUsers(ids));
            List<Models.User> toReturn = [];
            MySqlDataReader usersReader = await usersTask;
            while (usersReader.Read())
            {
                toReturn.Add(Models.User.FromQuery(usersReader));
            }
            return toReturn;
        }
    }
}
