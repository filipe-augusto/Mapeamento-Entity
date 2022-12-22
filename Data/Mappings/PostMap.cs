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
       
        //Relacionamentos
         builder.HasOne(x => x.Author).WithMany(x => x.Posts).HasConstraintName("FK_Post_Author")
         .OnDelete(DeleteBehavior.Cascade);//quando exclui um post exclui os  autores relacionados ao post;

        builder.HasOne(x=> x.Category).WithMany(x=> x.Posts)
        .HasConstraintName("FK_Post_Category")
        .OnDelete(DeleteBehavior.NoAction);
    }
}