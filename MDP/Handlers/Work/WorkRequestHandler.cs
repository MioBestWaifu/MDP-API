using MDP.Data;
using MDP.Models.Artifacts;
using MySql.Data.MySqlClient;

namespace MDP.Handlers.Work
{
    /// <summary>
    /// Busca, cria e retorna um único trabalho baseado no Id dele.
    /// </summary>
    public class WorkRequestHandler : IRequestHandler<Artifact>
    {
        private DatabaseConnector connector;

        public WorkRequestHandler(DatabaseConnector connector)
        {
            this.connector = connector;
        }

        //Inicia 8 connections
        public async Task<Artifact> HandleRequest(int id)
        {
            Task<MySqlDataReader> artifactTask = connector.ExecuteQuery(StatementPreparer.GetWorkById(id));
            Task<MySqlDataReader> categoriesTask = GetCategories(id);
            Task<MySqlDataReader> targetDemographicsTask = GetTargetDemographics(id);
            Task<MySqlDataReader> otherNamesTask = GetOtherNames(id);
            Task<MySqlDataReader> imagesTask = GetImages(id);
            Task<MySqlDataReader> averageRatingTask = GetAverageRating(id);
            Task<MySqlDataReader> mediaTask = GetMedia(id);
            Task<MySqlDataReader> mainParticipantRoleTask = GetMainParticipantRole(id);

            MySqlDataReader artifactReader = await artifactTask;
            artifactReader.Read();
            Artifact toReturn = Artifact.FromQuery(artifactReader);

            Task? categoriesAfterTask =  categoriesTask.ContinueWith((task) => {
                toReturn.SetCategories(task.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task? targetDemographicsAfterTask = targetDemographicsTask.ContinueWith((task) =>
            {
                toReturn.SetDemographics(task.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task? otherNamesAfterTask = otherNamesTask.ContinueWith((task) =>
            {
                toReturn.SetOtherNames(task.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task? imagesAfterTask = imagesTask.ContinueWith((task) =>
            {
                toReturn.SetImageUrls(task.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task? averageRatingAfterTask = averageRatingTask.ContinueWith((task) =>
            {
                toReturn.SetAverageRating(task.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task? mediaAfterTask = mediaTask.ContinueWith((task) =>
            {
                toReturn.SetMedia(task.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task? mainParticipantRoleAfterTask = mainParticipantRoleTask.ContinueWith((task) =>
            {
                toReturn.SetMainParticipantRole(task.Result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            Task.WaitAll(categoriesAfterTask, targetDemographicsAfterTask, otherNamesAfterTask, imagesAfterTask, 
                averageRatingAfterTask, mediaAfterTask, mainParticipantRoleAfterTask);

            return toReturn;
        }

        private async Task<MySqlDataReader> GetCategories(int id)
        {
            return await connector.ExecuteQuery(StatementPreparer.GetWorkCategoriesByWorkId(id));
        }

        private async Task<MySqlDataReader> GetTargetDemographics(int id)
        {
            return await connector.ExecuteQuery(StatementPreparer.GetWorkDemographics(id));
        }

        private async Task<MySqlDataReader> GetOtherNames(int id)
        {
            return await connector.ExecuteQuery(StatementPreparer.GetWorkOtherNames(id));
        }

        private async Task<MySqlDataReader> GetImages(int id)
        {
            return await connector.ExecuteQuery(StatementPreparer.GetAllWorkImages(id));
        }

        private async Task<MySqlDataReader> GetAverageRating(int id)
        {
            return await connector.ExecuteQuery(StatementPreparer.GetWorkAverageRating(id));
        }

        private async Task<MySqlDataReader> GetMedia(int id)
        {
            return await connector.ExecuteQuery(StatementPreparer.GetWorkMedia(id));
        }

        private async Task<MySqlDataReader> GetMainParticipantRole(int id)
        {
            return await connector.ExecuteQuery(StatementPreparer.GetWorkMainParticipantRole(id));
        }
    }
}
