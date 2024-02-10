

namespace MDP.Handlers.Pages
{
    using MDP.Data;
    using MDP.Handlers.Work;
    using MDP.Handlers.Link;
    using MDP.Models.Artifacts;
    using MDP.Models.Pages;
    using MDP.Models;
    public class WorkPageRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<WorkPageModel>
    {
        /// <summary>
        /// Falta adicionar reviews, related works, news and highlights e fractions
        /// </summary>
        /// <param name="id"></param>
        /// <returns></returns>
        public async Task<WorkPageModel> HandleRequest(int id)
        {
            Task<Artifact> workTask = new WorkRequestHandler(conn).HandleRequest(id);
            Task<List<Link>> personsTask = new ParticipantPersonsAsLinksRequestHandler(conn).HandleRequest(id);
            Task<List<Link>> companiesTask = new ParticipantCompaniesAsLinksRequestHandler(conn).HandleRequest(id);

            Artifact artifact = await workTask;
            WorkPageModel toReturn = new WorkPageModel();
            toReturn.Participants = [.. await companiesTask,.. await personsTask];
            toReturn.Work = artifact;
            return toReturn;
        }
    }
}
