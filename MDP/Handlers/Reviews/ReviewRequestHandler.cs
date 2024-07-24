using MDP.Models;
using MDP.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using MDP.Handlers.Users;
using MDP.Models.Users;
namespace MDP.Handlers.Reviews
{


    /// <summary>
    /// Busca, cria e retorna uma única review baseada no Id dela.
    /// </summary>
    public class ReviewRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<Review>
    {
        public async Task<Review?> HandleRequest(int id)
        {
            return connector.Reviews.Where(x => x.Id == id).FirstOrDefault();
        }


    }
}
