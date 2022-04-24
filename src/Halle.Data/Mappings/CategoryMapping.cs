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
    public class CategoryMapping : IEntityTypeConfiguration<Category>
    {
        public void Configure(EntityTypeBuilder<Category> builder)
        {
            builder.ToTable("Category");    
            builder.HasKey(c => c.Id);

            builder.Property(x => x.Name)
               .IsRequired();

            builder.HasMany(s => s.Subcategories)
                .WithOne(s => s.Category)
                .HasForeignKey(c => c.Id);

            builder.HasMany(b => b.Books)
                .WithMany(b => b.Categories);
        }
    }
}
