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
        [Required]
        public int BreedId { get; set; }
        public Breed Breed { get; set; }

        [Required]
        [Range(1, 20, ErrorMessage = "cannot enter 0 ")]
        public string Age { get; set; }

        [Required]
        public Gender Gender { get; set; }

        [Required]

        public string Image { get; set; }


        public bool Castrated { get; set; }

        public bool Passport { get; set; }

        public string Condition { get; set; }
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}")]
        public DateTime Date { get; set; }


    }
}
