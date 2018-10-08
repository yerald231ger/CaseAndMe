using CaseAndMeWeb.Models;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CaseAndMeWeb.ViewModel
{
    public class DeliverViewModel
    {
        [Required]
        [Display(Name = "Nombre(s)")]
        public string Nombre { get; set; }

        [Required]
        [Display(Name = "Apellido(s)")]
        public string Apellido { get; set; }

        [Required]
        [Display(Name = "Dirección")]
        public string Direccion { get; set; }

        [Required]
        [Display(Name = "Colónia")]
        public string Colonia { get; set; }

        [Required]
        [Display(Name = "Ciudad")]
        public string Ciudad { get; set; }

        [Required]
        [Display(Name = "CP")]
        public string CP { get; set; }

        
        [Display(Name = "Estado")]
        public Estado Estado { get; set; }

        
        [Display(Name = "Pais")]
        public Pais Pais { get; set; }

        [Required]
        [Display(Name = "Estado")]
        public ICollection<Estado> Estados { get; set; }

        [Required]
        [Display(Name = "Pais")]
        public ICollection<Pais> Paises { get; set; }

        [Required]
        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Required]
        [Display(Name = "Correo")]
        public string Email { get; set; }
    }
}