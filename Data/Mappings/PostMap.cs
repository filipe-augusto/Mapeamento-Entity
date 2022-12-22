using blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace blog.Data.Mappings;
public class PostMap : IEntityTypeConfiguration<Post>
{
    public void Configure(EntityTypeBuilder<Post> builder)
    {
       builder.ToTable("Post");
        //tabela
        //chave primaria
        builder.HasKey(x => x.Id);
        //identity
        builder.Property(x => x.Id)
        .ValueGeneratedOnAdd()
        .UseIdentityColumn();
        //propriedades
         builder.Property(x => x.LastUpdateDate).IsRequired()
        .HasColumnName("LastUpdateDate")
        .HasColumnType("SMALLDATETIME")
        //.HasDefaultValueSql("GETDATE()")
        .HasDefaultValue(DateTime.Now.ToUniversalTime());

        builder.HasIndex(x => x.Slug, "IX_Post_Slug").IsUnique();
    }
}