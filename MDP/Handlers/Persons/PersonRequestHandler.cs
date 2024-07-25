using MDP.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using MySqlX.XDevAPI.Common;
using MDP.Models.Persons;
using Microsoft.EntityFrameworkCore;
namespace MDP.Handlers.Persons
{
    /// <summary>
    /// Returns a full Person. If you need a partial one, query elsewhere.s
    /// </summary>
    public class PersonRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<Person>
    {
        public async Task<Person?> HandleRequest(int id)
        {
            return connector.People
                .Include(x=>x.ShortName)
                .Include(x=>x.FullName)
                .Include(x=>x.Nicknames)
                .Include(x=>x.CardImage)
                .Include(x=>x.MainImage)
                .Include(x=>x.OtherImages)
                .Include(x=>x.Country)
                .Include(x=>x.Roles)
                .FirstOrDefault(p => p.Id == id);
        }

    }
}
