using Microsoft.Win32;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;
using static Silicon.Models.AccountModel;
using System.Web.UI.WebControls;
using System.Web.Mvc;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silicon.Models
{
    public class BlogModel
    {
        public ComentarioModel Comentario { get; set; }

        public BlogModel()
        {
            Comentario = new ComentarioModel();
        }

        public class ComentarioModel
        {
            [Key]
            [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            [Display(Name = "ID de Comentario")]
            public int ReviewId { get; set; }

            [Required(ErrorMessage = "Por favor selecciona una película.")]
            [Display(Name = "ID de Película")]
            public int MovieId { get; set; }

            [Required(ErrorMessage = "Por favor escribe un comentario.")]
            [Display(Name = "Comentario")]
            [StringLength(500, MinimumLength = 5, ErrorMessage = "El comentario debe tener entre 5 y 500 caracteres.")]
            public string Comment { get; set; }

            [Required(ErrorMessage = "Por favor califica la película.")]
            [Range(1, 5, ErrorMessage = "La calificación debe estar entre 1 y 5 estrellas.")]
            [Display(Name = "Calificación")]
            public int Rating { get; set; }

            [Required(ErrorMessage = "Debes estar registrado para dejar un comentario.")]
            [Display(Name = "ID de Usuario")]
            public int UserId { get; set; }

            

            [Display(Name = "Fecha de Publicación")]
            [DataType(DataType.DateTime)]
            //[DatabaseGenerated(DatabaseGeneratedOption.Identity)]
            public System.DateTime PublicationDate { get; set; };
        }
    }
}