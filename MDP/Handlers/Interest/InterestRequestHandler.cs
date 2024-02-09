namespace MDP.Handlers.Interest
{
    using MDP.Models;
    using MDP.Data;
    using MySql.Data.MySqlClient;
    using System.Threading.Tasks;

    /// <summary>
    /// Busca, cria e retorna um único interest baseado no Id dele.
    /// </summary>
    public class InterestRequestHandler : IRequestHandler<Interest>
    {
        private DatabaseConnector connector;

        public InterestRequestHandler(DatabaseConnector connector)
        {
            this.connector = connector;
        }

        //Cria 2 connections
        public async Task<Interest> HandleRequest(int id)
        {
            Task<MySqlDataReader> interestTask = connector.ExecuteQuery(StatementPreparer.GetInterestById(id));
            Task<MySqlDataReader> demographicsTask = GetDemographics(id);

            MySqlDataReader interestReader = await interestTask;
            interestReader.Read();
            Interest toReturn = Interest.FromQuery(interestReader);

            Task? demographicsAfterTask = demographicsTask.ContinueWith((task) =>
            {
                toReturn.SetDemographics(task.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            Task.WaitAll(demographicsAfterTask);

            return toReturn;
        }

        private async Task<MySqlDataReader> GetDemographics(int id)
        {
            return await connector.ExecuteQuery(StatementPreparer.GetInterestDemographicsByInterestId(id));
        }
    }
}
