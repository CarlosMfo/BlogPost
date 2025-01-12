using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using WebApplication3.Models;
using System.Data.Entity;



namespace WebApplication3.Services
{
    public class BlogPostRepository
    {
        private object db;

        public List<BlogPost> ObtenerTodos()
       {
            using (var db = new Blogcontext())
            {
                return db.BlogPosts.Include(x => x.comentarios).ToList();
            }
       }

        public BlogPost ObtenerPorId(int id)
        {
            using (var context = new Blogcontext()) // Usa tu DbContext aquí
            {
                return context.BlogPosts.FirstOrDefault(bp => bp.Id == id);
            }
        }


        internal void Crear(BlogPost model)
        {
            using (var db = new Blogcontext())
            {
                db.BlogPosts.Add(model);
                db.SaveChanges();
            }
                


        }

        internal void Editar(BlogPost model)
        {
            using (var db = new Blogcontext())
            {
                var blogPostExistente = db.BlogPosts.FirstOrDefault(bp => bp.Id == model.Id);

                if (blogPostExistente != null)
                {
                    // Actualiza las propiedades del objeto existente
                    blogPostExistente.Titulo = model.Titulo;    
                    blogPostExistente.Contenido = model.Contenido;
                    blogPostExistente.Autor = model.Autor;
                    blogPostExistente.Publicacion = model.Publicacion;

                    // Guarda los cambios en la base de datos
                    db.SaveChanges();
                }
                else
                {
                    throw new Exception("BlogPost no encontrado.");
                }

                
            }



        }



        internal void Eliminar(BlogPost model)
        {
            using (var db = new Blogcontext())
            {
                var entry = db.Entry(model);
                if (entry.State == EntityState.Detached)
                {
                    db.BlogPosts.Attach(model); // Adjunta la entidad al contexto
                }


                // Actualiza las propiedades del objeto existente
                db.BlogPosts.Remove(model);
                    // Guarda los cambios en la base de datos
                    db.SaveChanges();
                              


            }



        }
    }
}