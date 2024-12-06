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
    }
}