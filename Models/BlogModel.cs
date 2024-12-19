using System.Collections.Generic;
using Silicon.Models.Entidades;

namespace Silicon.Models
{
    public class BlogModel
    {
        public PeliculaEspecificaModel PeliculaEspecifica { get; set; }
        public PeliculaInicioModel PeliculaInicio { get; set; }
        public ComentarioModel Comentario { get; set; }
        
        public BlogModel()
        {
           PeliculaEspecifica = new PeliculaEspecificaModel();
           PeliculaInicio = new PeliculaInicioModel();
           Comentario = new ComentarioModel();
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

        public class ComentarioModel
        {
            public Comentario Comentario { get; set; }
            public ComentarioModel()
            {
                Comentario = new Comentario();
            }
        }

        public class PeliculaInicioModel
        {
            public Pelicula pelicula { get; set; }
            public List<Comentario> comentario { get; set; }
   
   }    }
    
}