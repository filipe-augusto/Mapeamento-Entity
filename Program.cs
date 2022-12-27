
using blog.Models;
using Blog.Data;
using Microsoft.EntityFrameworkCore;
//dotnet tool install --global dotnet-ef
//dotnet ef migrations add InitialCreation
// dotnet ef database update
//dotnet add package  Microsoft.EntityFrameworkCore.Design
 using var context = new BlogDataContext();
context.Users.Add(new User{
   Bio = "20x microsoft MVP",
   Email = "filipe@gmail.com",
   Image = "https://balta.io",
   Name = "Filipe",
   PasswordHash = "132456",
   Slug  = "filipe-augusto" ,
   Github = "f04a07s19c93"
});

 context.SaveChanges();

// var user = context.Users.FirstOrDefault();
// var post = new Post{
//     Author = user,
//     Body = "meu artigo",
//     Category = new Category{Name = "manutenção", Slug = "manutenção"},
//     CreateDate = System.DateTime.Now,
//     Slug = "meu-artigo",
//     Summary = "Neste artigo vamos conferir...",
//     Title = "meu artigo"
// };
// context.Posts.Add(post);
// context.SaveChanges();


