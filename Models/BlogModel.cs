using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Silicon.Models.BlogModel;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silicon.Models
{
    public class BlogModel
    {
        public PeliculaModel Pelicula { get; set; }

        public BlogModel()
        {
            Pelicula = new PeliculaModel();
        }

        public class PeliculaModel
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Display(Name = "ID de Película")]
            public int MovieId { get; set; }

            [Required(ErrorMessage = "Por favor ingresa el título de la película.")]
            [Display(Name = "Título")]
            public string Title { get; set; }

            [Required(ErrorMessage = "Por favor ingresa la sinopsis de la película.")]
            [Display(Name = "Sinopsis")]
            [StringLength(1000, MinimumLength = 10, ErrorMessage = "La sinopsis debe tener entre 10 y 1000 caracteres.")]
            public string Synopsis { get; set; }

            [Required(ErrorMessage = "Por favor ingresa la duración de la película.")]
            [Display(Name = "Duración")]
            [Range(1, 300, ErrorMessage = "La duración debe ser entre 1 y 300 minutos.")]
            public int Duration { get; set; }  

            [Required(ErrorMessage = "Por favor ingresa la fecha de estreno.")]
            [Display(Name = "Fecha de Estreno")]
            [DataType(DataType.Date)]
            public DateTime ReleaseDate { get; set; }

            [Required(ErrorMessage = "Por favor ingresa el nombre del director.")]
            [Display(Name = "Director")]
            public string Director { get; set; }

            [Required(ErrorMessage = "Por favor selecciona el género de la película.")]
            [Display(Name = "Género")]
            public string Genre { get; set; }

            [Display(Name = "Imagen de la Película")]
            public string ImageUrl { get; set; }

            public ICollection<ComentarioModel> Comentarios { get; set; }
        }
    }
}