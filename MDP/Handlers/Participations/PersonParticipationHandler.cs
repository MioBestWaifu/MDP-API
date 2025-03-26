using MDP.Data;
using MDP.Models.Accessory;
using MDP.Models.Companies;
using MDP.Models.Persons;
using MDP.Models.Works;
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

        public async Task<List<PersonParticipation>> GetArtifactsFromPerson(int personId)
        {
            return connector.PersonParticipations.Where(x => x.Participant.Id == personId)
                .Include(x => x.Artifact)
                .Include(x => x.Roles)
                .Include(x => x.Artifact.CardImage)
                .Include(x => x.Artifact.ShortName)
                .ToList();
        }

        public async Task<List<CompanyPerson>> GetCompaniesFromPerson(int personId)
        {
            return connector.CompanyPeople.Where(x => x.Person.Id == personId)
                .Include(x => x.Company)
                .ThenInclude(y => y.CardImage)
                .Include(x => x.Company.ShortName)
                .ToList();
        }

        public async Task<List<CompanyPerson>> GetFromCompany(int companyId)
        {
            return connector.CompanyPeople.Where(x => x.Company.Id == companyId)
                .Include(x => x.Person)
                .ThenInclude(y => y.CardImage)
                .Include(x => x.Person.ShortName)
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

            var toUpdateIds = toUpdate.Select(x => x.Id).ToList();

            var toDelete = connector.PersonParticipations
                .Where(x => x.Artifact.Id == artifactId && !toUpdateIds.Contains(x.Id))
                .ToList();
            connector.PersonParticipations.RemoveRange(toDelete);

            connector.PersonParticipations.AddRange(toInsert);
            await connector.SaveChangesAsync();
            return participations;
        }

        public async Task<List<CompanyPerson>> UpdateCompany(int companyId, List<CompanyPerson> participations)
        {
            foreach (var participation in participations)
            {

                participation.Person = connector.People.Find(participation.Person.Id);
                participation.Company = connector.Companies.Find(participation.Company.Id);
            }

            var toUpdate = participations.Where(x => x.Id >= 1);
            var toInsert = participations.Where(x => x.Id <= 0);

            var toUpdateIds = toUpdate.Select(x => x.Id).ToList();

            var toDelete = connector.CompanyPeople
                .Where(x => x.Company.Id == companyId && !toUpdateIds.Contains(x.Id))
                .ToList();
            connector.CompanyPeople.RemoveRange(toDelete);

            connector.CompanyPeople.AddRange(toInsert);
            await connector.SaveChangesAsync();
            return participations;
        }

        public async Task<List<CompanyPerson>> UpdatePerson(int personId, List<CompanyPerson> participations)
        {
            foreach (var participation in participations)
            {

                participation.Person = connector.People.Find(participation.Person.Id);
                participation.Company = connector.Companies.Find(participation.Company.Id);
            }

            var toUpdate = participations.Where(x => x.Id >= 1);
            var toInsert = participations.Where(x => x.Id <= 0);

            var toUpdateIds = toUpdate.Select(x => x.Id).ToList();

            var toDelete = connector.CompanyPeople
                .Where(x => x.Person.Id == personId && !toUpdateIds.Contains(x.Id))
                .ToList();
            connector.CompanyPeople.RemoveRange(toDelete);

            connector.CompanyPeople.AddRange(toInsert);
            await connector.SaveChangesAsync();
            return participations;
        }

        public async Task<List<PersonParticipation>> UpdatePerson(int personId, List<PersonParticipation> participations)
        {
            foreach (var participation in participations)
            {
                var buffer = participation.Roles;
                participation.Roles = new List<Role>();
                foreach (var role in buffer)
                {
                    participation.Roles.Add(connector.Roles.Find(role.Id));
                }

                participation.Participant = connector.People.Find(personId);
                participation.Artifact = connector.Artifacts.Find(participation.Artifact.Id);
            }

            var toUpdate = participations.Where(x => x.Id >= 1);
            var toInsert = participations.Where(x => x.Id <= 0);

            foreach (var participation in toUpdate)
            {
                var p = connector.PersonParticipations.Include(x => x.Roles).First(x => x.Id == participation.Id);
                p.Roles.Clear();
                foreach (var role in participation.Roles)
                {
                    p.Roles.Add(role);
                }
                p.Participant = participation.Participant;
                p.Artifact = participation.Artifact;
                p.AdditionalInformation = participation.AdditionalInformation;
            }

            var toUpdateIds = toUpdate.Select(x => x.Id).ToList();

            var toDelete = connector.PersonParticipations
                .Where(x => x.Participant.Id == personId && !toUpdateIds.Contains(x.Id))
                .ToList();
            connector.PersonParticipations.RemoveRange(toDelete);

            connector.PersonParticipations.AddRange(toInsert);
            await connector.SaveChangesAsync();
            return participations;
        }
    }
}
