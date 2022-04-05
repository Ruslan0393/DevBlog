using DevBlog.Areas.Identity.Data;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Blogger.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Body { get; set; }
        public string PostImg { get; set; }
        public DateTime AddTime { get; set; }

        [ForeignKey("BlogUser")]
        public string BlogUserRefId { get; set; }
        public BlogUser BlogUser { get; set; }
    }
}
