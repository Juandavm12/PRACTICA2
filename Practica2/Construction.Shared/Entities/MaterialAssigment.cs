using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Construction.Shared.Entities
{
    public class MaterialAssigment
    {

        //Attributes
        public int Id { get; set; }

        //object creation to assign FK in the database
        public Material Materials { get; set; }

        //object creation to assign FK in the database
        public Dutie Duties { get; set; }
    }
}
