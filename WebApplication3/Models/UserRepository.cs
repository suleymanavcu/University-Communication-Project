using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApplication3.Models
{
    public class UserRepository
    {
        private static List<User> users=null;
        private static List<Post> posts = null;
        private static List<University> universities = null;
        private static List<Authority> authorities = null;
        private static List<Comment> comments = null;
        private static List<Department> departments = null;
        private static List<Faculty> faculties = null;
        private static List<Jobs> jobs = null;
        private static List<Status> statuses = null;
        static UserRepository()
        {
            
        }
        public static bool AddPost(Post post)
        {
            Post s = null;
            if (s != null)
            {
                    s.PostName = post.PostName;
                    s.Subject = post.Subject;
                    s.Text = post.Text;
                    s.UserId = post.UserId;
                return true;
            }

            return false;

        }










        public static List<User> Users { get { return users; } }
        public static List<Post> Posts { get { return posts; } }
        public static List<University> Universities { get { return universities; } }
        public static List<Authority> Authorities { get { return authorities; } }
        public static List<Comment> Comments { get { return comments; } }
        public static List<Department> Departments { get { return departments; } }
        public static List<Faculty> Faculties { get { return faculties; } }
        public static List<Jobs> Jobs { get { return jobs; } }
        public static List<Status> Statuses { get { return statuses; } }
    }
}
