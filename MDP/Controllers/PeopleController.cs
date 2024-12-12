using MDP.Data;
using MDP.Handlers.Persons;
using MDP.Models.Persons;
using Microsoft.AspNetCore.Mvc;

namespace MDP.Controllers
{
    [ApiController]
    [Route("people")]
    public class PeopleController : CrudController<Person, PersonInsert>
    {
        public PeopleController(DatabaseConnector conn) : base(conn, new PersonRequestHandler(conn))
        {
        }
    }
}
