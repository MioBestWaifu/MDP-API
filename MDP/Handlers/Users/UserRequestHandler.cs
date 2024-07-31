using MDP.Data;
using MDP.Models.Users;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;

namespace MDP.Handlers.Users
{
    /// <summary>
    /// Returns a full User. If need a partial one, query elsewhere
    /// </summary>
    public class UserRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<User>
    {

        public async Task<User?> HandleRequest(int id)
        {
            return connector.Users
                .Include(u => u.Nickname)
                .Include(u => u.CardImage)
                .Include(u => u.MainImage)
                .Include(u => u.OtherImages)
                .Include(u => u.Country)
                .FirstOrDefault(u => u.Id == id);
        }
    }
}
