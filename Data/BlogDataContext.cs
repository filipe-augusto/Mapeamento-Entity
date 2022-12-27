using blog.Data.Mappings;
using blog.Models;
using Microsoft.EntityFrameworkCore;

namespace Blog.Data;

public class BlogDataContext : DbContext{
    public DbSet<Category> Categories { get; set; }
    public DbSet<Post> Posts { get; set; }
    public DbSet<User> Users { get; set; }



    protected override void OnConfiguring(DbContextOptionsBuilder options)
    =>
     //options.UseSqlServer(@"Data Source=IM-BRS-NT1071\MSSQLSERVER01;Integrated Security=True;Connect Timeout=30;Initial Catalog=Blog; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
     options.UseSqlServer(@"Data Source=IM-BRS-NT1071\MSSQLSERVER01;Integrated Security=True;Connect Timeout=30;Initial Catalog=Blog3; Encrypt=False;TrustServerCertificate=False;ApplicationIntent=ReadWrite;MultiSubnetFailover=False");
     
  protected override  void OnModelCreating(ModelBuilder modelBuilder){
        modelBuilder.ApplyConfiguration(new CategoryMap());
        modelBuilder.ApplyConfiguration(new UserMap());
        modelBuilder.ApplyConfiguration(new PostMap());
  }
    


}

