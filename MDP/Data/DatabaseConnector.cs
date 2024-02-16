using MySql.Data.MySqlClient;
using System.Collections.Concurrent;
using System.Data;

namespace MDP.Data
{
    public class DatabaseConnector
    {
        private string connectionString;
        private ConcurrentDictionary<MySqlDataReader, MySqlConnection> openConnections = [];

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

        public async Task<MySqlConnection> GetConnection()
        {
            var connection = new MySqlConnection(connectionString);
            await connection.OpenAsync();
            return connection;
        }

        public async Task<MySqlDataReader> ExecuteQuery(MySqlCommand command)
        {
            var conn = await GetConnection();
            command.Connection = conn;
            MySqlDataReader reader = await command.ExecuteReaderAsync() as MySqlDataReader;
            openConnections.TryAdd(reader, conn);
            return reader;
        }

        public void CloseConnection(MySqlDataReader reader)
        {
            if (openConnections.TryRemove(reader, out var conn))
            {
                conn.Close();
                conn.Dispose();
                reader.Close();
                reader.Dispose();
            }
        }

    }
}
