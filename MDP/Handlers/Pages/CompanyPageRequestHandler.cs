using MDP.Data;
using MySql.Data.MySqlClient;
using MDP.Models;
using MDP.Models.Pages;
using MDP.Models.Companies;
using MDP.Handlers.Companies;

namespace MDP.Handlers.Pages
{
    public class CompanyPageRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<CompanyPageModel>
    {
        public async Task<CompanyPageModel?> HandleRequest(int id)
        {
            //What if null?
            Company company = await new CompanyRequestHandler(conn).HandleRequest(id);
            CompanyPageModel toReturn = new CompanyPageModel();
            toReturn.Company = company;
            toReturn.Affiliates = connector.CompanyPeople.Where(x => x.Company.Id == company.Id && x.To == null).Select(x=> x.Person).ToList();
            return toReturn;
        }
    }
}
