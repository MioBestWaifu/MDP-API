namespace MDP.Handlers.Person
{
    using MDP.Models;
    using MDP.Data;
    using MySql.Data.MySqlClient;
    using System.Threading.Tasks;

    /// <summary>
    /// Busca, cria e retorna uma única pessoa baseada no Id dela.
    /// </summary>
    public class PersonRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<Person>
    {
        //Inicia 4 connections
        public async Task<Person> HandleRequest(int id)
        {
            Task<MySqlDataReader> personTask = connector.ExecuteQuery(StatementPreparer.GetPersonById(id));
            Task<MySqlDataReader> rolesTask = GetRoles(id);
            Task<MySqlDataReader> imagesTask = GetImages(id);
            Task<MySqlDataReader> countryTask = GetCountry(id);

            MySqlDataReader personReader = await personTask;
            personReader.Read();
            Person toReturn = Person.FromQuery(personReader);

            Task? rolesAfterTask = rolesTask.ContinueWith((task) =>
            {
                toReturn.SetRoles(task.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task? imagesAfterTask = imagesTask.ContinueWith((task) =>
            {
                toReturn.SetImageUrls(task.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task? countryAfterTask = countryTask.ContinueWith((task) =>
            {
                toReturn.SetCountry(task.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            Task.WaitAll(rolesAfterTask, imagesAfterTask, countryAfterTask);
            return toReturn;
        }

        private async Task<MySqlDataReader> GetCountry (int id)
        {
            return await connector.ExecuteQuery(StatementPreparer.GetPersonCountry(id));
        }

        private async Task<MySqlDataReader> GetRoles (int id)
        {
            return await connector.ExecuteQuery(StatementPreparer.GetPersonRolesByPersonId(id));
        }

        private async Task<MySqlDataReader> GetImages (int id)
        {
            return await connector.ExecuteQuery(StatementPreparer.GetAllPersonImages(id));
        }

    }
}
