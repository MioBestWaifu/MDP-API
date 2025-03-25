using MDP.Data;
using MDP.Handlers.Participations;
using MDP.Handlers.Persons;
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
            return new PersonParticipationHandler(conn).GetFromPerson(id).Result;
        }

        [HttpGet("search")]
        public List<Person> Search(string query)
        {
            return new PersonRequestHandler(conn).HandleSearch(query).Result;
        }
    }
}
