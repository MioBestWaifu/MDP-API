using MDP.Data;
using MDP.Handlers.Participations;
using MDP.Handlers.Persons;
using MDP.Models.Companies;
using MDP.Models.Persons;
using Microsoft.AspNetCore.Mvc;

namespace MDP.Controllers
{
    [ApiController]
    [Route("people")]
    public class PeopleController : CrudController<Person, PersonInsert>
    {

        private readonly DatabaseConnector conn;
        public PeopleController(DatabaseConnector conn) : base(conn, new PersonRequestHandler(conn))
        {
            this.conn = conn;
        }

        [HttpGet("participations")]
        public List<PersonParticipation> GetParticipations(int id)
        {
            return new PersonParticipationHandler(conn).GetArtifactsFromPerson(id).Result;
        }

        [HttpGet("search")]
        public List<Person> Search(string query)
        {
            return new PersonRequestHandler(conn).HandleSearch(query).Result;
        }

        [HttpGet("{id}/companies")]
        public List<CompanyPerson> GetParticipatedCompanies(int id)
        {
            return new PersonParticipationHandler(conn).GetCompaniesFromPerson(id).Result;
        }

        [HttpPatch("{id}/companies")]
        public List<CompanyPerson> UpdateParticipatedCompanies(int id, List<CompanyPerson> participations)
        {
            return new PersonParticipationHandler(conn).UpdatePerson(id, participations.Where(x => x.Person.Id == id).ToList()).Result;
        }

        [HttpGet("{id}/works")]
        public List<PersonParticipation> GetParticipatedArtifacts(int id)
        {
            return new PersonParticipationHandler(conn).GetArtifactsFromPerson(id).Result;
        }

        [HttpPatch("{id}/works")]
        public List<PersonParticipation> UpdateParticipatedWorks(int id, List<PersonParticipation> participations)
        {
            return new PersonParticipationHandler(conn).UpdatePerson(id, participations.Where(x => x.Participant.Id == id).ToList()).Result;
        }
    }
}
