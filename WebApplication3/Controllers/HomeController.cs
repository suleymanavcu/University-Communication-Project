using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using WebApplication3.Models;

namespace WebApplication3.Controllers
{
    public class HomeController : Controller
    {
        UserDbContext context;
        public static User user = new Models.User();
        
        public HomeController(UserDbContext c)
        {
            context = c;
            
            
        }
        

        public IActionResult _Layout(int i)
        {
            if(i==1)
            {
                return RedirectToAction("Index", user);
            }
            else
            {
                return RedirectToAction("Index", user);
            }
            

            
        }


        public IActionResult Index(User userr)
        {

            user = userr;
            ViewBag.userid = user.Id;
            TempData["Veri"] = user.Id;
            ViewBag.usermodeli = user;
            /////////////////////////////////////////////////////
            var pi = (from u in context.Users
                      join a in context.Authorities
                      on u.AuthorityId equals a.Id
                      join d in context.Departments
                      on u.DepartmentId equals d.Id
                      join f in context.Faculties
                      on u.FacultyId equals f.Id
                      join s in context.Statuses
                      on u.StatusId equals s.Id
                      join un in context.Universities
                      on u.UniversityId equals un.Id                      
                      select new
                      {
                          u,a,d,f,s,un
                      });

            List<UserInfo> q = new List<UserInfo>();
            var itemmm = pi.FirstOrDefault(i=>i.u.Id== user.Id);
            
                
                    q.Add(new UserInfo
                    {
                        Id = itemmm.u.Id,
                        UserName =itemmm.u.Name,
                        UserSurname = itemmm.u.Surname,
                        Age=itemmm.u.Age,                           
                        AuthorityName=itemmm.a.AuthorityName,
                        DepartmentName=itemmm.d.DepartmentName,
                        FacultyName=itemmm.f.FacultyName,
                        PhoneNumber=itemmm.u.Phonenumber,
                        StatusName=itemmm.s.StatusName,
                        UniversityName=itemmm.un.UniversityName,
                        Email=itemmm.u.Email
                    });
                
            
            ViewBag.Userinfolar = q;
            /////////////////////////////////////////////////////
            var pu = (from u in context.Users
                     join p in context.Posts  
                     on u.Id equals p.UserId
                     join d in context.Departments
                     on u.DepartmentId equals d.Id
                     join un in context.Universities
                     on u.UniversityId equals un.Id
                     join s in context.Statuses
                     on u.StatusId equals s.Id
                     orderby p.Id descending
                      select new
                     {
                        u,p,un,s,d
                     });
            List<UserPost> qqq = new List<UserPost>();
            foreach(var item in pu)
            {
                qqq.Add(new UserPost {
                    Id=item.u.Id,
                    Name = item.u.Name,
                    Surname =item.u.Surname,
                    StatusName = item.s.StatusName,
                    DepartmentId=item.u.DepartmentId,
                    DepartmentName=item.d.DepartmentName,
                    UniversityName=item.un.UniversityName,
                    AuthorityId=item.u.AuthorityId,
                    PostName=item.p.PostName,
                    Subject=item.p.Subject,
                    Text = item.p.Text,
                    PostId = item.p.Id});
            }
            ViewBag.postveuser = qqq;
            /////////////////////////////////////////////////////
            var pc = (from c in context.Comments
                      join p in context.Posts
                      on c.PostId equals p.Id
                      join u in context.Users
                      on c.UserId equals u.Id
                      join s in context.Statuses
                      on u.StatusId equals s.Id
                      orderby c.Id
                      select new
                      {
                          c,
                          p,
                          u,
                          s
                      });
            List<CommentPost> qq = new List<CommentPost>();
            foreach(var itemm in pc)
            {
                qq.Add(new CommentPost
                {
                    PostId = itemm.p.Id,
                    CommentId=itemm.c.Id,
                    CommentName=itemm.c.CommentName,
                    CommentUserId=itemm.u.Id,
                    CommentUserName=itemm.u.Name,
                    CommentUserAuthorityId=itemm.u.AuthorityId,
                    CommentUserSurname=itemm.u.Surname,
                    CommentUserStatus=itemm.s.StatusName
                });
            }
            ViewBag.comment = qq;
            /////////////////////////////////////////////////////

            ViewBag.commentadd = context.Comments;

            return View(context.Users);
        }




        [HttpPost]
        public IActionResult PostKayit(string title,string subject,string text)
        {
            var TempDateVeri = TempData["Veri"];
            context.Posts.Add(new Post { PostName = title, Text = text, Subject = subject ,UserId= Convert.ToInt32(TempDateVeri) });
            context.SaveChanges();          
            return RedirectToAction("Index",context.Users.FirstOrDefault(i => i.Id == Convert.ToInt32(TempDateVeri)));           
        }


        [HttpPost]
        public IActionResult CommentKayit(string commentname , int postid)
        {
            var TempDateVeri = TempData["Veri"];
            context.Comments.Add(new Comment { CommentName = commentname, PostId = postid, UserId =  Convert.ToInt32(TempDateVeri)  });
            context.SaveChanges();

            return RedirectToAction("Index",context.Users.FirstOrDefault(i => i.Id == Convert.ToInt32(TempDateVeri)));
        }

