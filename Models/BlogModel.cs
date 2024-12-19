using System.Collections.Generic;
using Silicon.Models.Entidades;

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
            public Pelicula pelicula { get; set; }
            //Comentarios
            public List<Comentario> comentario { get; set; }

            public PeliculaEspecificaModel()
            {
                pelicula = new Pelicula();
                comentario = new List<Comentario>();
            }
        }
    }
}