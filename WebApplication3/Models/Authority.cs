using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class Authority
    {
        public int Id { get; set; }
        public string AuthorityName { get; set; }
        public List<User> Users { get; set; }
    }
}
