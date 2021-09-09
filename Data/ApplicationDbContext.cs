using Microsoft.EntityFrameworkCore;
using ParkingSpacesApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ParkingSpacesApp.Data
{
    public class ApplicationDbContext : DbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
                
        }

        public DbSet<Users> Users { get; set; }
        public DbSet<Reservations> Reservations { get; set; }
        public DbSet<ParkingSpaces> ParkingSpaces { get; set; }
        public DbSet<Buildings> Buildings { get; set; }
    }
}
