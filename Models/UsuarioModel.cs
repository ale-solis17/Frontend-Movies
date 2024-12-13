using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silicon.Models
{
    public class UsuarioModel
    {
        public class Registar
        {
            [Required(ErrorMessage = "Ingrese el nombre")]
            [StringLength(50, ErrorMessage = "El nombre no puede ser mas de 50 caracteres")]
            public string nombre { get; set; }

            [Required(ErrorMessage = "Ingrese el apellido")]
            [StringLength(50, ErrorMessage = "El apeliido no puede ser mas de 50 caracteres")]
            public string apellidos { get; set; }

            [Required(ErrorMessage = "Ingrese el correo electrónico")]
            [EmailAddress(ErrorMessage = "Ingrese un correo válido")]
            public string correoElectronico { get; set; }

            [Required(ErrorMessage = "Ingrese el password")]
            [StringLength(100, MinimumLength = 6, ErrorMessage = "La contraseña debe tener al menos 6 caracteres")]
            public string password { get; set; }

            [Required(ErrorMessage = "Ingrese el password")]
            [System.ComponentModel.DataAnnotations.Compare("password", ErrorMessage = "El password y la confírmación no coinciden")]
            public string confirmarPassword { get; set; }
        }
    }
}