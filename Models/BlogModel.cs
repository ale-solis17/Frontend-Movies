using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Silicon.Models
{
    public class BlogModel
    {
        public ComentarioModel Comentario { get; set; }
        public PeliculaEspecificaModel PeliculaEspecifica { get; set; }
        
        public BlogModel()
        {
            Comentario = new ComentarioModel();
            PeliculaEspecifica = new PeliculaEspecificaModel();
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
            public System.DateTime PublicationDate { get; set; }
        }
        public class PeliculaEspecificaModel
        {
            // Peliculas
            [Display(Name = "IdMovie")]
            public long idMovie { get; set; }
            [Display(Name = "NombrePelicula")]
            public string name { get; set; }
            [Display(Name = "Director")]
            public string director {  get; set; }
            [Display(Name = "Duracion")]
            public int duracion { get; set; }
            [Display(Name = "Creacion")]
            public DateTime creacion { get; set; }
            [Display(Name = "Synopsis")]
            public string synopsis { get; set; }
            [Display(Name = "Generos")]
            public string generos { get; set; }
            [Display(Name = "Url")]
            public string URL { get; set; }
            
            // Comentarios
            [Display(Name = "IdComentario")]
            public long IdComment { get; set; }
            [Display(Name = "IdUsuario")]
            public long idUsuario { get; set; }
            [Display(Name = "FechaCreacion")]
            public DateTime? creationDate { get; set; }
            [Display(Name = "Comentario")]
            public string comentario { get; set; }
            [Display(Name = "Rating")]
            public decimal? rating { get; set; }
        }
    }
}