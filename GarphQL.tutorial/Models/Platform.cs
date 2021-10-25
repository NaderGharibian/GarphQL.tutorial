using HotChocolate;

using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel.DataAnnotations;

namespace GarphQL.tutorial.Models
{
    //[GraphQLDescription("Represents any software or service that has a command line interface.")]
    public class Platform
    {
        public Platform()
        {
            Commands = new HashSet<Command>();
        }
        [Key]
        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
      //  [GraphQLDescription("Represents a purchast , valid license for the platform")]
        public string LicenseKey { get; set; }
        public virtual ICollection<Command> Commands { get; set; }
    }
}
