using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace TestingToSeeIfShitWorks.Models
{
    public class Blog
    {
        public int BlogId { get; set; }
        public string Name { get; set; }

        public virtual List<Post> Posts { get; set; }
    }
}