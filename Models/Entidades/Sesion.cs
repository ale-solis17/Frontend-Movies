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
        public static string password { get; set; }

        public static DateTime ultimaAccion { get; set; }
        public static DateTime fechaDeInicio { get; set; }

        public static bool ComprobarSesion()
        {
            if (Sesion.Id == 0)
            {
                return false;
            }
            return true;
        }

        public static void cerrarSesion()
        {
            Sesion.Id = 0;
            Sesion.name = null;
            Sesion.lastName = null;
            Sesion.email = null;
            Sesion.password = null;
        }
    }
}