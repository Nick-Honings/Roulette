using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InterfaceLayerBD.Bet;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roulette.ASP.NET.Models;
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
        private static int balance = 500;
        private readonly IUserContainerRepository _userRepo;
        private readonly IBetRepository _betRepository;
        private User user;

        public BetController(IUserContainerRepository userRepo, IBetRepository betRepository)
        {
            this._userRepo = userRepo;
            //context = new BetViewModel();
            this._betRepository = betRepository;
            user = new User("Nick", userRepo.CreateUserDAL(), betRepository.CreateBetDAL())
            {
                Id = 20
            };
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


        // GET: Bet/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Bet/Create
        [HttpPost]
        public IActionResult Create(BetModel model)
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
            context.SingleBets.Add(model);
            

            return RedirectToAction("Index", "Room");
        }

        public ActionResult PlaceColorBet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PlaceColorBet(ColorBetModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            context.ColorBets.Add(model);
            return RedirectToAction("Index", "Room");
        }

        public ActionResult PlaceNeighboursBet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PlaceNeighboursBet(NeighboursBetModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            context.NeighboursBets.Add(model);
            return RedirectToAction("Index", "Room");
        }

        public ActionResult PlaceEvenUnevenBet()
        {
            return View();
        }

        [HttpPost]
        public IActionResult PlaceEvenUnevenBet(EvenUnevenBetModel model)
        {
            if (!ModelState.IsValid)
            {
                return View();
            }

            context.EvenUnevenBets.Add(model);
            return RedirectToAction("Index", "Room");
        }



        [HttpGet]        
        public IActionResult GetBetList()
        {
            return PartialView(context);
        }

        [HttpGet]
        public IActionResult ClearBetList()
        {
            context.ColorBets.Clear();
            context.EvenUnevenBets.Clear();
            context.NeighboursBets.Clear();
            context.SingleBets.Clear();
            return Json("Ok");
        }


    }
}