using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class CommentPost
    {

        public int PostId { get; set; }
        public int CommentId { get; set; }
        public string CommentName { get; set; }
        public int CommentUserId { get; set; }
        public int CommentUserAuthorityId { get; set; }
        public string CommentUserName { get; set; }
        public string CommentUserSurname { get; set; }
        public string CommentUserStatus { get; set; }
    }
}
