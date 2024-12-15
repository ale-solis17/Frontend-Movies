using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silicon.Models.Entidades
{
    public class Comentario
    {
        public int Id { get; set; }
        public int idUsuario { get; set; }
        public int idPelicula { get; set; }
        public DateTime creationDate { get; set; }
        public string comentario {  get; set; }
        public decimal rating { get; set; }
    }
}