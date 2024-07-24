using MDP.Handlers.User;
using MDP.Models;
using MDP.Models.Artifacts;
using MDP.Models.Companies;
using MDP.Models.News;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Collections.Concurrent;
using System.Data;
using System.Text.Json;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace MDP.Data
{
    /// <summary>
    /// Classe que cria e gerencia conexões com o banco de dados. Atualmente usada como um Singleton e feito para
    /// ser usada como Singleton;
    /// </summary>
    public class DatabaseConnector : DbContext
    {
        private DatabaseConfigs configs;
        public DbSet<Artifact> Artifacts { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyPerson> CompanyPeople { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFavoriteWork> UserFavoriteWorks { get; set; }
        public DbSet<WorkNews> WorkNews { get; set; }

        public DatabaseConnector(IWebHostEnvironment environment, ILogger<DatabaseConnector> logger)
        {
            if (environment.IsDevelopment())
            {
                string filePath = Path.Combine(environment.ContentRootPath, "connection.txt");
                try
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                       
                    };
                    configs = JsonSerializer.Deserialize<DatabaseConfigs>(File.ReadAllText(filePath));
                }
                catch (Exception ex) when (ex is FileNotFoundException || ex is DirectoryNotFoundException)
                {
                    logger.LogInformation("\nconnection.json, que deveria estar no root da aplicação (/MDP), não foi encontrado\nO seguinte caminho foi tentado: " +
                        filePath);
                    throw;
                }
            }
            else
            {
            }
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {
                int[] version = configs.SplitVersion();
                optionsBuilder.UseMySql(configs.GetConnectionString(),
                   new MySqlServerVersion(new Version(version[0], version[1], version[2])));
            }

        }

    }
}
