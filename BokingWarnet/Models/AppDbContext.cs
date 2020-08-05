using BokingWarnet.Models.DomainClass;
using BokingWarnet.Utility;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace BokingWarnet.Models
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions options) : base(options)
        {

        }

        public DbSet<Komputer> Komputers { get; set; }
        public DbSet<OrangBooking> OrangBooking { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Seed();
            base.OnModelCreating(modelBuilder);
        }
    }
}
