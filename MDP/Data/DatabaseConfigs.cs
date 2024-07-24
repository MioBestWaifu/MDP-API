namespace MDP.Data
{
    public class DatabaseConfigs
    {
        public string Server { get; set; }
        public string Database { get; set; }
        public string UserId { get; set; }
        public string Password { get; set; }
        public string Version { get; set; }

        public DatabaseConfigs(string server, string database, string userId, string password, string version)
        {
            Server = server;
            Database = database;
            UserId = userId;
            Password = password;
            Version = version;
        }

        public string GetConnectionString()
        {
            return $"server={Server};database={Database};user={UserId};password={Password};";
        }

        public int[] SplitVersion()
        {
            var splitString = Version.Split('.');
            return [int.Parse(splitString[0]),int.Parse(splitString[1]), int.Parse(splitString[2])];
        }
    }
}
