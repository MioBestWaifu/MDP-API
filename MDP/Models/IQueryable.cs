using MySql.Data.MySqlClient;

namespace MDP.Models
{
    public interface IQueryable <K>
    {
        public abstract static K FromQuery(MySqlDataReader reader);
    }
}
