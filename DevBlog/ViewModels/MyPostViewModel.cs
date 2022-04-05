using Blogger.Models;
using DevBlog.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBlog.ViewModels
{
    public class MyPostViewModel
    {
        public IEnumerable<BlogUser> AllUsers { get; set; }
        public IEnumerable<Post> AllPosts { get; set; }
        public string Title { get; set; }
    }
}
