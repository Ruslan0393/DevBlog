using Blogger.Models;
using DevBlog.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBlog.ViewModels
{
    public class GetGlobalPosts
    {
        public BlogUser users { get; set; }
        public Post post { get; set; }
        public string title { get; set; }
    }
}
