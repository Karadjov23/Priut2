using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Priut2.Models
{
    public class LoginModel
    {   [Required]
        [StringLength(30, MinimumLength = 2)]
        [EmailAddress]
        [Display(Name = "Потребител")]
        public string Email { get; set; }

        [Required]
        [StringLength(30, MinimumLength = 8)]
        [DataType(DataType.Password)]
        [Display(Name = "Парола")]
        public string Password { get; set; }
        
     
        [Display(Name = " Запомни ме ")]
        public bool RememberMe { get; set; }
        
        public string LoginInValid { get; set; }
    }
}
