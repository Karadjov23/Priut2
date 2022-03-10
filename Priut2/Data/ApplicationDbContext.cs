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
        public virtual DbSet<Animals> Animalss { get; set; }
        public virtual DbSet<Breed> Breeds { get; set; }
        public virtual DbSet<Article> Articles { get; set; }
        public virtual DbSet<Signal> Signals { get; set; }  
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<User> User{ get; set; }
    }
}
