using MDP.Data;
using MDP.Models.Users;
using MySql.Data.MySqlClient;

namespace MDP.Handlers.Users
{
    /// <summary>
    /// Busca, cria e retorna um único usuário baseado no Id dele.
    /// </summary>
    public class UserRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<User>
    {

        //Inicia 3 connections
        public async Task<User?> HandleRequest(int id)
        {
            return connector.Users
                .Where(u => u.Id == id)
                .FirstOrDefault();
        }
    }
}
