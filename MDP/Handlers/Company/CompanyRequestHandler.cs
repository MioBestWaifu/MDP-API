using MDP.Models;
using MDP.Data;
using MySql.Data.MySqlClient;
using System.Threading.Tasks;

namespace MDP.Handlers.Company
{

    /// <summary>
    /// Busca, cria e retorna uma única empresa baseada no Id dela.
    /// </summary>
    public class CompanyRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<Models.Company>
    {
        //Inicia 5 connections 
        public async Task<Models.Company> HandleRequest(int id)
        {
            Task<MySqlDataReader> companyTask = connector.ExecuteQuery(StatementPreparer.GetCompanyById(id));
            Task<MySqlDataReader> rolesTask = GetRoles(id);
            Task<MySqlDataReader> imagesTask = GetImages(id);
            Task<MySqlDataReader> averageRatingTask = GetAverageRating(id);
            Task<MySqlDataReader> countryTask = GetCountry(id);

            MySqlDataReader companyReader = await companyTask;
            companyReader.Read();
            Models.Company toReturn = Models.Company.FromQuery(companyReader);

            Task? rolesAfterTask = rolesTask.ContinueWith((task) =>
            {
                toReturn.SetRoles(task.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task? imagesAfterTask = imagesTask.ContinueWith((task) =>
            {
                toReturn.SetImageUrls(task.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task? averageRatingAfterTask = averageRatingTask.ContinueWith((task) =>
            {
                toReturn.SetAverageRating(task.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task? countryAfterTask = countryTask.ContinueWith((task) =>
            {
                toReturn.SetCountry(task.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            Task.WaitAll(rolesAfterTask, imagesAfterTask, averageRatingAfterTask, countryAfterTask);
            return toReturn;
        }

        private async Task<MySqlDataReader> GetRoles(int id)
        {
            return await connector.ExecuteQuery(StatementPreparer.GetCompanyRolesByCompanyId(id));
        }

        private async Task<MySqlDataReader> GetImages(int id)
        {
            return await connector.ExecuteQuery(StatementPreparer.GetAllCompanyImages(id));
        }

        private async Task<MySqlDataReader> GetAverageRating(int id)
        {
            return await connector.ExecuteQuery(StatementPreparer.GetCompanyAverageRating(id));
        }

        private async Task<MySqlDataReader> GetCountry(int id)
        {
            return await connector.ExecuteQuery(StatementPreparer.GetCompanyCountry(id));
        }
    }
}
