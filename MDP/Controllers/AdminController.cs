using MDP.Data;
using MDP.Models;
using MDP.Models.Accessory;
using MDP.Models.Companies;
using MDP.Models.Information;
using MDP.Models.Persons;
using MDP.Models.Recommendation;
using MDP.Models.Users;
using MDP.Models.Works;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System.Security.Cryptography.X509Certificates;

namespace MDP.Controllers
{
    [ApiController]
    [Route("admin")]
    public class AdminController : ControllerBase
    {
        DatabaseConnector connector;
        public AdminController(DatabaseConnector connector)
        {
            this.connector = connector;
        }

        [HttpGet("health")]
        public IActionResult HealthCheck()
        {
            return Ok();
        }

        [HttpPatch("createdb")]
        public bool CreateDb()
        {
            return connector.Database.EnsureCreated();
        }

        [HttpPatch("deletedb")]
        public bool DeleteDb()
        {
            return connector.Database.EnsureDeleted();
        }

        [HttpPatch("initmocks")]
        public bool InitializeMocks()
        {
            List<AgeRating> ageRatings = [
                new AgeRating { Name = "E - Everyone" },
                new AgeRating { Name = "T - Teen" },
                new AgeRating { Name = "M - Mature" },
                ];
            connector.AgeRatings.AddRange(ageRatings);

            List<Media> medias = [
                new Media { Name = "Anime" },
                new Media { Name = "Manga" },
                new Media { Name = "Light Novel" },
                ];
            connector.Medias.AddRange(medias);

            List<Category> categories = [
                new Category { Name = "Isekai" },
                new Category { Name = "Drama" },
                new Category { Name = "Hentai" },
                new Category { Name = "Slice of Life" },
                new Category { Name = "Battle" },
                ];
            connector.Categories.AddRange(categories);

            List<Demographic> demographics = [
                new Demographic { Name = "Shonen" },
                new Demographic { Name = "Shoujo" },
                new Demographic { Name = "Chads" },
                new Demographic { Name = "Gooners" },
                new Demographic { Name = "Weebs" },
                ];
            connector.Demographics.AddRange(demographics);

            List<Role> roles = [
                new Role {
                    Name = "Voice actor"
                },
                new Role {
                    Name = "Studio"
                }
                ];

            connector.SaveChanges();
            Country country = new Country
            {
                Name = "Japan",
                Code = "JPN"
            };

            var brazil = new Country
            {
                Name = "Brazil",
                Code = "BRA"
            };

            User user = new User
            {
                Email = "user@example.com",
                Password = "password",
                ShortName = new Name
                {
                    Literal = "Onani"
                },
                MainImage = new Image
                {
                    Content = "assets/imgs/users/1main.png",
                    Type = ImageType.MainImage
                },
                Country = country,
                Description = "Just a regular guy",
                Birthday = new DateOnly(1990, 1, 1),
                Gender = Gender.Male
            };
            connector.Users.Add(user);
            connector.Countries.Add(brazil);
            connector.SaveChanges();

            Company company = new Company
            {
                ShortName = new Name
                {
                    Literal = "White Fox"
                },
                FullName = new Name
                {
                    Literal = "White Fox Co., Ltd"
                },
                Description = "A good fucking studio",
                Country = country,
                Roles = [
                    roles[1]
                    ],
                MainImage = new Image
                {
                    Content = "assets/imgs/companies/1main.png",
                    Type = ImageType.MainImage
                },
                CardImage = new Image
                {
                    Content = "assets/imgs/companies/1card.png",
                    Type = ImageType.CardImage
                },
                FoundingDate = new DateOnly(2007,4,1)
            };
            connector.Companies.Add(company);
            connector.SaveChanges();

            Person person = new Person
            {
                ShortName = new Name { Literal = "Takahashi Rie" },
                FullName = new Name { Literal = "Takahashi Rie" },
                Nicknames = [new Name { Literal = "Rieri" }],
                CardImage = new Image
                {
                    Content = "assets/imgs/persons/1card.png",
                    Type = ImageType.CardImage
                },
                MainImage = new Image
                {
                    Content = "assets/imgs/persons/1main.png",
                    Type = ImageType.MainImage
                },
                Country = country,
                Roles = [
                    roles[0]
                ],
                Description = "Sweetest voice in Japan. In the world, actually. I fucking love her.",
                Gender = Gender.Female,
                Birthday = new DateOnly(1994, 02, 27)
            };
            connector.People.Add(person);
            connector.SaveChanges();

            Artifact artifact = new()
            {
                ShortName = new() { Literal = "Re:zero" },
                FullName = new() { Literal = "Re:zero kara hajimeru isekai seikatsu" },
                Description = "Guy gets kidnapped to another world, dies many times for elf girl and her egirl servant",
                Media = medias[0],
                Categories = [categories[0], categories[1]],
                TargetDemographics = [demographics[2]],
                AgeRating = ageRatings[1],
                CardImage = new() { Content = "assets/imgs/works/1card.png", Type = ImageType.CardImage },
                MainImage = new() { Content = "assets/imgs/works/1main.png", Type = ImageType.MainImage },
                AverageRating = 4.5,
                ReleaseDate = new DateOnly(2016, 4, 4)
            };

            var otherArtifacts = new List<Artifact> {
                new Artifact {
                    ShortName = new() { Literal = "Fate/stay night UBW" },
                    FullName = new() { Literal = "Fate/stay night: Unlimited Blade Works" },
                    Description = "Guy invokes great waifu from the past to fight other heroes for no good reason",
                    Media = medias[0],
                    Categories = [categories[4]],
                    TargetDemographics = [demographics[0]],
                    AgeRating = ageRatings[1],
                    CardImage = new() { Content = "assets/imgs/works/2card.png", Type = ImageType.CardImage },
                    MainImage = new() { Content = "assets/imgs/works/2main.png", Type = ImageType.MainImage },
                    AverageRating = 9,
                    ReleaseDate = new DateOnly(2015, 1, 1)
                },
                new Artifact {
                    ShortName = new() { Literal = "Yagate Kimi ni Naru" },
                    FullName = new() { Literal = "Yagate Kimi ni Naru" },
                    Description = "Traumatized depressive girl and horny girl doing lesbianism",
                    Media = medias[0],
                    Categories = [categories[1]],
                    TargetDemographics = [demographics[1]],
                    AgeRating = ageRatings[1],
                    CardImage = new() { Content = "assets/imgs/works/3card.png", Type = ImageType.CardImage },
                    MainImage = new() { Content = "assets/imgs/works/3main.png", Type = ImageType.MainImage },
                    AverageRating = 9,
                    ReleaseDate = new DateOnly(2017, 1, 1)
                },
                new Artifact {
                    ShortName = new() { Literal = "Kiss x Sis" },
                    FullName = new() { Literal = "Kiss x Sis" },
                    Description = "Some overly close step-sibilings",
                    Media = medias[0],
                    Categories = [categories[2]],
                    TargetDemographics = [demographics[3]],
                    AgeRating = ageRatings[2],
                    CardImage = new() { Content = "assets/imgs/works/4card.png", Type = ImageType.CardImage },
                    MainImage = new() { Content = "assets/imgs/works/4main.png", Type = ImageType.MainImage },
                    AverageRating = 9,
                    ReleaseDate = new DateOnly(2018, 1, 1)
                },
                new Artifact {
                    ShortName = new() { Literal = "K-On" },
                    FullName = new() { Literal = "K-On" },
                    Description = "Cute music girls doing everything but music",
                    Media = medias[0],
                    Categories = [categories[3]],
                    TargetDemographics = [demographics[4]],
                    AgeRating = ageRatings[0],
                    CardImage = new() { Content = "assets/imgs/works/5card.png", Type = ImageType.CardImage },
                    MainImage = new() { Content = "assets/imgs/works/5main.png", Type = ImageType.MainImage },
                    AverageRating = 9,
                    ReleaseDate = new DateOnly(2019, 1, 1)
                }
            };
            connector.Artifacts.Add(artifact);
            connector.SaveChanges();

            for (int i = 0; i < 19; i++)
            {
                connector.Artifacts.Add(Artifact.CloneArtifact(artifact));
                foreach (var other in otherArtifacts)
                {
                    connector.Artifacts.Add(Artifact.CloneArtifact(other));
                }
            }

            
            connector.SaveChanges();

            PersonParticipation personParticipation = new()
            {
                Participant = person,
                Artifact = artifact,
                Roles = [roles[0]],
                AdditionalInformation = "Emilia"
            };

            CompanyParticipation companyParticipation = new()
            {
                Participant = company,
                Artifact = artifact,
                Roles = [roles[1]]
            };

            CompanyPerson companyPerson = new()
            {
                Company = company,
                Person = person,
                Start = new DateOnly(2013, 4, 4)
            };

            connector.PersonParticipations.Add(personParticipation);
            connector.CompanyParticipations.Add(companyParticipation);
            connector.CompanyPeople.Add(companyPerson);
            connector.SaveChanges();

            List<WorkNews> workNews = [
                new WorkNews(){ ArtifactId = 1,
                News = new News(){
                    Title = "Season 3 Coming!",
                    Content = "Re:zero season 3 is coming soon! Get ready for more suffering!",
                    Date = new DateTime(2023, 1, 1),
                    Images = new List<Image>(){
                        new Image(){
                            Content = "assets/imgs/news/1main.png",
                            Type = ImageType.MainImage
                        },
                    }
                } },new WorkNews(){ ArtifactId = 1,
                News = new News(){
                    Title = "Another Rezero news",
                    Content = "But i dont have crativity to describe it!",
                    Date = new DateTime(2023, 1, 1),
                    Images = new List<Image>(){
                        new Image(){
                            Content = "assets/imgs/news/2main.png",
                            Type = ImageType.MainImage
                        },
                    }
                } },new WorkNews(){ ArtifactId = 1,
                News = new News(){
                    Title = "Another one!",
                    Content = "This time with a larger text, very much larger, full of words, to test the dispositions of actual news into the UI. Did you know that the samurai never fought with swords? Yep, for the time between 800s-1500s, the samurai fought with spears and bows, often on horseback. In later periods, notably in the late Sengoku Jidai (1467-1615) and the entirety of the Tokugawa Shogunate (1603-1868) warfare in Japan was actually quite similar to 17th century Europe, they killed each other with muskets and cannons. The myth of the sword-fighting samurai derives from later revision. The samurai, like their western knight counterpart, did have swords, but they were cerimonial, a symbol of authority, not to be used in an actual combat. Just like in the west, this fact was glossed over, because swords are fucking cool.",
                    Date = new DateTime(2023, 1, 1),
                    Images = new List<Image>(){
                        new Image(){
                            Content = "assets/imgs/news/3main.png",
                            Type = ImageType.MainImage
                        },
                    }
                } },
                ];

            connector.WorkNews.AddRange(workNews);
            connector.SaveChanges();

            List<GlobalNews> globalNews = [
                new GlobalNews{
                    News = new News(){
                        Title ="Carousel test 1!",
                        Content = "Does he know?",
                        Images = [
                            new Image {
                                Content = "assets/imgs/news/4main.png",
                                Type = ImageType.MainImage
                            }
                            ]
                    }
                },new GlobalNews{
                    News = new News(){
                        Title ="Carousel test 2!",
                        Content = "He Doesnt know.",
                        Images = [
                            new Image {
                                Content = "assets/imgs/news/5main.png",
                                Type = ImageType.MainImage
                            }
                            ]
                    }
                },new GlobalNews{
                    News = new News(){
                        Title ="Carousel test 3!",
                        Content = "HE KNOWS!",
                        Images = [
                            new Image {
                                Content = "assets/imgs/news/6main.png",
                                Type = ImageType.MainImage
                            }
                            ]
                    }
                }
            ];

            var demoAges = new List<DemoAge> { 
                new DemoAge { Demographic = demographics[0], RangeStart = 9, RangeEnd = 17, Weight = 0.4 },
                new DemoAge { Demographic = demographics[1], RangeStart = 12, RangeEnd = 20, Weight = 0.5 },
                new DemoAge { Demographic = demographics[2], RangeStart = 18, RangeEnd = 45, Weight = 0.5 },
            };

            var demoGenders = new List<DemoGender>
            {
                new DemoGender {Demographic = demographics[0], Gender = Gender.Male, Weight = 0.1},
                new DemoGender {Demographic = demographics[1], Gender = Gender.Female, Weight = 0.2 },
            };

            var demoCountries = new List<DemoCountry>
            {
                new DemoCountry {Demographic = demographics[4], Country = brazil, Weight = 0.3},
            };

            var demoCats = new List<DemoCat>
            {
                new DemoCat {Demographic = demographics[2], Category = categories[3], Weight = 0.7},
                new DemoCat {Demographic = demographics[3], Category = categories[2], Weight = 0.9},
            };
            
            connector.GlobalNews.AddRange(globalNews);
            connector.DemoAges.AddRange(demoAges);
            connector.DemoGenders.AddRange(demoGenders);
            connector.DemoCountrys.AddRange(demoCountries);
            connector.DemoCats.AddRange(demoCats);
            connector.SaveChanges();

            return true;
        }
    }
}
