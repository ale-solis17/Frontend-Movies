using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silicon.Models.Entidades.Response
{
    public class ResGeneros : ResBase
    {
        public List<Genero> Generos { get; set; }
    }
}