
namespace MDP.Handlers.User
{
    using MDP.Models;
    using MDP.Data;
    using MySql.Data.MySqlClient;

    public class SimpleUserListRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<List<User>>
    {
        public Task<List<User>> HandleRequest(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<User>> HandleRequest(List<int> ids)
        {
            Task<MySqlDataReader> usersTask = connector.ExecuteQuery(StatementPreparer.GetListOfSimpleUsers(ids));
            List<User> toReturn = [];
            MySqlDataReader usersReader = await usersTask;
            while (usersReader.Read())
            {
                toReturn.Add(User.FromQuery(usersReader));
            }
            return toReturn;
        }
    }
}
