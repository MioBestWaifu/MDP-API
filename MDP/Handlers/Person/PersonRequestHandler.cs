using MDP.Models;
using MDP.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;
using MySqlX.XDevAPI.Common;
namespace MDP.Handlers.Person
{
    /// <summary>
    /// Busca, cria e retorna uma única pessoa baseada no Id dela.
    /// </summary>
    public class PersonRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<Models.Person>
    {
        //Inicia 4 connections
        public async Task<Models.Person> HandleRequest(int id)
        {
            Task<MySqlDataReader> personTask = connector.ExecuteQuery(StatementPreparer.GetPersonById(id));
            Task<MySqlDataReader> rolesTask = GetRoles(id);
            Task<MySqlDataReader> imagesTask = GetImages(id);
            Task<MySqlDataReader> countryTask = GetCountry(id);

            MySqlDataReader personReader = await personTask;
            personReader.Read();
            Models.Person toReturn = Models.Person.FromQuery(personReader);
            conn.CloseConnection(personReader);
            Task? rolesAfterTask = rolesTask.ContinueWith((task) =>
            {
                var result = task.Result;
                toReturn.SetRoles(result);
                connector.CloseConnection(result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task? imagesAfterTask = imagesTask.ContinueWith((task) =>
            {
                var result = task.Result;
                toReturn.SetImageUrls(result);
                connector.CloseConnection(result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task? countryAfterTask = countryTask.ContinueWith((task) =>
            {
                var result = task.Result;
                toReturn.SetCountry(result);
                connector.CloseConnection(result);
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
