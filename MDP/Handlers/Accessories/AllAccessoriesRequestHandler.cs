using MDP.Data;
using MDP.Models.Accessory;
using MySql.Data.MySqlClient;

namespace MDP.Handlers.Accessories
{
    public class AllAccessoriesRequestHandler(DatabaseConnector conn) : Handler(conn), IRequestHandler<List<Accessory>>
    {
        public async Task<List<Accessory>> HandleRequest(int id)
        {
            switch (id)
            {
                case (int)AccessoryType.Category:
                    return await GetCategories();
                case (int)AccessoryType.Media:
                    return await GetMedias();
                case (int)AccessoryType.Demographic:
                    return await GetDemographics();
                default:
                    throw new NotImplementedException();
            }
        }

        private async Task<List<Accessory>> GetCategories()
        {
            MySqlDataReader reader = await conn.ExecuteQuery(StatementPreparer.GetAllCategories());
            List<Accessory> toReturn = new List<Accessory>();
            while (reader.Read())
            {
                Accessory accessory = Accessory.FromQuery(reader);
                accessory.Type = (int)AccessoryType.Category;
                toReturn.Add(accessory);
            }
            return toReturn;
        }

        private async Task<List<Accessory>> GetMedias()
        {
            MySqlDataReader reader = await conn.ExecuteQuery(StatementPreparer.GetAllMedia());
            List<Accessory> toReturn = new List<Accessory>();
            while (reader.Read())
            {
                Accessory accessory = Accessory.FromQuery(reader);
                accessory.Type = (int)AccessoryType.Media;
                toReturn.Add(accessory);
            }
            return toReturn;
        }

        private async Task<List<Accessory>> GetDemographics()
        {
            MySqlDataReader reader = await conn.ExecuteQuery(StatementPreparer.GetAllDemographics());
            List<Accessory> toReturn = new List<Accessory>();
            while (reader.Read())
            {
                Accessory accessory = Accessory.FromQuery(reader);
                accessory.Type = (int)AccessoryType.Demographic;
                toReturn.Add(accessory);
            }
            return toReturn;
        }
    }
}
