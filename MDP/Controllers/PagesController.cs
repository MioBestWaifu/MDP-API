using Microsoft.AspNetCore.Mvc;

namespace MDP.Controllers
{
    [ApiController]
    [Route("pages")]
    public class PagesController : ControllerBase
    {
        [HttpGet(Name = "GetPages")]
        public string Get()
        {
            return "Hello, World!";
        }
    }
}
