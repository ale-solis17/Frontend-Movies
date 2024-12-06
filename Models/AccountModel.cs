using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Silicon.Models
{
    public class AccountModel
    {
        public RegisterModel Register { get; set; }
        public LoginModel Login { get; set; } 

        public AccountModel() 
        {
            Register = new RegisterModel(); 
            Login = new LoginModel();
        }

        public class LoginModel
        {
            [Required(ErrorMessage = "El correo electrónico es obligatorio")]
            [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
            [Display(Name = "Correo Electrónico")]
            public string Email { get; set; }

            [Required(ErrorMessage = "La contraseña es obligatoria")]
            [Display(Name = "Contraseña")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

    }
}