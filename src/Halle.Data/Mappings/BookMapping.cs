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
    public class BookMapping : IEntityTypeConfiguration<Book>
    {
        public void Configure(EntityTypeBuilder<Book> builder)
        {
            builder.ToTable("Book");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Name);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.HasMany(c => c.Categories)
                .WithMany(b => b.Books);

            builder.HasMany(c => c.Authors)
                .WithMany(b => b.Books);

            builder.HasMany(c => c.Tags)
                .WithMany(b => b.Books);
        }
    }
}
