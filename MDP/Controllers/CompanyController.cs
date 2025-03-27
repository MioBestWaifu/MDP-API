using MDP.Data;
using MDP.Handlers;
using MDP.Handlers.Companies;
using MDP.Handlers.Participations;
using MDP.Handlers.Persons;
using MDP.Handlers.Work;
using MDP.Models.Companies;
using MDP.Models.Persons;
using MDP.Models.Works;
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

        [HttpGet("{id}/people")]
        public List<CompanyPerson> GetParticipantPeople(int id)
        {
            return new PersonParticipationHandler(conn).GetFromCompany(id).Result;
        }

        [HttpPatch("{id}/people")]
        public List<CompanyPerson> UpdatePersonParticipations(int id, List<CompanyPerson> participations)
        {
            return new PersonParticipationHandler(conn).UpdateCompany(id, participations.Where(x => x.Company.Id == id).ToList()).Result;
        }

        [HttpGet("{id}/works")]
        public List<CompanyParticipation> GetParticipatedArtifacts(int id)
        {
            return new CompanyParticipationHandler(conn).GetFromCompany(id).Result;
        }

        [HttpPatch("{id}/works")]
        public List<CompanyParticipation> UpdateCompanyParticipations(int id, List<CompanyParticipation> participations)
        {
            return new CompanyParticipationHandler(conn).UpdateCompany(id, participations.Where(x => x.Participant.Id == id).ToList()).Result;
        }

        [HttpGet("search")]
        public List<Company> Search(string query)
        {
            return new CompanyRequestHandler(conn).HandleSearch(query).Result;
        }
    }
}
