using MySql.Data.MySqlClient;
using System.Data;

namespace MDP.Data
{
    public class DatabaseConnector
    {
        private string connectionString;

        public DatabaseConnector(IWebHostEnvironment environment, ILogger<DatabaseConnector> logger)
        {
            if (environment.IsDevelopment())
            {
                string filePath = Path.Combine(environment.ContentRootPath, "connection.txt");
                try
                {
                    connectionString = File.ReadAllText(filePath);
                }
                catch (Exception ex) when (ex is FileNotFoundException || ex is DirectoryNotFoundException)
                {
                    logger.LogInformation("\nconnection.txt, que deveria estar no root da aplicação (/MDP), não foi encontrado\nO seguinte caminho foi tentado: " +
                        filePath);
                    throw;
                }
            }
            else
            {
                connectionString = "Server=prod;Database=prod;User Id=prod;Password=prod;";
            }
            logger.LogInformation("\n" + connectionString + "\n");
        }

        public async Task<MySqlDataReader> ExecuteQueryAsync(MySqlCommand command)
        {
            using (var connection = new MySqlConnection(connectionString))
            {
                command.Connection = connection;
                
                await connection.OpenAsync();
                return command.ExecuteReaderAsync(CommandBehavior.Default);
            }
        }
    }
}
