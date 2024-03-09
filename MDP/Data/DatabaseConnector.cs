using MySql.Data.MySqlClient;
using System.Collections.Concurrent;
using System.Data;

namespace MDP.Data
{
    /// <summary>
    /// Classe que cria e gerencia conexões com o banco de dados. Atualmente usada como um Singleton e feito para
    /// ser usada como Singleton;
    /// </summary>
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

        /// <summary>
        /// Executa um SELECT e retorna seu MySqlDataReader. Quando terminar de usar o reader, chame <see cref="CloseConnection(MySqlDataReader)"/>.
        /// Isso é obrigatório, do contrário as conexões vão acumular e rapidamente exceder o máximo do servidor.
        /// </summary>
        /// <param name="command"></param>
        /// <returns></returns>
        public async Task<MySqlDataReader> ExecuteQuery(MySqlCommand command)
        {
            var conn = await GetConnection();
            command.Connection = conn;
            MySqlDataReader reader = await command.ExecuteReaderAsync() as MySqlDataReader;
            openConnections.TryAdd(reader, conn);
            return reader;
        }
        /// <summary>
        /// Isso é necessário porque por algum motivo fechar um MySqlDataReader não realmente fecha a conexão indendemente
        /// das configurações utilizadas. Assim, esse método DEVE ser usado após terminar de trabalhar com um MySqlDataReader.
        /// </summary>
        /// <param name="reader"></param>
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
