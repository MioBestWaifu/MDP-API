using MDP.Data;
using MDP.Handlers;
using MDP.Handlers.Companies;
using MDP.Models.Companies;
using Microsoft.AspNetCore.Mvc;

namespace MDP.Controllers
{
    [ApiController]
    [Route("companies")]
    public class CompanyController : CrudController<Company, CompanyInsert>
    {
        public CompanyController(DatabaseConnector conn) : base(conn, new CompanyRequestHandler(conn))
        {
        }
    }
}
