using MDP.Data;
using MDP.Handlers;
using MDP.Handlers.Accessories;
using MDP.Models;
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

        [HttpGet("age-ratings")]
        public List<Accessory> GetAgeRatings()
        {
            return new AllAccessoriesRequestHandler(conn).HandleRequest((int)AccessoryType.AgeRating).Result;
        }

        [HttpGet("roles")]
        public List<Accessory> GetRoles()
        {
            return new AllAccessoriesRequestHandler(conn).HandleRequest((int)AccessoryType.Role).Result;
        }

        //Country não é um acessory, mas vai ficar aqui mesmo
        [HttpGet("countries")]
        public List<Country> GetCountries()
        {
            return new CountryRequestHandler(conn).GetAllCountries();
        }
    }
}
