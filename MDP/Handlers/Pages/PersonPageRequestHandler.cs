using MDP.Data;
using MDP.Handlers.Person;
using MDP.Models.Pages;
using MDP.Models;
using MySql.Data.MySqlClient;

namespace MDP.Handlers.Pages
{
    public class PersonPageRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<UserPageModel>
    {
        public async Task<UserPageModel> HandleRequest(int id)
        {
            Task<Models.Person> personTask = new PersonRequestHandler(conn).HandleRequest(id);
            Task<MySqlDataReader> participationsTask = connector.ExecuteQuery(StatementPreparer.GetLinkablePersonParticipationsByPerson(id));
            Task<MySqlDataReader> affiliationsTask = connector.ExecuteQuery(StatementPreparer.GetLinkableAffiliationsByPerson(id));

            Models.Person person = await personTask;
            UserPageModel toReturn = new UserPageModel();
            toReturn.Person = person;
            var participationsAfterTask = participationsTask.ContinueWith((task) =>
            {
                var result = task.Result;
                while (result.Read())
                {
                    toReturn.ArtifactParticipations.Add(Link.FromLinkableWork(result));
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            var affiliationsAfterTask = affiliationsTask.ContinueWith((task) =>
            {
                var result = task.Result;
                while (result.Read())
                {
                    toReturn.CompanyAffiliations.Add(Link.FromLinkableCompany(result));
                }
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            Task.WaitAll(participationsAfterTask, affiliationsAfterTask);
            return toReturn;
        }
    }
}
