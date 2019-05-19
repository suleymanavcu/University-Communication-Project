using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Post
    {
        public int Id { get; set; }
        public string PostName { get; set; }
        public string Text { get; set; }
        public string Subject { get; set; }         
        public int UserId { get; set; }

        public List<Comment> Comments { get; set; }
        public User User { get; set; }

    }
}
