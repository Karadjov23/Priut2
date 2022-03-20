using Microsoft.AspNetCore.Identity;
using Priut2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Priut2
{
    public class User : IdentityUser
    {
      
        [StringLength(30)]
        public string FirstName { get; set; }
        [StringLength(30)]
        public string LastName { get; set; }
        
        public  ICollection<Signal> Signal { get; set; }
    }

}
