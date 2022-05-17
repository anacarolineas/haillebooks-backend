using Halle.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Halle.Data.Mappings
{
    public class FavoriteMapping : IEntityTypeConfiguration<Favorite>
    {
        public void Configure(EntityTypeBuilder<Favorite> builder)
        {
            builder.ToTable("Favorite");
            builder.HasKey(x => x.Id);

            builder.HasKey(f => new { f.UserId, f.BookId });

            builder.HasOne(b => b.Book)
                .WithMany(f => f.Favorites)
                .HasForeignKey(x => x.BookId);
        }
    }
}
