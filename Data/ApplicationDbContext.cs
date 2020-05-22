using System;
using System.Linq;
using System.Threading.Tasks;
using ApiGraph.DomainObjects;
using ApiGraph.Entities;
using Microsoft.EntityFrameworkCore;

namespace ApiGraph.Data
{
    public class ApplicationDbContext : DbContext, IUnitOfWork
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {
            
        }

        public DbSet<Product> Products {get; set;}
        public DbSet<Category> Categories {get; set;}

        public async Task<bool> Commit()
        {
            foreach(var entry in ChangeTracker.Entries()
            .Where(entry => entry.Entity.GetType().GetProperty("DateRegister") != null ))
            {
                if(entry.State == EntityState.Added)
                    entry.Property("DateRegister").CurrentValue = DateTime.Now;
                
                if(entry.State == EntityState.Modified)
                    entry.Property("DateRegister").IsModified = false;
            }

            return await base.SaveChangesAsync() > 0;
        }
    }
}