using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TelephoneBook.Models;
using System.Data.Entity;

namespace TelephoneBook.Controllers
{
    public class HomeController : Controller
    {
        TelephoneBookContext db = new TelephoneBookContext();
        public ActionResult Index(string StructuralSubdivision, string SearchString)
        {
            IQueryable<User> users = db.Users.Include(p => p.Telephones);
            if (!String.IsNullOrEmpty(StructuralSubdivision) && !StructuralSubdivision.Equals("Все"))
            {
                if (SearchString == "")
                {
                    users = users.Where(u => (u.StructuralSubdivision == StructuralSubdivision) && (u.StructuralSubdivision == StructuralSubdivision));
                }
                else
                {
                    IQueryable<User> tryUsers;
                    tryUsers = users.Where(u => (u.StructuralSubdivision == StructuralSubdivision) && (u.StructuralSubdivision == StructuralSubdivision));
                    tryUsers = tryUsers.Where(u => u.LastName == SearchString);
                    if (tryUsers.Count() == 0)
                    {
                        users = users.Where(u => (u.StructuralSubdivision == StructuralSubdivision) && (u.StructuralSubdivision == StructuralSubdivision));
                        Response.Write("<script>alert('Пользователя с такой фамилией не найдено')</script>");
                    }
                    else
                    {
                        users = users.Where(u => (u.StructuralSubdivision == StructuralSubdivision) && (u.StructuralSubdivision == StructuralSubdivision));
                        users = users.Where(u => u.LastName == SearchString);
                    }
                }
            }
            else
            {
                if(!String.IsNullOrEmpty(StructuralSubdivision) && StructuralSubdivision.Equals("Все") && SearchString != "")
                {
                    IQueryable<User> tryUsers;
                    tryUsers = users.Where(u => u.LastName == SearchString);
                    if (tryUsers.Count() == 0)
                    {
                        Response.Write("<script>alert('Пользователя с такой фамилией не найдено')</script>");
                    }
                    else
                    {
                        users = users.Where(u => u.LastName == SearchString);
                    }
                }
            }
            UserListViewModel ulvm = new UserListViewModel
            {
                Users = users.ToList(),
                StructuralSubdivisions = new SelectList(new List<string>()
                {
                    "Все",
                    "Финансовый отдел",
                    "Юридический отдел",
                    "Отдел разработки",
                    "Отдел безопасности"
                })
            };
            return View(ulvm);
        }
        [HttpGet]
        public ActionResult AddUser()
        {
            return View();
        }
        [HttpPost]
        public ActionResult AddUser(User user)
        {
            if (ModelState.IsValid)
            {
                db.Users.Add(user);
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            return View();
            
        }

        public ActionResult Delete(int Id)
        {
            User user = db.Users.Find(Id);

            if (user != null)
            {
                db.Users.Remove(user);
                db.SaveChanges();
            }
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Detail(int id)
        {
            var user = db.Users.Include(u => u.Telephones).FirstOrDefault(u => u.Id == id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Detail()
        {
            return RedirectToAction("Index");
        }
        [HttpGet]
        public ActionResult Edit(int id)
        {
            var user = db.Users.Include(u => u.Telephones).FirstOrDefault(u => u.Id == id);
            return View(user);
        }
        [HttpPost]
        public ActionResult Edit(User user)
        {
            if (ModelState.IsValid)
            {
                db.Entry(user).State = EntityState.Modified;
                db.SaveChanges();
                return RedirectToAction("Index");
            }
            
            return View(user);
        }
    }
}