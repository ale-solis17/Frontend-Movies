using System.Collections.Generic;

namespace Silicon.Models.Entidades
{
    public class ResMostrarComentarios : ResBase
    {
        public List<Comentario> Comentarios { get; set; }
    }
}