using MDP.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using MySqlX.XDevAPI.Common;
using MDP.Models.Persons;
namespace MDP.Handlers.Persons
{
    /// <summary>
    /// Busca, cria e retorna uma única pessoa baseada no Id dela.
    /// </summary>
    public class PersonRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<Person>
    {
        public async Task<Person> HandleRequest(int id)
        {
            return connector.People.Where(p => p.Id == id).First();
        }

    }
}
