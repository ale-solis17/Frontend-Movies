using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Silicon.Models.BlogModel;
namespace Silicon.Models
{
    public class BlogModel
    {
        public PeliculaModel Pelicula { get; set; }

        public ComentarioModel Comentario { get; set; }
        public PeliculaEspecificaModel PeliculaEspecifica { get; set; }
        
        public BlogModel()
        {
            Comentario = new ComentarioModel();
            PeliculaEspecifica = new PeliculaEspecificaModel();
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