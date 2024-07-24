using MDP.Data;
using MySql.Data.MySqlClient;
namespace MDP.Handlers.Users
{
    public class SimpleUserListRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<List<Models.Users.User>>
    {
        public Task<List<Models.Users.User>> HandleRequest(int id)
        {
            throw new NotImplementedException();
        }

        public async Task<List<Models.Users.User>> HandleRequest(List<int> ids)
        {
            if (ids.Count == 0)
            {
                return [];
            }
            Task<MySqlDataReader> usersTask = connector.ExecuteQuery(StatementPreparer.GetListOfSimpleUsers(ids));
            List<Models.Users.User> toReturn = [];
            MySqlDataReader usersReader = await usersTask;
            while (usersReader.Read())
            {
                var toAdd = Models.Users.User.FromQuery(usersReader);
                try
                {
                    toAdd.MainImgUrl = usersReader.GetString("url");
                }
                catch (Exception ex)
                {
                    Console.WriteLine("url column not found");
                }
                toReturn.Add(toAdd);
            }
            connector.CloseConnection(usersReader);
            return toReturn;
        }
    }
}
