namespace MDP.Handlers.Company
{
    using MDP.Models;
    using MDP.Data;
    using MySql.Data.MySqlClient;
    using System.Threading.Tasks;

    public class CompanyRequestHandler : IRequestHandler<Company>
    {
        private DatabaseConnector connector;
        public CompanyRequestHandler(DatabaseConnector connector)
        {
            this.connector = connector;
        }
        //Inicia 5 connections 
        public async Task<Company> HandleRequest(int id)
        {
            Task<MySqlDataReader> companyTask = connector.ExecuteQuery(StatementPreparer.GetCompanyById(id));
            Task<MySqlDataReader> rolesTask = GetRoles(id);
            Task<MySqlDataReader> imagesTask = GetImages(id);
            Task<MySqlDataReader> averageRatingTask = GetAverageRating(id);
            Task<MySqlDataReader> countryTask = GetCountry(id);

            MySqlDataReader companyReader = await companyTask;
            companyReader.Read();
            Company toReturn = Company.FromQuery(companyReader);

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
