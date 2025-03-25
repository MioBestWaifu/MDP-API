using MDP.Data;
using MDP.Handlers.Participations;
using MDP.Handlers.Work;
using MDP.Models.Companies;
using MDP.Models.Persons;
using MDP.Models.Works;
using Microsoft.AspNetCore.Mvc;

namespace MDP.Controllers
{
    [ApiController]
    [Route("works")]
    public class WorkController : CrudController<Artifact,ArtifactInsert>
    {

        private readonly DatabaseConnector conn;

        public WorkController(DatabaseConnector conn) : base(conn, new WorkRequestHandler(conn))
        {
            this.conn = conn;
        }

        [HttpGet("{id}/people")]
        public List<PersonParticipation> GetParticipantPeople(int id)
        {
            return new PersonParticipationHandler(conn).GetFromArtifact(id).Result;
        }

        [HttpPatch("{id}/people")]
        public List<PersonParticipation> UpdatePersonParticipations(int id,List<PersonParticipation> participations)
        {
            return new PersonParticipationHandler(conn).UpdateArtifact(id,participations.Where(x => x.Artifact.Id == id).ToList()).Result;
        }

        [HttpGet("{id}/companies")]
        public List<CompanyParticipation> GetParticipantCopmanies(int id)
        {
            return new CompanyParticipationHandler(conn).GetFromArtifact(id).Result;
        }

        [HttpPatch("{id}/companies")]
        public List<CompanyParticipation> UpdateCompanyParticipations(int id, List<CompanyParticipation> participations)
        {
            return new CompanyParticipationHandler(conn).UpdateArtifact(id, participations.Where(x => x.Artifact.Id == id).ToList()).Result;
        }
    }
}
