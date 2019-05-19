using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class UserPost
    {




        public int Id { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public string StatusName { get; set; }
        public string DepartmentName { get; set; }
        public int DepartmentId { get; set; }
        public string UniversityName { get; set; }
        public int AuthorityId { get; set; }
        public int PostId { get; set; }
        public string PostName { get; set; }
        public string Text { get; set; }
        public string Subject { get; set; }
        
    }
}
