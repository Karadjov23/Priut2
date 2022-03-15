using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Priut2.Entities;
using Priut2.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace Priut2.Data
{
  
    public class ApplicationDbContext : IdentityDbContext<User>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public  DbSet<Animals> Animalss { get; set; }
        public  DbSet<Breed> Breeds { get; set; }
        public  DbSet<Article> Articles { get; set; }
        public  DbSet<Signal> Signals { get; set; }  
        public  DbSet<Employee> Employees { get; set; }
     
    }
}
