using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class Blogcontext: DbContext
    {
        public Blogcontext() : base("DefaultConnection")
        {
        }
        public DbSet<BlogPost> BlogPosts { get; set; }
        public DbSet<comentario> Comentarios { get; set; }


    }
}