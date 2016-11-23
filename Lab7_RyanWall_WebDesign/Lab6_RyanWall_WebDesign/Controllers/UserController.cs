using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Entity;
using System.Linq;
using System.Net;
using System.Web;
using System.Web.Mvc;
using Lab6_RyanWall_WebDesign.Data;
using Lab6_RyanWall_WebDesign.Models;
using Lab6_RyanWall_WebDesign.Services;

namespace Lab6_RyanWall_WebDesign.Controllers
{
    [Authorize]
    public class UserController : Controller
    {
        //private UserContext db = new UserContext();

        private readonly IRepository _repository;
        private readonly IUserService _userservice;

        public UserController(IRepository Repository, IUserService userservice)
        {
            _repository = Repository;
            _userservice = userservice;
            //_UserService = userservice;
        }

        // GET: User
        public ActionResult Index()
        {
            var users = _repository.GetAllUsers();
            foreach (var user in users)
            {
                user.Cool = _userservice.UserIsCool(user);
            }
            return View(users);
        }

        // GET: User/Details/5
        public ActionResult Details(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = _repository.GetUser(id.Value);
            if (user == null)
            {
                return HttpNotFound();
            }
            return View(user);
        }

        // GET: User/Create
        public ActionResult Create()
        {
            GetPetList();
            return View();
        }

        // POST: User/Create
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create([Bind(Include = "FirstName,LastName,EmailAddress,NickName,address,FavoriteNBATeam,DoYouPlayVG")] User user, List<int> PetIds)
        {
            if (ModelState.IsValid)
            {
                user.Pets = new List<Pet>();
                if (PetIds != null)
                {
                    foreach (var petId in PetIds)
                    {
                        user.Pets.Add(new Pet
                        {
                            PetId = petId
                        });
                    }
                }

                _repository.AddUser(user);
                return RedirectToAction("Index");
            }

            return View(user);
        }

        // GET: User/Edit/5
        public ActionResult Edit(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = _repository.GetUser(id.Value);

            if (user == null)
            {
                return HttpNotFound();
            }

            return View(user);
        }

        // POST: User/Edit/5
        // To protect from overposting attacks, please enable the specific properties you want to bind to, for 
        // more details see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit([Bind(Include = "UserId,FirstName,LastName,EmailAddress,NickName,address,FavoriteNBATeam,DoYouPlayVG")] User user)
        {
            if (ModelState.IsValid)
            {
                return View(user);
            }

            _repository.UpdateUser(user);
            return RedirectToAction("Index");
        }

        // GET: User/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null)
            {
                return new HttpStatusCodeResult(HttpStatusCode.BadRequest);
            }

            User user = _repository.GetUser(id.Value);

            if (user == null)
            {
                return HttpNotFound();
            }
            _repository.RemoveUser(user);
            return RedirectToAction("Index");
        }

        // POST: User/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public ActionResult DeleteConfirmed(int id)
        {
            User user = _repository.GetUser(id);
            // db.Users.Remove(user);
            //db.SaveChanges();
            return RedirectToAction("Index");
        }

        //protected override void Dispose(bool disposing)
        //{
        //    if (disposing)
        //    {
        //        db.Dispose();
        //    }
        //    base.Dispose(disposing);
        //}

        private void GetPetList()
        {
            var Pets = _repository.GetAllPets();
            ViewBag.PetList = new MultiSelectList(Pets, "PetId", "TypeOfAnimal", "Name", "TypeOfFood");
        }
    }
}