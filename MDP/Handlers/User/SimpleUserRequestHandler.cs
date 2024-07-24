
using MDP.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
namespace MDP.Handlers.User
{

    public class SimpleUserRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<Models.Users.User>
    {
        /// <summary>
        /// Busca, cria e retorna um único usuário apenas com nome, id e url de mainImage, baseado no Id dele.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<Models.Users.User> HandleRequest(int id)
        {
            Task<MySqlDataReader> userTask = connector.ExecuteQuery(StatementPreparer.GetSimpleUserById(id));
            MySqlDataReader userReader = await userTask;
            userReader.Read();
            Models.Users.User toReturn = Models.Users.User.FromQuery(userReader);
            try
            {
                toReturn.MainImgUrl = userReader.GetString("url");
            }
            catch (Exception ex)
            {
                Console.WriteLine("url column not found");
            }
            connector.CloseConnection(userReader);
            return toReturn;
        }

    }
}
