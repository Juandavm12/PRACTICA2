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
    public class Equipment
    {

        //Attributes

        public int Id { get; set; }

        [Display(Name = "Nombre")]
        [MaxLength(20, ErrorMessage = "No se permiten mas de 20 caracteres")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public string Name { get; set; }


        [Display(Name = "Capacidad")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 caracteres")]
        [Required(ErrorMessage = "El campo  {0} es obligatorio")]

        public string Capacity { get; set; }

        [Display(Name = "Estado de mantenimiento")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 caracteres")]
        [Required(ErrorMessage = "El campo  {0} es obligatorio")]

        public string MaintenanceState { get; set; }


      

        [Display(Name = "Disponibilidad")]
        [MaxLength(50, ErrorMessage = "No se permiten más de 50 caracteres")]
        [Required(ErrorMessage = "El campo  {0} es obligatorio")]

        public string Availability { get; set; }


        public string Remarks { get; set; }


        //object creation to assign FK in the database

        [ForeignKey("ProjectConstructionsId")]
        [JsonIgnore]
        public ProjectConstruction ProjectConstructions { get; set; }
        public int? ProjectConstructionsId { get; set; }


        [ForeignKey("DutiesId")]
        [JsonIgnore]
        public Dutie Duties { get; set; }
        public int? DutiesId { get; set; }

    }
}

