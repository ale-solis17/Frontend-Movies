using Silicon.Models.Entidades;
using System.Collections.Generic;

namespace Silicon.Models
{
    public class LandingModel
    {
        public LandingModel()
        {
            filtrar = new FiltrarGeneroModel();
            Mostrar = new GenerosMostrar();
            PeliculaInicio = new PeliculaInicioModel();
        }

        public class FiltrarGeneroModel
        {
            public Genero Generos { get; set; }
            public List<Pelicula> Peliculas { get;set; }

            public FiltrarGeneroModel()
            {
                Generos = new Genero();
                Peliculas = new List<Pelicula>();
            }

        }

        public class GenerosMostrar
        {
            public List<Genero> Generos{ get; set; }

            public GenerosMostrar()
            {
                Generos = new List<Genero>();
            }
        }
        
        public class PeliculaInicioModel
        {
            public Pelicula Peliculas { get; set; }
            public List<Comentario> Comentario { get; set; }
   
            public PeliculaInicioModel()
            {
                Peliculas = new Pelicula();
                Comentario = new List<Comentario>();
            }
        }    

        public FiltrarGeneroModel filtrar { get; set; }

        public GenerosMostrar Mostrar { get; set; }
        
        public PeliculaInicioModel PeliculaInicio { get; set; }
    }
}