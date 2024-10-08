﻿using MDP.Data;
using MDP.Models;
using MDP.Models.Accessory;
using MDP.Models.Companies;
using MDP.Models.Information;
using MDP.Models.Persons;
using MDP.Models.Users;
using MDP.Models.Works;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

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
                ];
            connector.Categories.AddRange(categories);

            List<Demographic> demographics = [
                new Demographic { Name = "Shonen" },
                new Demographic { Name = "Shoujo" },
                new Demographic { Name = "Chads" },
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
                    Url = "assets/imgs/users/1main.png",
                    Type = ImageType.MainImage
                },
                Country = country,
                Description = "Just a regular guy",
                Birthday = new DateTime(1990, 1, 1),
                Gender = Gender.Male
            };
            connector.Users.Add(user);
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
                    Url = "assets/imgs/companies/1main.png",
                    Type = ImageType.MainImage
                },
                CardImage = new Image
                {
                    Url = "assets/imgs/companies/1card.png",
                    Type = ImageType.CardImage
                },
                FoundingDate = new DateTime(2007,4,1)
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
                    Url = "assets/imgs/persons/1card.png",
                    Type = ImageType.CardImage
                },
                MainImage = new Image
                {
                    Url = "assets/imgs/persons/1main.png",
                    Type = ImageType.MainImage
                },
                Country = country,
                Roles = [
                    roles[0]
                ],
                Description = "Sweetest voice in Japan. In the world, actually. I fucking love her.",
                Gender = Gender.Female,
                Birthday = new DateTime(1994, 02, 27)
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
                CardImage = new() { Url = "assets/imgs/works/1card.png", Type = ImageType.CardImage },
                MainImage = new() { Url = "assets/imgs/works/1main.png", Type = ImageType.MainImage },
                AverageRating = 4.5,
                ReleaseDate = new DateTime(2016, 4, 4)
            };
            connector.Artifacts.Add(artifact);
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
                Start = new DateTime(2013, 4, 4)
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
                            Url = "assets/imgs/news/1main.png",
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
                            Url = "assets/imgs/news/2main.png",
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
                            Url = "assets/imgs/news/3main.png",
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
                                Url = "assets/imgs/news/4main.png",
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
                                Url = "assets/imgs/news/5main.png",
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
                                Url = "assets/imgs/news/6main.png",
                                Type = ImageType.MainImage
                            }
                            ]
                    }
                }
                ];
            
            connector.GlobalNews.AddRange(globalNews);
            connector.SaveChanges();

            return true;
        }
    }
}
