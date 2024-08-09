using MDP.Data;
using MDP.Handlers.Work;
using MDP.Models.Pages;
using MDP.Models;
using MDP.Handlers.Reviews;
using MDP.Utils;
using MySql.Data.MySqlClient;
using MDP.Models.Works;
using Microsoft.EntityFrameworkCore;

namespace MDP.Handlers.Pages
{

    public class WorkPageRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<WorkPageModel>
    {
        /// <summary>
        /// Falta adicionar reviews, related works, news and highlights e fractions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WorkPageModel> HandleRequest(int id)
        {
            //Where reviews?;

            Artifact artifact = await new WorkRequestHandler(connector).HandleRequest(id);
            if(artifact == null)
            {
                return null;
            }
            //If artifact is null it should do something. Raise exception? Return error code?
            WorkPageModel toReturn = new WorkPageModel();
            toReturn.Work = artifact;

            toReturn.NewsAndHighlights = connector.WorkNews
                .Where(x => x.ArtifactId == artifact.Id)
                .OrderByDescending(x => x.News.Date)
                .Take(Constants.MAX_RECENT_NEWS)
                .Include(wn => wn.News.Images)
                .Select(x=> x.News)
                .ToList();


            toReturn.ParticipantCompanies = connector.CompanyParticipations
                .Include(x => x.Participant)
                    .ThenInclude(c=> c.ShortName)
                .Include(x => x.Participant)
                    .ThenInclude(c => c.CardImage)
                .Include(x => x.Roles)
                .Where(x => x.Artifact.Id == artifact.Id)
                .ToList();

            toReturn.ParticipantPersons = connector.PersonParticipations
                .Include(x => x.Participant)
                    .ThenInclude(p => p.ShortName)
                .Include(x=> x.Participant)
                    .ThenInclude(p => p.CardImage)
                .Include(x=> x.Roles)
                .Where(x => x.Artifact.Id == artifact.Id)
                .ToList();
            return toReturn;
        }
    }
}
