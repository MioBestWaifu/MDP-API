using MDP.Data;
using MDP.Models.Accessory;
using MDP.Models.Companies;
using MDP.Models.Works;
using Microsoft.EntityFrameworkCore;

namespace MDP.Handlers.Participations
{
    public class CompanyParticipationHandler(DatabaseConnector connector) : Handler(connector)
    {
        public async Task<List<CompanyParticipation>> GetFromArtifact(int artifactId)
        {
            return connector.CompanyParticipations.Include(x => x.Participant)
               .Where(x => x.Artifact.Id == artifactId)
               .Include(x => x.Roles)
               .Include(x => x.Participant.CardImage)
               .Include(x => x.Participant.ShortName)
               .Include(x => x.Participant.FullName)
               .ToList();
        }

        public async Task<List<CompanyParticipation>> GetFromCompany(int companyId)
        {
            return connector.CompanyParticipations.Where(x => x.Participant.Id == companyId)
                .Include(x => x.Participant)
                .ToList();
        }

        public async Task<List<CompanyParticipation>> UpdateArtifact(int artifactId, List<CompanyParticipation> participations)
        {
            foreach (var participation in participations)
            {
                var buffer = participation.Roles;
                participation.Roles = new List<Role>();
                foreach (var role in buffer)
                {
                    participation.Roles.Add(connector.Roles.Find(role.Id));
                }

                participation.Participant = connector.Companies.Find(participation.Participant.Id);
                participation.Artifact = connector.Artifacts.Find(artifactId);
            }

            var toUpdate = participations.Where(x => x.Id >= 1);
            var toInsert = participations.Where(x => x.Id <= 0);

            foreach (var participation in toUpdate)
            {
                var p = connector.CompanyParticipations.Include(x => x.Roles).First(x => x.Id == participation.Id);
                p.Roles.Clear();
                foreach (var role in participation.Roles)
                {
                    p.Roles.Add(role);
                }
                p.Participant = participation.Participant;
                p.Artifact = participation.Artifact;
                p.AdditionalInformation = participation.AdditionalInformation;
            }

            connector.CompanyParticipations.AddRange(toInsert);
            await connector.SaveChangesAsync();
            return participations;
        }
    }
}

