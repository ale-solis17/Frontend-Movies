using System;

namespace Silicon.Models.Entidades
{
    public class Comentario
    {
        public long idPelicula { get; set; }
        public long IdComment { get; set; }
        public string nickname { get; set; }
        public DateTime? creationDate { get; set; }
        public string comentario { get; set; }
        public decimal? rating { get; set; }
    }
}