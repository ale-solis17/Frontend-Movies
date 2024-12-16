using System;

namespace Silicon.Models.Entidades
{
    public class Comentario
    {
        public long Id { get; set; }
        public long idUsuario { get; set; }
        public long idPelicula { get; set; }
        public DateTime? creationDate { get; set; }
        public string comentario { get; set; }
        public decimal? rating { get; set; }
    }
}