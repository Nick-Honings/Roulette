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
            
            return View(container.Users);
        }

        // GET: AdminPanel/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AdminPanel/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: AdminPanel/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                // TODO: Add insert logic here

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
            return View();
        }

        // POST: AdminPanel/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

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
            return View();
        }

        // POST: AdminPanel/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}