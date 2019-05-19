using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Faculty
    {
        public int Id { get; set; }
        public string FacultyName { get; set; }
        public List<User> Users { get; set; }
    }
}
