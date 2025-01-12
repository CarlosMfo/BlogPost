using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class BlogPost
    {
        public int Id { get; set; }
        [Required]
        [StringLength(200)]
        public string Titulo { get; set; }
        [Required]
        [StringLength(200)]
        public string Contenido { get; set; }
        public string Autor { get; set; }
        public DateTime Publicacion { get; set; }
        public List<comentario> comentarios { get; set; }


    }
}