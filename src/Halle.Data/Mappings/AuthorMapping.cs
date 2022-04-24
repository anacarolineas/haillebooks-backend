using Halle.Business.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Halle.Data.Mappings
{
    public class AuthorMapping : IEntityTypeConfiguration<Author>
    {
        public void Configure(EntityTypeBuilder<Author> builder)
        {
            builder.ToTable("Author");
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Name);

            builder.Property(x => x.Name)
                .IsRequired();

            builder.HasMany(b => b.Books)
                .WithMany(a => a.Authors);
        }
    }
}
