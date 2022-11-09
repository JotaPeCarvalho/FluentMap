using Blog.Data;
using Blog.Models;
using Microsoft.EntityFrameworkCore;

using (var context = new BlogDataContext())
{
   
   context.Users.Add(new User{
    Bio  = "9X Microsoft MVP",
    Email = "andre@gmail.com",
    Image = "https://balta.io",
    Name = "João Pedro",
    PasswordHash = "123456",
    Slug = "andre-baltieri"
   });
    context.SaveChanges();
}

