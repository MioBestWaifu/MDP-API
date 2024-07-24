using MDP.Data;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace MDP.Controllers
{
    [ApiController]
    [Route("admin")]
    public class AdminController : ControllerBase
    {
        DatabaseConnector connector;
        public AdminController(DatabaseConnector connector)
        {
            this.connector = connector;
        }

        [HttpGet("health")]
        public IActionResult HealthCheck()
        {
            return Ok();
        }

        [HttpPatch("ensuredbcreated")]
        public bool DatabaseCreated()
        {
            return connector.Database.EnsureCreated();
        }
    }
}
