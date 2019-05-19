using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class University
    {
        public int Id { get; set; }
        public string UniversityName { get; set; }
        public string City { get; set; }
        public string UniversityPhone { get; set;}
        public string Website { get; set; }
        public List<User> Users { get; set; }
    }
}
