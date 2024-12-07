using System;
using System.Collections.Generic;

namespace Silicon.Models.Entidades
{
    public class ResBase
    {
        public bool resultado { get; set; }
        public List<Error> errores { get; set; }
    }
}