using Halle.Business.Entities;
using Microsoft.EntityFrameworkCore;

namespace Halle.Data
{
    public interface IContext : IAsyncDisposable, IDisposable
    {
        public DbSet<Book> Books { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<Author> Authors { get; set; }
        public DbSet<Tag> Tags { get; set; }
        public DbSet<Favorite> Favorites { get; set; }

        public Task SaveChangesAsync();
    }
}
