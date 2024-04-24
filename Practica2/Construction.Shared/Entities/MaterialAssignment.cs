using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Construction.Shared.Entities
{
    public class MaterialAssignment
    {

        //Attributes
        public int Id { get; set; }

        //object creation to assign FK in the database    
   
        [ForeignKey("MaterialsId")]
        [JsonIgnore]
        public Material Materials { get; set; }
        public int? MaterialsId { get; set; }

        //object creation to assign FK in the database        

        [ForeignKey("DutiesId")]
        [JsonIgnore]
        public Dutie Duties { get; set; }
        public int? DutiesId { get; set; }
    }
}
