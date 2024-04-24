using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Construction.Shared.Entities
{
    public class Material
    {
        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(20, ErrorMessage = "No se permiten mas de 20 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        public double RequiredQuantity { get; set; }

        [Display(Name = "Proveedor")]
        [MaxLength(20, ErrorMessage = "No se permiten mas de 20 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Supplier { get; set; }

        [DisplayFormat(DataFormatString = "{0:yyyy/MM/dd}", ApplyFormatInEditMode = true)]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public DateTime EstimatedDeliveryTime { get; set; }

        //Reference to M*M table
        [JsonIgnore]
        public ICollection<MaterialAssignment> MaterialAssignments { get; set; }


        //object creation to assign FK in the database

        [ForeignKey("ProjectConstructionsId")]
        [JsonIgnore]
        public ProjectConstruction ProjectConstructions { get; set; }
        public int? ProjectConstructionsId { get; set; }



    }
}
