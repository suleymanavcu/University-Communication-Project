using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class User
    {
        public int Id { get; set; }
        public string Password { get; set; }
        public string Name { get; set; }
        public string Surname { get; set; }
        public int Age { get; set; }
        public string Email { get; set; }
        public string Phonenumber { get; set; }
        public int AuthorityId { get; set; }
        public int UniversityId { get; set; }
        public int FacultyId { get; set; }
        public int DepartmentId { get; set; }
        public int StatusId { get; set; }

        public Authority Authority { get; set; }
        public University University  { get; set; }
        public Faculty Faculty { get; set; }
        public Department Department { get; set; }
        public Status Status { get; set; }

        public List<Comment> Comments { get; set; }
        public List<Post> Posts { get; set; }
        


    }
}
