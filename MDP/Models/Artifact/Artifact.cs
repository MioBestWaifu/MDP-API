﻿namespace MDP.Models.Artifacts
{
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
        public string Media { get; set; }
        public List<string> Categories { get; set; }
        public List<string> TargetDemographics { get; set; }
        public string AgeRating { get; set; }
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
    }
}
