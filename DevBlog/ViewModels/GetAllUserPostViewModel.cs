using Blogger.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace DevBlog.ViewModels
{

    public class GetAllUserPostViewModel
    {
        public IEnumerable<Post> posts { get; set; }
        public string title { get; set; }
    }
}
