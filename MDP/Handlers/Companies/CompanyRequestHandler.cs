using MDP.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using MDP.Models.Companies;

namespace MDP.Handlers.Companies
{
    public class CompanyRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<Company>
    {
        //Inicia 5 connections 
        public async Task<Company?> HandleRequest(int id)
        {
            return connector.Companies.Where(x => x.Id == id).FirstOrDefault();
            //Do averagerating

        }
    }
}
