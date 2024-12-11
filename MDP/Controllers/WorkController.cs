using MDP.Data;
using MDP.Handlers.Work;
using MDP.Models.Works;
using Microsoft.AspNetCore.Mvc;

namespace MDP.Controllers
{
    [ApiController]
    [Route("works")]
    public class WorkController : CrudController<Artifact,ArtifactInsert>
    {
        public WorkController(DatabaseConnector conn) : base(conn, new WorkRequestHandler(conn))
        {
        }
    }
}
