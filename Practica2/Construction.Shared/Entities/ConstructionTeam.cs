using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace Construction.Shared.Entities
{
    public class ConstructionTeam
    {
        //Attributes

        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(20, ErrorMessage = "No se permiten mas de 20 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }

        [Display(Name = "Especialidades")]
        [MaxLength(100, ErrorMessage = "No se permiten mas de 100 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Specialties { get; set; }

        [Display(Name = "Lista de miembros")]
        [MaxLength(50, ErrorMessage = "No se permiten mas de 50 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string MembersList { get; set; }

        public string Remarks { get; set; }

        //Reference to M*M table
        [JsonIgnore]
        public ICollection<EquipmentAssignment> EquipmentAssignments { get; set; }

    }
}
