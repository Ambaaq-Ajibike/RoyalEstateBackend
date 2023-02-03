using RoyalEstateBackend.Entities;
using Microsoft.EntityFrameworkCore;

namespace RoyalEstateBackend.Context
{
    public class ApplicationContext : DbContext
    {
        public ApplicationContext(DbContextOptions<ApplicationContext> options) : base(options)
        {
            
        }
        public DbSet<Address> Addresses{get; set;}
        public DbSet<Agent> Agents{get; set;}
        public DbSet<Image> Images{get; set;}
        public DbSet<Property> Properties{get; set;}
        public DbSet<PropertyType> PropertyTypes{get; set;}
        public DbSet<Utility> Utilities{get; set;}
    }
}