using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KFC_MGMT.Models.Forms.Car
{
    public class DeleteCarForm : Attribute
    {
        [HiddenInput(DisplayValue = false)]
        [Key]
        public int IdCar { get; set; }

        [Display(Name = "Numéro de chassis")]
        [MinLength(2)]
        public string ChassisNumber { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int IdModel { get; set; }

        [Display(Name = "Nom du modèle")]
        [MinLength(2)]
        public string ModelName { get; set; }

        [Display(Name = "Version")]
        [MinLength(2)]
        public string Version { get; set; }

        [Display(Name = "Année")]
        [DataType(DataType.Date)]
        public DateTime Year { get; set; }

        [Display(Name = "Type")]
        [MinLength(2)]
        public string ChassisType { get; set; }
        
        [Display(Name = "Kilom.")]
        public int Mileage { get; set; }

        [Display(Name = "Localisation")]
        [MinLength(2)]
        public string Location { get; set; }
        
    }
}