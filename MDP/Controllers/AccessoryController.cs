using MDP.Data;
using MDP.Handlers.Accessories;
using MDP.Models.Accessory;
using Microsoft.AspNetCore.Mvc;

namespace MDP.Controllers
{
    [ApiController]
    [Route("accessory")]
    public class AccessoryController : ControllerBase
    {
        private readonly DatabaseConnector conn;
        public AccessoryController(DatabaseConnector conn)
        {
            this.conn = conn;
        }

        [HttpGet("categories")]
        public List<Accessory> GetCategories()
        {
            return new AllAccessoriesRequestHandler(conn).HandleRequest((int)AccessoryType.Category).Result;
        }

        [HttpGet("medias")]
        public List<Accessory> GetMedias()
        {
            return new AllAccessoriesRequestHandler(conn).HandleRequest((int)AccessoryType.Media).Result;
        }

        [HttpGet("demographics")]
        public List<Accessory> GetDemographics()
        {
            return new AllAccessoriesRequestHandler(conn).HandleRequest((int)AccessoryType.Demographic).Result;
        }
    }
}
