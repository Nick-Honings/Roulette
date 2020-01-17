using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roulette.ASP.NETCore.Models;
using TestDataAccesFactory.Interfaces;
using Roulette.Users;

namespace Roulette.ASP.NETCore.Controllers
{
    public class AdminPanelController : Controller
    {
        private readonly IUserContainerRepository _repo;
        private UserContainer container;

        public AdminPanelController(IUserContainerRepository containerRepository)
        {
            this._repo = containerRepository;
            container = new UserContainer(_repo.CreateUserContainerDAL(), _repo.CreateUserDAL(), _repo.CreateBetDAL());
        }

        // GET: AdminPanel
        public ActionResult Index()
        {
            var usermodels = new List<UserModel>();
            foreach (var user in container.Users)
            {
                usermodels.Add(CreateUserModel(user));
            }
            return View(usermodels);
        }

        // GET: AdminPanel/Details/5
        public ActionResult Details(int id)
        {
            return View(CreateUserModel(container.GetUserById(id)));
        }

        // GET: AdminPanel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(UserModel model)
        {
            try
            {
                // TODO: Add insert logic here
                if (container.AddUser(CreateUser(model)))
                {
                    return RedirectToAction(nameof(Index));
                }

                return RedirectToAction(nameof(Index));
                
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminPanel/Edit/5
        public ActionResult Edit(int id)
        {
            return View(CreateUserModel(container.GetUserById(id)));
        }

        // POST: AdminPanel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, UserModel model)
        {
            try
            {
                var user = CreateUser(model);   
                user.UpdateProfile();

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: AdminPanel/Delete/5
        public ActionResult Delete(int id)
        {
            return View(CreateUserModel(container.GetUserById(id)));
        }

        // POST: AdminPanel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, UserModel model)
        {
            try
            {
                if (container.RemoveUser(id))
                {
                    return RedirectToAction(nameof(Index));

                }
                // To Do: add exception message to display to the user.
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        public static UserModel CreateUserModel(User user)
        {
            return new UserModel()
            {
                Id = user.Id,
                Name = user.Name,
                Password = user.Password,
                Email = user.Email,
                Age = user.Age,
                IsActive = user.IsActive,
                Balance = user.Balance,               
                RoomId = user.RoomId
            };
        }

        public User CreateUser(UserModel model)
        {
            return new User(model.Name, _repo.CreateUserDAL(), null)
            {
                Id = model.Id,
                Password = model.Password,
                Email = model.Email,
                Age = model.Age,
                IsActive = model.IsActive,
                Balance = model.Balance,
            };
        }
    }
}