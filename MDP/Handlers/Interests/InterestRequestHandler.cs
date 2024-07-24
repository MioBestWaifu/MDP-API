using MDP.Models;
using MDP.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
namespace MDP.Handlers.Interests
{


    /// <summary>
    /// Busca, cria e retorna um único interest baseado no Id dele.
    /// </summary>
    public class InterestRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<Interest>
    {
        //Cria 2 connections
        public async Task<Interest> HandleRequest(int id)
        {
            //Pending decision on what to do with Interest, hence not adapting it
            throw new NotImplementedException();
        }
    }
}
