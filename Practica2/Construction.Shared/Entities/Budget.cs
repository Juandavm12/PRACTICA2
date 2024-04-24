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
    public class Budget
    {
        //Attributes

        public int Id { get; set; }

        [Display(Name = "Presupuesto equipo de construccion ")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public double BudgetConstructionTeam { get; set; }

        [Display(Name = "Presupuesto de tareas ")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public double BudgetDutie { get; set; }

        [Display(Name = "Presupuesto de maquinaria ")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public double BudgetEquipment { get; set; }

        [Display(Name = "Presupuesto proyecto de construccion ")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public double BudgetProyectConstruction { get; set; }

        [Display(Name = "Presupuesto total ")]
        [Required(ErrorMessage = "El campo {0} es obligatorio")]
        public double BudgetTotal { get; set; }

        public string Remarks { get; set; }


        //object creation to assign FK in the database


        [ForeignKey("ProjectConstructionsId")]
        [JsonIgnore]
        public ProjectConstruction ProjectConstructions { get; set; }
        public int? ProjectConstructionsId { get; set; }

    }
}
