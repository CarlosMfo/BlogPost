using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using WebApplication3.Models;
using WebApplication3.Services;

namespace WebApplication3.Controllers
{
    public class BlogpostController : Controller        
    {
        private BlogPostRepository _repo;

        public BlogpostController()
        { 

              _repo = new BlogPostRepository();

        }

    
        // GET: Blogpost
        public ActionResult Index()
        {
            var model = _repo.ObtenerTodos();
            //var comentario = model[0].comentarios[0];
            return View(model);
        }

        // GET: Blogpost/Details/5
        public ActionResult Details(int id)
        {

            var blogPost = _repo.ObtenerPorId(id);

            if (blogPost == null)
            {
                return HttpNotFound();
            }

            return View(blogPost);
        }

        // GET: Blogpost/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Blogpost/Create
        [HttpPost]
        public ActionResult Create(BlogPost Model)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _repo.Crear(Model);
                    return RedirectToAction("Index");
                    
                }

            }
            catch
            {
               
            }
            return View(Model);
        }

        // GET: Blogpost/Edit/5
        public ActionResult Edit(int id, BlogPost Model)
        {// Busca el objeto BlogPost por ID en la base de datos
         // Usa el repositorio para buscar el blog post
            var blogPost = _repo.ObtenerPorId(id);

            if (blogPost == null)
            {
                return HttpNotFound();
            }
           
            return View(blogPost);


        }

        // POST: Blogpost/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, BlogPost Model, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                ModelState.Clear();
                if (ModelState.IsValid)
                {
                    _repo.Editar(Model);
                    return RedirectToAction("Index");

                }

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Blogpost/Delete/5
        public ActionResult Delete(int id)
        {
            var blogPost = _repo.ObtenerPorId(id);

            if (blogPost == null)
            {
                return HttpNotFound();
            }
            return View(blogPost);
        }

        // POST: Blogpost/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here
                var blogPost = _repo.ObtenerPorId(id);

                if (blogPost == null)
                {
                    return HttpNotFound();
                }
                _repo.Eliminar(blogPost);
                return RedirectToAction("Index");


            }
            catch(Exception e)
            {
                return View();
            }
        }
    }
}
