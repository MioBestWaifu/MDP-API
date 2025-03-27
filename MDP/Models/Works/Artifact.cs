using MDP.Models.Accessory;
using MDP.Models.Companies;
using MDP.Models.Persons;
using MySql.Data.MySqlClient;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace MDP.Models.Works
{
    public class Artifact : IEntity
    {
        public int Id { get; set; }
        public Name ShortName { get; set; }
        public Name FullName { get; set; }
        public List<Name>? OtherNames { get; set; }
        public string? Description { get; set; }
        [Required]
        public Media Media { get; set; }
        [Required]
        public List<Category> Categories { get; set; }
        public List<Demographic>? TargetDemographics { get; set; }
        public AgeRating AgeRating { get; set; }
        public Image? CardImage { get; set; }
        public Image? MainImage { get; set; }
        public List<Image>? OtherImages { get; set; }
        public double AverageRating { get; set; }
        public DateOnly? ReleaseDate { get; set; }

        public static Artifact CloneArtifact(Artifact original)
        {
            return new Artifact
            {
                ShortName = new Name { Literal = original.ShortName.Literal },
                FullName = new Name { Literal = original.FullName.Literal },
                Description = original.Description,
                Media = original.Media,
                Categories = original.Categories.ToList(),
                TargetDemographics = original.TargetDemographics?.ToList(),
                AgeRating = original.AgeRating,
                CardImage = original.CardImage != null ? new Image { Content = original.CardImage.Content, Type = original.CardImage.Type } : null,
                MainImage = original.MainImage != null ? new Image { Content = original.MainImage.Content, Type = original.MainImage.Type } : null,
                AverageRating = original.AverageRating,
                ReleaseDate = original.ReleaseDate
            };
        }

    }
}
