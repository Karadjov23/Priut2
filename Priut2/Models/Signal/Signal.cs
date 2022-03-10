using Priut2.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Priut2.Models
{
    public class Signal
    {
        public int Id { get; set; }
        public string UserId { get; set; }
        public virtual User User{ get; set; }
        public int EmployeeId { get; set; }
        public virtual Employee Employee { get; set; }
        public string Description { get; set; }    
        public DateTime Date{ get; set; }
        
    }
}
