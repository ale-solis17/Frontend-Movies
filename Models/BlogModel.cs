using System.Collections.Generic;
using Silicon.Models.Entidades;

namespace Silicon.Models
{
    public class BlogModel
    {
       
        public BlogModel()
        {
            PeliculaEspecifica = new PeliculaEspecificaModel();
            PeliculaInicio = new PeliculaInicioModel();
        }

        public class PeliculaEspecificaModel
        {
            // Peliculas
            public Pelicula Peliculas { get; set; }
            //Comentarios
            public List<Comentario> Comentario { get; set; }

            public PeliculaEspecificaModel()
            {
                Peliculas = new Pelicula();
                Comentario = new List<Comentario>();
            }
        }

        public class PeliculaInicioModel
        {
            public Pelicula pelicula { get; set; }
            public List<Comentario> comentario { get; set; }

        }
        public PeliculaEspecificaModel PeliculaEspecifica { get; set; }
        public PeliculaInicioModel PeliculaInicio { get; set; }
    }
}