using blog.Models;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace blog.Data.Mappings;

public class UserMap : IEntityTypeConfiguration<User>
{
    public void Configure(EntityTypeBuilder<User> builder)
    {
       // throw new NotImplementedException();
       //tabela
        builder.ToTable("User");
        //chave primaria
        builder.HasKey(x => x.Id);
        //identity
        builder.Property(x => x.Id)
        .ValueGeneratedOnAdd()
        .UseIdentityColumn();
        //propriedades
         builder.Property(x => x.Name).IsRequired()
        .HasColumnName("Name")
        .HasColumnType("NVARCHAR")
        .HasMaxLength(30);

        builder.Property(x => x.Bio);
        builder.Property(x => x.Email);
        builder.Property(x => x.Image);
        builder.Property(x => x.PasswordHash);
        builder.Property(x => x.Slug)
        .IsRequired()
        .HasColumnName("Slug")
        .HasColumnType("VARCHAR")
        .HasMaxLength(80);

        //indices
        builder.HasIndex(x => x.Slug, "IX_User_Slug").IsUnique();
        //relacionados
        builder.HasMany(x => x.Roles).WithMany(x => x.Users)
        .UsingEntity<Dictionary<string,object>>(
            "UserRole", role => role.HasOne<Role>()
            .WithMany()
            .HasForeignKey("RoleId")
            .HasConstraintName("FK_UserRole_RoleId")
            .OnDelete(DeleteBehavior.Cascade),
            user => user.HasOne<User>()
            .WithMany()
            .HasForeignKey("UserId")
            .HasConstraintName("FK_UserRole_UserId")
            .OnDelete(DeleteBehavior.Cascade)
        );
            


    }
}

