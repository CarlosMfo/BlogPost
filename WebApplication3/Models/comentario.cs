using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace WebApplication3.Models
{
    public class comentario
    {
        public int Id { get; set; }
        public String Contenido { get; set; }
        public String Autor { get; set; }
        public int BlogPostId { get; set; }

        [ForeignKey("BlogPostId")]
       public BlogPost blogPost { get; set; }

    }

}