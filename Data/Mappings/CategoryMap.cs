using blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace blog.Data.Mappings;

public class CategoryMap : IEntityTypeConfiguration<Category>
{
    public void Configure(EntityTypeBuilder<Category> builder)
    {
     //FLUENT MAPPING
      builder.ToTable("Category");
      //Chave primaria
      builder.HasKey(x => x.Id);
        //identity
      builder.Property(x => x.Id).ValueGeneratedOnAdd()
        .UseIdentityColumn(); // identity 

        //propriedades
        builder.Property(x => x.Name)
        .IsRequired()
        .HasColumnName("Name")
        .HasColumnType("NVARCHAR")
        .HasMaxLength(80);

        builder.Property(x => x.Slug)
        .IsRequired()
        .HasColumnName("Slug")
        .HasColumnType("VARCHAR")
        .HasMaxLength(80);

         //indices
         builder.HasIndex( x => x.Slug, "IX_Category_Slug")
         .IsUnique();




    }
}