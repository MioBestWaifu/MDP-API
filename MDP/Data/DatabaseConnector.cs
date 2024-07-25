using MDP.Models;
using MDP.Models.Accessory;
using MDP.Models.Companies;
using MDP.Models.Information;
using MDP.Models.Persons;
using MDP.Models.Users;
using MDP.Models.Works;
using Microsoft.EntityFrameworkCore;
using MySql.Data.MySqlClient;
using System.Collections.Concurrent;
using System.Data;
using System.Text.Json;
using static Org.BouncyCastle.Math.EC.ECCurve;

namespace MDP.Data
{
    public class DatabaseConnector : DbContext
    {
        private DatabaseConfigs configs;
        public DbSet<Artifact> Artifacts { get; set; }
        public DbSet<Person> People { get; set; }
        public DbSet<PersonParticipation> PersonParticipations { get; set; }
        public DbSet<Company> Companies { get; set; }
        public DbSet<CompanyPerson> CompanyPeople { get; set; }
        public DbSet<CompanyParticipation> CompanyParticipations { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<UserFavoriteWork> UserFavoriteWorks { get; set; }
        public DbSet<WorkNews> WorkNews { get; set; }
        public DbSet<GlobalNews> GlobalNews { get; set; }
        public DbSet<Media> Medias { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Demographic> Demographics { get; set; }
        public DbSet<AgeRating> AgeRatings { get; set; }
        public DbSet<Role> Roles { get; set; }
        public DbSet<Review> Reviews { get; set; }
        public DbSet<ArtifactReview> ArtifactReviews { get; set; }

        public DatabaseConnector(IWebHostEnvironment environment, ILogger<DatabaseConnector> logger)
        {
            if (environment.IsDevelopment())
            {
                string filePath = Path.Combine(environment.ContentRootPath, "connection.json");
                try
                {
                    JsonSerializerOptions options = new JsonSerializerOptions
                    {
                        PropertyNameCaseInsensitive = true,
                       
                    };
                    configs = JsonSerializer.Deserialize<DatabaseConfigs>(File.ReadAllText(filePath),options);
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
                //Remember to implement this
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
