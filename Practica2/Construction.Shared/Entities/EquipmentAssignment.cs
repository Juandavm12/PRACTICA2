using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Construction.Shared.Entities
{
    public class EquipmentAssignment
    {
        //Attributes
        public int Id { get; set; }


        //object creation to assign FK in the database

        [ForeignKey("ConstructionTeamsId")]     
        [JsonIgnore]
        public ConstructionTeam ConstructionTeams { get; set; }
        public int? ConstructionTeamsId { get; set; }

        //object creation to assign FK in the database       

        [ForeignKey("ProjectConstructionsId")]
        [JsonIgnore]
        public ProjectConstruction ProjectConstructions { get; set; }
        public int? ProjectConstructionsId { get; set; }
    }
}
