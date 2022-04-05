using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;

namespace DevBlog.ViewModels
{
    public class AddPostViewModel
    {

        [Required]
        [MaxLength(50)]
        [Display(Name = "Title post")]
        public string Title { get; set; }

        [Required]
        [MaxLength(20000)]
        [Display(Name = "Body post")]
        public string Body { get; set; }

        public IFormFile Photo { get; set; }
    }
}
