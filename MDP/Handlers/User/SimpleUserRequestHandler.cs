

namespace MDP.Handlers.User
{
    using MDP.Data;
    using MDP.Models;
    using MySql.Data.MySqlClient;
    using System.Threading.Tasks;

    public class SimpleUserRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<User>
    {
        /// <summary>
        /// Busca, cria e retorna um único usuário apenas com nome, id e url de mainImage, baseado no Id dele.
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        /// <exception cref="NotImplementedException"></exception>
        public async Task<User> HandleRequest(int id)
        {
            Task<MySqlDataReader> userTask = connector.ExecuteQuery(StatementPreparer.GetSimpleUserById(id));
            MySqlDataReader userReader = await userTask;
            userReader.Read();
            User toReturn = User.FromQuery(userReader);
            toReturn.MainImgUrl = userReader.GetString("url");

            return toReturn;
        }

    }
}
