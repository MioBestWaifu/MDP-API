using MDP.Data;
using MySql.Data.MySqlClient;

namespace MDP.Handlers.User
{
    /// <summary>
    /// Busca, cria e retorna um único usuário baseado no Id dele.
    /// </summary>
    public class UserRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<Models.Users.User>
    {

        //Inicia 3 connections
        public async Task<Models.Users.User> HandleRequest(int id)
        {
            Task<MySqlDataReader> userTask = connector.ExecuteQuery(StatementPreparer.GetUserById(id));
            Task<MySqlDataReader> imageUrlsTask = GetImageUrls(id);
            Task<MySqlDataReader> countryTask = GetCountry(id);

            MySqlDataReader userReader = await userTask;
            userReader.Read();
            Models.Users.User toReturn = Models.Users.User.FromQuery(userReader);
            connector.CloseConnection(userReader);

            Task? imageUrlsAfterTask = imageUrlsTask.ContinueWith((task) =>
            {
                toReturn.SetImageUrls(task.Result);
                connector.CloseConnection(task.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            Task? countryAfterTask = countryTask.ContinueWith((task) =>
            {
                toReturn.SetCountry(task.Result);
                connector.CloseConnection(task.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            Task.WaitAll(imageUrlsAfterTask, countryAfterTask);

            return toReturn;
        }

        private async Task<MySqlDataReader> GetImageUrls(int id)
        {
            return await connector.ExecuteQuery(StatementPreparer.GetAllUserImages(id));
        }

        private async Task<MySqlDataReader> GetCountry(int id)
        {
            return await connector.ExecuteQuery(StatementPreparer.GetUserCountry(id));
        }
    }
}
