using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silicon.Models.Entidades
{
    public class Sesion
    {
        public static int Id { get; set; }
        public static string name { get; set; }
        public static string lastName { get; set; }
        public static string email { get; set; }
        public static string nickname { get; set; }
        
        public static DateTime fechaDeInicio { get; set; }

        public static bool ComprobarSesion()
        {
            if (Id == 0)
            {
                return false;
            }
            return true;
        }

        public static void CerrarSesion()
        {
            Id = 0;
            name = null;
            lastName = null;
            email = null;
            
        }
    }
}