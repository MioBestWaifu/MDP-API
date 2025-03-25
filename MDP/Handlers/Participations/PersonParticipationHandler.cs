using MDP.Data;
using MDP.Models.Accessory;
using MDP.Models.Persons;
using Microsoft.EntityFrameworkCore;

namespace MDP.Handlers.Participations
{
    public class PersonParticipationHandler(DatabaseConnector connector) : Handler(connector)
    {
        public async Task<List<PersonParticipation>> GetFromArtifact(int artifactId)
        {
            return connector.PersonParticipations.Include(x=> x.Participant)
               .Where(x => x.Artifact.Id == artifactId)
               .Include(x => x.Roles)
               .Include(x => x.Participant.CardImage)
               .Include(x => x.Participant.ShortName)
               .Include(x => x.Participant.FullName)
               .ToList();
        }

        public async Task<List<PersonParticipation>> GetFromPerson(int personId)
        {
            return connector.PersonParticipations.Where(x => x.Participant.Id == personId)
                .Include(x => x.Participant)
                .ToList();
        }

        public async Task<List<PersonParticipation>> UpdateArtifact(int artifactId,List<PersonParticipation> participations)
        {
            foreach (var participation in participations) {
                var buffer = participation.Roles;
                participation.Roles = new List<Role>();
                foreach (var role in buffer)
                {
                    participation.Roles.Add(connector.Roles.Find(role.Id));
                }

                participation.Participant = connector.People.Find(participation.Participant.Id);
                participation.Artifact = connector.Artifacts.Find(artifactId);
            }

            var toUpdate = participations.Where(x => x.Id >= 1);
            var toInsert = participations.Where(x => x.Id <= 0);

            foreach (var participation in toUpdate)
            {
                var p = connector.PersonParticipations.Include(x=>x.Roles).First(x=> x.Id == participation.Id);
                p.Roles.Clear();
                foreach (var role in participation.Roles)
                {
                    p.Roles.Add(role);
                }
                p.Participant = participation.Participant;
                p.Artifact = participation.Artifact;
                p.AdditionalInformation = participation.AdditionalInformation;
            }

            connector.PersonParticipations.AddRange(toInsert);
            await connector.SaveChangesAsync();
            return participations;
        }
    }
}
