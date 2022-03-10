using Microsoft.AspNetCore.Mvc;
using Priut2.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Priut2.Models
{
   
    public class Breed
    {
        public int Id { get; set; }

        public string Breeds { get; set; }

        public ICollection<Animals> Animalss{ get; set; }
    }
    
}
