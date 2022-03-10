using Priut2.Enum;
using Priut2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Priut2.Entities
{
    public class Animals
    {

        public int Id { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public KindCategory KindCategory { get; set; }

        public int BreedId { get; set; }
         public virtual Breed Breed { get; set; }

        [Required]
        [Range(0, int.MaxValue, ErrorMessage = "Моля въведете по голямо от 0-ла")]
        public string Age { get; set; }
       
        [Required]
        public Gender Gender { get; set; }

        [Required]
        public string Image { get; set; }

        [Required]
        public bool Castrated { get; set; }

        [Required]
        public bool Passport { get; set; }
      
       
        public string Condition { get; set; }
               
        public DateTime Date { get; set; }
     
       
      
        
       
     
    

    }
}
