using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silicon.Models.Entidades.Response
{
    public class ResPeliculaInicio : ResBase
    {
        public Pelicula Pelicula { get; set; }
        public List<Comentario> Comentarios { get; set; } 
    }
}