using MDP.Data;
using MDP.Handlers.Persons;
using MDP.Models.Pages;
using MDP.Models;
using MySql.Data.MySqlClient;
using Microsoft.EntityFrameworkCore;

namespace MDP.Handlers.Pages
{
    public class PersonPageRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<PersonPageModel>
    {
        public async Task<PersonPageModel> HandleRequest(int id)
        {
            PersonPageModel toReturn = new PersonPageModel();

            toReturn.Person = await new PersonRequestHandler(conn).HandleRequest(id);

            toReturn.Participations = connector.PersonParticipations
                .Include(x => x.Artifact)
                    .ThenInclude(a=> a.ShortName)
                .Include(x => x.Artifact)
                    .ThenInclude(a=> a.CardImage)
                .Include(x => x.Roles)
                .Where(x => x.Participant.Id == id)
                .ToList();

            toReturn.Affiliations = connector.CompanyPeople
                .Include(x => x.Company)
                    .ThenInclude(c => c.ShortName)
                .Include(x => x.Company)
                    .ThenInclude(c => c.CardImage)
                .Where(x => x.Person.Id == id)
                .ToList();

            return toReturn;
        }
    }
}
