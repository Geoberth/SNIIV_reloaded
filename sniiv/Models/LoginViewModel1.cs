using System;
using System.ComponentModel.DataAnnotations;

namespace sniiv.Models
{
    public class LoginViewModel
    {
        [Required]
        public string Usuario { get; set; }

        [Required]
        [DataType(DataType.Password)]
        public string Contraseña { get; set; }

        public string ReturnUrl { get; set; }
    }
}
