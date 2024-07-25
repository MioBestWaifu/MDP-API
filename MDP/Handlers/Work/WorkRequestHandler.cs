using MDP.Data;
using MDP.Models.Works;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System.Reflection.PortableExecutable;

namespace MDP.Handlers.Work
{
    public class WorkRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<Artifact>
    {
        public async Task<Artifact?> HandleRequest(int id)
        {
            Artifact? toReturn = connector.Artifacts.Find(id);
            if(toReturn is not null)
            {
                connector.Entry(toReturn).Collection(a => a.Categories).Load();
                connector.Entry(toReturn).Collection(a => a.ParticipantCompanies).Load();
                connector.Entry(toReturn).Collection(a => a.ParticipantPersons).Load();
                connector.Entry(toReturn).Collection(a => a.TargetDemographics).Load();
                connector.Entry(toReturn).Reference(a => a.AgeRating).Load();
                connector.Entry(toReturn).Reference(a => a.CardImage).Load();
                connector.Entry(toReturn).Reference(a => a.MainImage).Load();
                connector.Entry(toReturn).Reference(a => a.Media).Load();
                connector.Entry(toReturn).Reference(a => a.ShortName).Load();
                connector.Entry(toReturn).Reference(a => a.FullName).Load();
                return toReturn;
            }

            return null;
        }
    }
}
