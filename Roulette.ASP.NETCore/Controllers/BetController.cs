using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfaceLayerBD.Bet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roulette.ASP.NETCore.Models;
using Roulette.ASP.NETCore.ViewModels;
using Roulette.Bets;
using Roulette.Users;
using TestDataAccesFactory.Interfaces;

namespace Roulette.ASP.NETCore.Controllers
{
    public class BetController : Controller
    {
        private static BetViewModel context = new BetViewModel();
        private readonly IBetRepository _betRepository;

        public BetController(IBetRepository betRepository)
        {
            //context = new BetViewModel();
            this._betRepository = betRepository;
        }

        // GET: Bet
        public ActionResult Index()
        {
            return View();
        }

        // GET: Bet/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Bet/GetTestResults
        [Route("gettestresult")]
        public IActionResult GetTestResult()
        {
            return new JsonResult("This works");
        }

        [Route("getbetlistpartial")]
        public IActionResult GetBetListPartial()
        {
            return PartialView("~/Views/Bet/_ListBets.cshtml", context);
        }

        // GET: Bet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bet/Create
        [HttpPost]
        public JsonResult Create(TestModel model)
        { 
            if (!ModelState.IsValid)
            {
                return new JsonResult("Not Ok");
            }                     

            //context.BetModels.Add(model);

            return new JsonResult("Ok");
            
        }

        // GET: Bet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpGet]        
        public IActionResult GetBetList()
        {
            return PartialView(context.BetModels);
        }

        // POST: Bet/Edit/5
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

        // GET: Bet/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Bet/Delete/5
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

        [HttpPost]
        public IActionResult UpdateViewResult()
        {
            //this.context.BetModels.Add(model);
            return PartialView("_Index", context.BetModels);
        }
    }
}