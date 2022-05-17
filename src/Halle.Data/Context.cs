using Halle.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Halle.Data.Extensions;
using Microsoft.EntityFrameworkCore.Metadata;
using Halle.Business.Interfaces;

namespace Halle.Data
{
    public class Context : DbContext, IContext
    {
        public Context(DbContextOptions<Context> options) : base(options) { }

        public DbSet<Book> Books { get; set; } = null!;
        public DbSet<Category> Categories { get; set; } = null!;
        public DbSet<Author> Authors { get; set; } = null!;
        public DbSet<Tag> Tags { get; set; } = null!;
        public DbSet<Favorite> Favorites { get; set; } = null!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            // por padrão, quando não definido, string gera limite 100
            foreach (var property in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetProperties()
                    .Where(p => p.ClrType == typeof(string))))
                property.SetColumnType("varchar(100)");

            modelBuilder.ApplyConfigurationsFromAssembly(typeof(Context).Assembly);

            //desabilita delete cascade
            foreach (var relationship in modelBuilder.Model.GetEntityTypes()
                .SelectMany(e => e.GetForeignKeys())) 
                relationship.DeleteBehavior = DeleteBehavior.ClientSetNull;

            base.OnModelCreating(modelBuilder);
        }
    }
}
