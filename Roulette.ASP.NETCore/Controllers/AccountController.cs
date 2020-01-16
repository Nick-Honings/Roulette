using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roulette.ASP.NETCore.ViewModels;
using Roulette.Users;
using TestDataAccesFactory.Interfaces;

namespace Roulette.ASP.NETCore.Controllers
{
    public class AccountController : Controller
    {
        private readonly IUserContainerRepository _containerRepository;

        public AccountController(IUserContainerRepository containerRepository)
        {
            this._containerRepository = containerRepository;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult Login(LoginViewModel model)
        {
            if (ModelState.IsValid)
            {
                int id = _containerRepository.CreateUserDAL().VerifyLogin(model.Name, model.Password);

                if (id == -1)
                {
                    ModelState.AddModelError("Password", "Invalid login attempt.");
                    return View("Index");
                }
                HttpContext.Session.SetString("userId", model.Name);
            }
            else
            {
                return View("Index");                            
            }
            return RedirectToAction("Index", "Home");
        }


        [HttpPost]
        public IActionResult Register(RegisterViewModel model)
        {
            if (ModelState.IsValid)
            {
                User user = new User(model.Name, null, null)
                {
                    Password = model.Password,
                    Email = model.Email,
                    Age = model.Age,
                    IsActive = true,
                    Balance = 0
                };
                if (_containerRepository.CreateUserContainerDAL().AddUser(user) == false)
                {
                    ModelState.AddModelError("Password", "Registration failed.");
                    return View("Registration");
                }                
            }
            else
            {
                return View("Registration");
            }
            return RedirectToAction("Index", "Account");
        }

        public IActionResult Register()
        {
            ViewData["Message"] = "Registration Page";
            
            return View();
        }

        public IActionResult Logout()
        {
            HttpContext.Session.Clear();
            return View("Index");
        }
        public void ValidationMessage(string key, string alert, string value)
        {
            try
            {
                TempData.Remove(key);
                TempData.Add(key, value);
                TempData.Add("alertType", alert);
            }
            catch
            {
                Debug.WriteLine("TempDataMessage Error");
            }

        }
    }
}