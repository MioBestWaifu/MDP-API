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
                     return connector.Categories.Select(x=> x as Accessory).ToList();
                case (int)AccessoryType.Media:
                    return connector.Medias.Select(x => x as Accessory).ToList();
                case (int)AccessoryType.Demographic:
                    return connector.Demographics.Select(x => x as Accessory).ToList();
                case (int)AccessoryType.AgeRating:
                    return connector.AgeRatings.Select(x => x as Accessory).ToList();
                default:
                    throw new ArgumentException();
            }
        }
    }
}