        public IActionResult PostSil(int id)
        {
            
             foreach (var a in context.Comments)
            {
                if(a.PostId==id)
                {
                    context.Comments.Remove(a);
                }
            }

            var b = context.Posts.FirstOrDefault(i => i.Id == id);

            
            context.Posts.Remove(b);
            context.SaveChanges();
            return RedirectToAction("Index",context.Users.FirstOrDefault(i => i.Id == user.Id));
        }
               


        public IActionResult CommentSil(int id)
        {
            
            var a = context.Comments.FirstOrDefault(i => i.Id == id);
            context.Comments.Remove(a);
            context.SaveChanges();
            return RedirectToAction("Index",context.Users.FirstOrDefault(i => i.Id == user.Id));
        }




        public IActionResult UniversityPage()
        {
            return View(context.Universities);
        }
        public IActionResult UserPage()
        {
            ViewBag.usermodelii = user;

            var uu = from us in context.Users
                         join un in context.Universities
                         on us.UniversityId equals un.Id                         
                         orderby us.StatusId descending
                         select new
                         {
                             us,
                             un
                         };
          
            List<UserUniversity> test = new List<UserUniversity>();
            foreach (var item in uu)
            {
                test.Add(new UserUniversity
                {
                    u_phone = item.us.Phonenumber,
                    u_surname = item.us.Surname,
                    u_name = item.us.Name,
                    u_age = item.us.Age,
                    u_email = item.us.Email,
                    u_uniName = item.un.UniversityName,
                    u_auth = item.us.AuthorityId,
                    u_uniId = item.un.Id,
                    u_depId = item.us.DepartmentId
                });
            }
            ViewBag.st_user = test;
            return View(context.Users);
        }
        public IActionResult LoginPage()
        {
            ViewBag.deps = context.Departments.Where(x=>x.Id!=1).ToList();
            ViewBag.unis = context.Universities.ToList();
            ViewBag.facs = context.Faculties.ToList();
            ViewBag.stas = context.Statuses.Where(x => x.Id != 3).ToList();
            return View(context.Users);
        }

        [HttpPost]
        public IActionResult LoginControl(string email, string psw)
        {
            var a = context.Users.FirstOrDefault(i => i.Email == email && i.Password == psw);
            if (a != null)
                return RedirectToAction("Index", context.Users.FirstOrDefault(i=>i.Id==a.Id));
            else
                return RedirectToAction("LoginPage");

        }
        [HttpPost]
        public IActionResult SignupControl(string email, string name, string surname, int age, string status, string university, string faculty, string department, string phone, string psw, string repsw)
        {
            string msg = " ";

            var deps = context.Departments.FirstOrDefault(i => i.DepartmentName == department);
            var unis = context.Universities.FirstOrDefault(i => i.UniversityName == university);
            var facs = context.Faculties.FirstOrDefault(i => i.FacultyName == faculty);
            var stas = context.Statuses.FirstOrDefault(i => i.StatusName == status);

            var a = context.Users.FirstOrDefault(i => i.Email == email);

            if (a == null && psw == repsw)
            {
                User userkayit = new User();

                userkayit.Name = name;
                userkayit.Surname = surname;
                userkayit.Email = email;
                userkayit.Age = age;
                userkayit.UniversityId = unis.Id;
                userkayit.DepartmentId = deps.Id;
                userkayit.FacultyId = facs.Id;
                userkayit.Password = psw;
                userkayit.Phonenumber = phone;
                userkayit.StatusId = stas.Id;
                userkayit.AuthorityId = 2;
                context.Users.Add(userkayit);
                context.SaveChanges();

                msg = "";
                ViewBag.warning = msg;

                return RedirectToAction("LoginPage");
            }
            else
            {
                msg = "hata";
                ViewBag.warning = msg;
                return RedirectToAction("LoginPage");
            }

        }

        public IActionResult JobsPage()
        {
            return View(context.Jobs);
        }
        public IActionResult ProjectPage()
        {
            return View();
        }
        public IActionResult ResetPasswordPage()
        {
            User userr = context.Users.FirstOrDefault(i => i.Id == user.Id);
            return View(userr);
        }

        [HttpPost]
        public IActionResult ResetPasswordPage(string oldPassword, string newPassword, string repeatPassword)
        {
            User userr = context.Users.FirstOrDefault(i => i.Id == user.Id);
            string message = "";
            if (userr.Password != oldPassword || newPassword != repeatPassword)
            {//Hata verecek sayfada
                message = "There is a problem with password fields";
                ViewBag.message = message;
                return View(userr);
            }
            else
            {//
                message = "Password has been changed successfully";
                ViewBag.message = message;
                userr.Password = newPassword;
                context.Users.Update(userr);
                context.SaveChanges();
                return View(userr);
            }

        }



    }
}