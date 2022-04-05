using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Blogger.Models;
using Microsoft.AspNetCore.Identity;

namespace DevBlog.Areas.Identity.Data
{
    // Add profile data for application users by adding properties to the BlogUser class
    public class BlogUser : IdentityUser
    {
        public string Description { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public int Age { get; set; }
        public string ImgUser { get; set; }
        public List<Post> Posts { get; set; }
    }
}
