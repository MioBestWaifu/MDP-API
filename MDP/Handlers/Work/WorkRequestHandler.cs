using MDP.Data;
using MDP.Models.Artifacts;
using MySql.Data.MySqlClient;
using MySqlX.XDevAPI.Common;
using System.Reflection.PortableExecutable;

namespace MDP.Handlers.Work
{
    /// <summary>
    /// Busca, cria e retorna um único trabalho baseado no Id dele.
    /// </summary>
    public class WorkRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<Artifact>
    {

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
            conn.CloseConnection(artifactReader);

            Task? categoriesAfterTask =  categoriesTask.ContinueWith((task) => {
                var result = task.Result;
                toReturn.SetCategories(result);
                connector.CloseConnection(result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task? targetDemographicsAfterTask = targetDemographicsTask.ContinueWith((task) =>
            {
                var result = task.Result;
                toReturn.SetDemographics(result);
                connector.CloseConnection(result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task? otherNamesAfterTask = otherNamesTask.ContinueWith((task) =>
            {
                var result = task.Result;
                toReturn.SetOtherNames(result);
                connector.CloseConnection(result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task? imagesAfterTask = imagesTask.ContinueWith((task) =>
            {
                var result = task.Result;
                toReturn.SetImageUrls(result);
                connector.CloseConnection(result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task? averageRatingAfterTask = averageRatingTask.ContinueWith((task) =>
            {
                var result = task.Result;
                toReturn.SetAverageRating(result);
                connector.CloseConnection(result); ;
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task? mediaAfterTask = mediaTask.ContinueWith((task) =>
            {
                var result = task.Result;
                toReturn.SetMedia(result);
                connector.CloseConnection(result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);
            Task? mainParticipantRoleAfterTask = mainParticipantRoleTask.ContinueWith((task) =>
            {
                var result = task.Result;
                toReturn.SetMainParticipantRole(result);
                connector.CloseConnection(result);
            }, TaskContinuationOptions.OnlyOnRanToCompletion);

            Task.WaitAll(categoriesAfterTask, targetDemographicsAfterTask, otherNamesAfterTask, imagesAfterTask, 
                averageRatingAfterTask, mediaAfterTask, mainParticipantRoleAfterTask);

            return toReturn;
        }

        public async Task GetAcessoryInformation(Artifact artifact)
        {
            try
            {
                var reader = await GetCategories(artifact.Id);
                artifact.SetCategories(reader);
                connector.CloseConnection(reader);
            }
            catch (Exception)
            {
                Console.WriteLine($"Categories for artifact {artifact.Id} could not be set");
            }
            try
            {
                var reader = await GetTargetDemographics(artifact.Id);
                artifact.SetDemographics(reader);
                connector.CloseConnection(reader);
            }
            catch (Exception)
            {
                Console.WriteLine($"Demographics for artifact {artifact.Id} could not be set");
            }
            try
            {
                var reader = await GetOtherNames(artifact.Id);
                artifact.SetOtherNames(reader);
                connector.CloseConnection(reader);
            }
            catch (Exception)
            {
                Console.WriteLine($"Other names for artifact {artifact.Id} could not be set");
            }
            try
            {
                var reader = await GetImages(artifact.Id);
                artifact.SetImageUrls(reader);
                connector.CloseConnection(reader);
            }
            catch (Exception)
            {
                Console.WriteLine($"Images for artifact {artifact.Id} could not be set");
            }
            try
            {
                var reader = await GetAverageRating(artifact.Id);
                artifact.SetAverageRating(reader);
                connector.CloseConnection(reader);
            }
            catch (Exception)
            {
                Console.WriteLine($"Average rating for artifact {artifact.Id} could not be set");
            }
            try
            {
                var reader = await GetMedia(artifact.Id);
                artifact.SetMedia(reader);
                connector.CloseConnection(reader);
            }
            catch (Exception)
            {
                Console.WriteLine($"Media for artifact {artifact.Id} could not be set");
            }
            try
            {
                var reader = await GetMainParticipantRole(artifact.Id);
                artifact.SetMainParticipantRole(reader);
                connector.CloseConnection(reader);
            }
            catch (Exception)
            {
                Console.WriteLine($"Main participant role for artifact {artifact.Id} could not be set");
            }
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
