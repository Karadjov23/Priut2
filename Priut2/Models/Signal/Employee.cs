using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Priut2.Models
{
    public class Employee
    { public int Id { get; set; }
    
        public string Name { get; set; }
        public string SecondName { get; set; }
        public string LastName { get; set; }
        public string Email { get; set; }
        public string Image { get; set; }
        public string EmployeersPosition { get; set; }
     
        public virtual ICollection<Signal> Signals { get; set; }

    }
}
