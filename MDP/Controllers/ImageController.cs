using MDP.Data;
using MDP.Handlers;
using MDP.Models;
using Microsoft.AspNetCore.Mvc;

namespace MDP.Controllers
{
    [ApiController]
    [Route("images")]
    public class ImageController : CrudController<Image, ImageInsert>
    {
        public ImageController(DatabaseConnector conn) : base(conn, new ImageHandler(conn))
        {
        }

        //These things should all return not found if not found
        [HttpGet("artifacts")]
        public Image GetFromArtifacts(int artifactId, ImageType type)
        {
            throw new NotImplementedException();
        }

        [HttpGet("persons")]
        public Image GetFromPersons(int personId, ImageType type)
        {
            throw new NotImplementedException();
        }

        [HttpGet("companies")]
        public Image GetFromCompanies(int companyId, ImageType type)
        {
            throw new NotImplementedException();
        }

        [HttpGet("users")]
        public Image GetFromUsers(int userId, ImageType type)
        {
            throw new NotImplementedException();
        }
    }
}
