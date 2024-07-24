
using MDP.Data;
using MDP.Handlers.Work;
using MDP.Models.Artifacts;
using MDP.Models.Pages;
using MDP.Models;
using MDP.Handlers.Review;
using MDP.Utils;
using MySql.Data.MySqlClient;

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
            //If artifact is null it should do something. Raise exception? Return error code?
            WorkPageModel toReturn = new WorkPageModel();
            toReturn.NewsAndHighlights = connector.WorkNews.Where(x => x.ArtifactId == artifact.Id).OrderByDescending(x => x.News.Date).Take(Constants.MAX_RECENT_NEWS).Select(x=> x.News).ToList();
            toReturn.Work = artifact;
            return toReturn;
        }
    }
}
