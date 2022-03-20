using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace Priut2.Models
{
    public class RegistrationModel
    {[Required]
    [EmailAddress]
    [Display(Name ="Потребител")]
        public string  Email { get; set; }
        [Required]
        [DataType(DataType.Password)]
        [Display(Name ="Парола")]
        public string Password { get; set; }
        [Required]
        [Compare("Password")]
        [Display(Name ="Потвърди парола")]
        [DataType(DataType.Password)]

        public string ConfirmPassword { get; set; }
        [Required]
        [StringLength(20,MinimumLength =2)]
        [Display(Name ="Име")]
        public string FirstName { get; set; }
        [Required]
        [StringLength(20,MinimumLength =2)]
        [Display(Name ="Фамилия")]
        public string LastName { get; set; }
        [Required]
        [RegularExpression(@"^([+]?359)|0?(|-| )8[789]\d{1}(|-| )\d{3}(|-| )\d{3}$")]
        [Display(Name ="Телефонен номер")]
        public string PhoneNumber { get; set; }
        public bool AcceptUserAgreement { get; set; }
        public string RegistrationInValid { get; set; }
    }
}
