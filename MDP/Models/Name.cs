using MDP.Models.Persons;
using MDP.Models.Works;
using Microsoft.AspNetCore.Mvc.ModelBinding.Validation;
using System.Text.Json.Serialization;

namespace MDP.Models
{
    public class Name
    {
        public int Id { get; set; }
        public string Literal { get; set; }
    }
}
