using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KFC_MGMT.Models.Forms.Car
{
    public class AddCarForm : Attribute
    {

        [Display(Name = "Numéro de chassis")]
        [Required]
        [MinLength(2)]
        public string ChassisNumber { get; set; }

        [Required]
        [Display(Name = "Nom du modèle")]
        public string ModelName { get; set; }
        public IEnumerable<SelectListItem> ModelList { get; set; }

        [Display(Name = "Version")]
        [Required]
        [MinLength(2)]
        public string Version { get; set; }

        [Display(Name = "Année")]
        [Required]
        [DataType(DataType.Date)]
        public DateTime Year { get; set; }

        [Display(Name = "Type de chassis")]
        [Required]
        [MinLength(2)]
        public string ChassisType { get; set; }

        [Display(Name = "Etat")]
        [Required]
        [MinLength(2)]
        public string Condition { get; set; }

        [Display(Name = "Kilomètrage")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Nombre positif")]
        public int Mileage { get; set; }

        [Display(Name = "Puissance")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Nombre positif")]
        public int Power { get; set; }

        [Display(Name = "Cylindrée")]
        [Required]
        [Range(1, int.MaxValue, ErrorMessage = "Nombre positif")]
        public int Cylinder { get; set; }

        [Display(Name = "Localisation")]
        [Required]
        [MinLength(2)]
        public string Location { get; set; }

        [Display(Name = "Carburant")]
        [Required]
        [MinLength(2)]
        public string Fuel { get; set; }

        [Display(Name = "Transmission")]
        [Required]
        [MinLength(2)]
        public string Transmition { get; set; }
       
        [Display(Name = "Couleur")]
        [Required]
        [MinLength(2)]
        public string Color { get; set; }

        [Display(Name = "Peinture métallisée")]
        [Required]
        public bool MetalPainting { get; set; }

        [Display(Name = "Carnet d'entretien")]
        [Required]
        public bool ServiceBook { get; set; }

        [Display(Name = "Volant à gauche")]
        [Required]
        public bool LeftHand { get; set; }
        
    }
}