﻿namespace MDP.Models.Artifacts
{
    using MDP.Models.Accessory;
    using MySql.Data.MySqlClient;
    using System;
    using System.Collections.Generic;

    public class Artifact : IQueryable<Artifact>
    {
        public int Id { get; set; }
        public string ShortName { get; set; }
        public string FullName { get; set; }
        public List<string> OtherNames { get; set; }
        public string Description { get; set; }
        public Accessory Media { get; set; }
        public List<Accessory> Categories { get; set; }
        public List<Accessory> TargetDemographics { get; set; }
        public Accessory AgeRating { get; set; }
        public string CardImgUrl { get; set; }
        public string MainImgUrl { get; set; }
        public List<string> OtherImgUrls { get; set; }
        public string MainParticipantRole { get; set; }
        public string MainParticipant { get; set; }
        public double AverageRating { get; set; }
        public DateTime? ReleaseDate { get; set; }

        /// <summary>
        /// Cria um Artifact com id, shortName, fullName, description e releaseDate.
        /// </summary>
        /// <param name="reader"></param>
        /// <returns></returns>
        public static Artifact FromQuery(MySqlDataReader reader)
        {
            Artifact artifact = new Artifact();
            try
            {
                artifact.Id = reader.GetInt32("id");
            }
            catch (Exception ex)
            {
                Console.WriteLine("id column not found");
            }
            try
            {
                artifact.ShortName = reader.GetString("shortName");
            }
            catch (Exception ex)
            {
                Console.WriteLine("shortName column not found");
            }
            try
            {
                artifact.FullName = reader.GetString("fullName");
            }
            catch (Exception ex)
            {
                Console.WriteLine("fullName column not found");
            }
            try
            {
                artifact.Description = reader.GetString("description");
            }
            catch (Exception ex)
            {
                Console.WriteLine("description column not found");
            }
            try
            {
                artifact.MainParticipant = reader.GetString("mainParticipant");
            }
            catch (Exception ex)
            {
                Console.WriteLine("mainParticipant column not found");
            }
            try
            {
                artifact.ReleaseDate = reader.GetDateTime("releaseDate");
            }
            catch (Exception ex)
            {
                Console.WriteLine("releaseDate column not found");
            }
            return artifact;
        }

        /// <summary>
        /// Cria o targetDemographics e o popula. Passar o reader direto da query, sem chamar Read().
        /// </summary>
        /// <param name="reader"></param>
        public void SetDemographics(MySqlDataReader reader)
        {
            try
            {
                this.TargetDemographics = [];
                while (reader.Read())
                {
                    try
                    {
                        TargetDemographics.Add(Accessory.FromQuery(reader));   
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"demographic name column not found for artifact {Id}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reader could not be closed");
            }
        }

        /// <summary>
        /// Cria o categories e o popula. Passar o reader direto da query, sem chamar Read()
        /// </summary>
        /// <param name="reader"></param>
        public void SetCategories(MySqlDataReader reader)
        {
            try
            {
                this.Categories = [];
                while (reader.Read())
                {
                    try
                    {
                        this.Categories.Add(Accessory.FromQuery(reader));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine($"category name column not found for artifact {Id}");
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Reader could not be closed");
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Passar o reader direto da query, sem chamar Read()
        /// </summary>
        /// <param name="reader"></param>
        public void SetAgeRating(MySqlDataReader reader)
        {
            try
            {
                reader.Read();
                this.AgeRating = Accessory.FromQuery(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Passar o reader direto da query, sem chamar Read()
        /// </summary>
        /// <param name="reader"></param>
        public void SetMedia(MySqlDataReader reader)
        {
            try
            {
                reader.Read();
                this.Media = Accessory.FromQuery(reader);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Passar o reader direto da query, sem chamar Read()
        /// </summary>
        /// <param name="reader"></param>
        public void SetMainParticipantRole(MySqlDataReader reader)
        {
            try
            {
                reader.Read();
                this.MainParticipantRole = reader.GetString("name");
            } catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Passar o reader direto da query, sem chamar Read()
        /// </summary>
        /// <param name="reader"></param>
        public void SetImageUrls(MySqlDataReader reader)
        {
            try
            {
                this.OtherImgUrls = new List<string>();
                while (reader.Read())
                {
                    try
                    {
                        switch (reader.GetInt32("type"))
                        {
                            case (int)ImageTypes.CardImage:
                                this.CardImgUrl = reader.GetString("url");
                                break;
                            case (int)ImageTypes.MainImage:
                                this.MainImgUrl = reader.GetString("url");
                                break;
                            case (int)ImageTypes.OtherImage:
                                this.OtherImgUrls.Add(reader.GetString("url"));
                                break;
                        }
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }            
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        /// <summary>
        /// Passar reader sem chamar Read(). Espera uma coluna chamada average.
        /// </summary>
        /// <param name="reader"></param>
        public void SetAverageRating(MySqlDataReader reader)
        {
            try
            {
                reader.Read();
                this.AverageRating = reader.GetDouble("average");
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }

        public void SetOtherNames(MySqlDataReader reader)
        {
            try
            {
                this.OtherNames = new List<string>();
                while (reader.Read())
                {
                    try
                    {
                        this.OtherNames.Add(reader.GetString("name"));
                    }
                    catch (Exception ex)
                    {
                        Console.WriteLine(ex);
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex);
            }
        }
    }
}
