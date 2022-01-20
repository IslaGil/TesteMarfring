using System;
using System.Collections.Generic;
using System.Text;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Marfriing.Models;

namespace Marfriing.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Marfriing.Models.Pecuarista> Pecuarista { get; set; }
        public DbSet<Marfriing.Models.Animal> Animal { get; set; }
    }
}
