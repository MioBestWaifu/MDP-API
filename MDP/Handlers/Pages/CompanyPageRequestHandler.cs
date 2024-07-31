using MDP.Data;
using MySql.Data.MySqlClient;
using MDP.Models;
using MDP.Models.Pages;
using MDP.Models.Companies;
using MDP.Handlers.Companies;
using Microsoft.EntityFrameworkCore;

namespace MDP.Handlers.Pages
{
    public class CompanyPageRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<CompanyPageModel>
    {
        public async Task<CompanyPageModel?> HandleRequest(int id)
        {
            // What if null?
            Company company = await new CompanyRequestHandler(conn).HandleRequest(id);
            if (company == null)
            {
                return null;
            }

            List<CompanyParticipation> participations = connector.CompanyParticipations
                .Include(x => x.Artifact)
                    .ThenInclude(x=>x.ShortName)
                .Include(x => x.Artifact)
                    .ThenInclude(x=> x.CardImage)
                .Include(x => x.Roles)
                .Where(x => x.Company.Id == id)
                .ToList();

            List<CompanyPerson> currentAffiliates = connector.CompanyPeople
                .Include(x => x.Person)
                    .ThenInclude(x=>x.ShortName)
                .Include(x => x.Person)
                    .ThenInclude(x=>x.CardImage)
                .Where(x => x.Company.Id == id && x.End == null)
                .ToList();
            
            CompanyPageModel toReturn = new CompanyPageModel() {
                Company = company,
                Participations = participations,
                Affiliates = currentAffiliates
            };
            return toReturn;
        }
    }
}
