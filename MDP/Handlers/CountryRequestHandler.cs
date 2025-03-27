using MDP.Data;
using MDP.Models;

namespace MDP.Handlers
{
    public class CountryRequestHandler(DatabaseConnector connector) : Handler(connector)
    {
        public List<Country> GetAllCountries()
        {
            return connector.Countries.ToList();
        }
    }
}
