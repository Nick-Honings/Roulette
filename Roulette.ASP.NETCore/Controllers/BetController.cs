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
        private readonly IUserContainerRepository _userRepo;
        private readonly IBetRepository _betRepository;
        private static List<SingleNumberBetModel> models = new List<SingleNumberBetModel>();

        public BetController(IUserContainerRepository userRepo, IBetRepository betRepository)
        {
            this._userRepo = userRepo;
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
            return PartialView("~/Views/Bet/_ListBets.cshtml", models);
        }

        // GET: Bet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bet/Create
        [HttpPost]
        public IActionResult Create(SingleNumberBetModel model)
        { 
            if (!ModelState.IsValid)
            {
                return new JsonResult("Not Ok");
            }

            //context.BetModels.Add(model);

            return new JsonResult("Ok");
            
        }

        public ActionResult PlaceBet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PlaceBet(SingleNumberBetModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }
            models.Add(model);

            return RedirectToAction("Index", "Room");
        }

        // GET: Bet/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        [HttpGet]        
        public IActionResult GetBetList()
        {
            return PartialView(models);
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