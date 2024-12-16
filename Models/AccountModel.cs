using System.ComponentModel.DataAnnotations;

namespace Silicon.Models
{
    public class AccountModel
    {
        public signupModel signup { get; set; }
        public signinModel signin { get; set; } 

        public AccountModel() 
        {
            signup = new signupModel(); 
            signin = new signinModel();
        }

        public class signupModel 
        {
            [Required(ErrorMessage = "Por favor escribe tu nombre!")]
            [Display(Name = "Nombre")]
            [StringLength(50, MinimumLength = 2, ErrorMessage = "El nombre debe tener entre 2 y 50 caracteres")]
            public string Name { get; set; }

            [Required(ErrorMessage = "Por favor escribe tu apellido!")]
            [Display(Name = "Apellido")]
            [StringLength(50, MinimumLength = 2, ErrorMessage = "El apellido debe tener entre 2 y 50 caracteres")]
            public string LastName { get; set; }

            [Required(ErrorMessage = "Por favor coloca tu email!")]
            [EmailAddress(ErrorMessage = "Por favor ingresa un email válido")]
            [Display(Name = "Email")]
            [StringLength(100, ErrorMessage = "El email no puede exceder 100 caracteres")]
            public string Email { get; set; }

            [Required(ErrorMessage = "Por favor coloca un NickName!")]
            [Display(Name = "NickName")]
            [StringLength(30, MinimumLength = 3, ErrorMessage = "El NickName debe tener entre 3 y 30 caracteres")]
            public string NickName { get; set; }

            [Required(ErrorMessage = "Por favor escribe una contraseña!")]
            [Display(Name = "Contraseña")]
            [StringLength(100, MinimumLength = 8, ErrorMessage = "La contraseña debe tener al menos 8 caracteres")]
            [DataType(DataType.Password)]
            public string Password { get; set; }

            [Required(ErrorMessage = "Por favor confirma la contraseña!")]
            [Display(Name = "Confirmar Contraseña")]
            [DataType(DataType.Password)]
            [Compare("Password", ErrorMessage = "Las contraseñas no coinciden")]
            public string ConfirmPassword { get; set; }
        }
        public class signinModel
        {
            [Required(ErrorMessage = "El correo electrónico es obligatorio")]
            [EmailAddress(ErrorMessage = "El formato del correo electrónico no es válido")]
            [Display(Name = "Correo Electrónico")]
            public string mail { get; set; }

            [Required(ErrorMessage = "La contraseña es obligatoria")]
            [Display(Name = "Contraseña")]
            [DataType(DataType.Password)]
            public string password { get; set; }
        }
    }
}