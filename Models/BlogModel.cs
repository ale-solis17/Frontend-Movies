using System;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using static Silicon.Models.BlogModel;
namespace Silicon.Models
{
    public class BlogModel
    {
        public PeliculaEspecificaModel PeliculaEspecifica { get; set; }
        
        public BlogModel()
        {
            PeliculaEspecifica = new PeliculaEspecificaModel();
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