using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace KFC_MGMT.Models.Forms.Car
{
    public class EditCarForm : Attribute
    {

        [HiddenInput(DisplayValue = false)]
        [Key]
        public int IdCar { get; set; }

        [Display(Name = "Numéro de chassis")]
        [MinLength(2)]
        [Required]
        public string ChassisNumber { get; set; }

        [HiddenInput(DisplayValue = false)]
        public int IdModel { get; set; }

        [Required]
        [Display(Name = "Nom du modèle")]
        public string ModelName { get; set; }
        public IEnumerable<SelectListItem> ModelList { get; set; }

        [Display(Name = "Version")]
        [MinLength(2)]
        [Required]
        public string Version { get; set; }

        [Display(Name = "Année")]
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        [Required]
        public DateTime Year { get; set; }
        
        [Display(Name = "Type")]
        [MinLength(2)]
        [Required]
        public string ChassisType { get; set; }

        [Display(Name = "Etat")]
        [MinLength(2)]
        [Required]
        public string Condition { get; set; }

        [Display(Name = "Kilom.")]
        [Required]
        public int Mileage { get; set; }

        [Display(Name = "Puissance")]
        [Required]
        public int Power { get; set; }

        [Display(Name = "Cylindrée")]
        [Required]
        public int Cylinder { get; set; }

        [Display(Name = "Localisation")]
        [MinLength(2)]
        [Required]
        public string Location { get; set; }

        [Display(Name = "Carburant")]
        [MinLength(2)]
        [Required]
        public string Fuel { get; set; }

        [Display(Name = "Transmission")]
        [MinLength(2)]
        [Required]
        public string Transmition { get; set; }
       
        [Display(Name = "Couleur")]
        [MinLength(2)]
        [Required]
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