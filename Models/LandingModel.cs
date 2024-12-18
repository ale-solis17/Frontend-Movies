using Silicon.Models.Entidades;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silicon.Models
{
    public class LandingModel
    {
        public FiltrarGeneroModel filtrar {  get; set; }
        public LandingModel()
        {
            filtrar = new FiltrarGeneroModel();
        }

        public class FiltrarGeneroModel
        {
          public Genero genero { get; set; }
            public List<Pelicula> pelicula { get;set; }

            public FiltrarGeneroModel()
            {
                genero = new Genero();           // Asegura que 'genero' no sea null
                pelicula = new List<Pelicula>(); // Asegura que 'pelicula' no sea null
            }

        }
    }
}