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
    public class SubcategoryMapping : IEntityTypeConfiguration<Subcategory>
    {
        public void Configure(EntityTypeBuilder<Subcategory> builder)
        {
            builder.ToTable("Subcategory"); 
            builder.HasKey(x => x.Id);

            builder.HasIndex(x => x.Name);

            builder.Property(x => x.Name)
               .IsRequired();

            builder.HasOne(c => c.Category)
                .WithMany(s => s.Subcategories)
                .HasForeignKey(c => c.Id);
        }
    }
}
