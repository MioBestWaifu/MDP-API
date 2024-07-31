using MDP.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using MDP.Models.Companies;
using Microsoft.EntityFrameworkCore;

namespace MDP.Handlers.Companies
{
    /// <summary>
    /// Returns a full Company. If you need a partial one, query elsewhere
    /// </summary>
    /// <param name="conn"></param>
    public class CompanyRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<Company>
    {
        public async Task<Company?> HandleRequest(int id)
        {
            return connector.Companies
                .Include(x=>x.ShortName)
                .Include(x=>x.FullName)
                .Include(x=>x.CardImage)
                .Include(x=>x.MainImage)
                .Include(x=>x.OtherImages)
                .Include(x=>x.Country)
                .Include(x=>x.Roles)
                .FirstOrDefault(x=> x.Id == id);
            //Do averagerating

        }
    }
}
