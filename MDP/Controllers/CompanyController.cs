using MDP.Data;
using MDP.Handlers;
using MDP.Handlers.Companies;
using MDP.Handlers.Participations;
using MDP.Handlers.Persons;
using MDP.Models.Companies;
using MDP.Models.Persons;
using Microsoft.AspNetCore.Mvc;

namespace MDP.Controllers
{
    [ApiController]
    [Route("companies")]
    public class CompanyController : CrudController<Company, CompanyInsert>
    {
        private readonly DatabaseConnector conn;
        public CompanyController(DatabaseConnector conn) : base(conn, new CompanyRequestHandler(conn))
        {
            this.conn = conn;
        }

        [HttpGet("participations")]
        public List<CompanyParticipation> GetParticipations(int id)
        {
            return new CompanyParticipationHandler(conn).GetFromCompany(id).Result;
        }

        [HttpGet("search")]
        public List<Company> Search(string query)
        {
            return new CompanyRequestHandler(conn).HandleSearch(query).Result;
        }
    }
}
