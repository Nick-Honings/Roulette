using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Roulette.ASP.NETCore.Models;
using Roulette.ASP.NETCore.Utilities;
using Roulette.ASP.NETCore.ViewModels;
using TestDataAccesFactory.Interfaces;

namespace Roulette.ASP.NETCore.Controllers
{
    public class AdminController : Controller
    {
        private readonly IAdminRepository _repository;
        private readonly IUserContainerRepository _containerRepository;

        public AdminController(IAdminRepository repository)
        {
            this._repository = repository;
        }


        // GET: Admin
        public ActionResult Index()
        {
            return View(GetInfo());
        }

        // GET: Admin/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Admin/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Admin/Create
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

        // GET: Admin/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Admin/Edit/5
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

        // GET: Admin/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Admin/Delete/5
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

        public DataSet GetInfo()
        {
            return _repository.CreateAdminDAL().GetUserAndBetDetails();
        }

        public UserViewModel FillViewModel()
        {
            var userdata = _repository.CreateAdminDAL().GetUserAndBetDetails();
            UserViewModel model = new UserViewModel();
            model.betDetails = new List<BetDetailsModel>();
            model.detailsModel = new List<UserDetailsModel>();

            for (int i = 0; i < userdata.Tables[0].Rows.Count; i++)
            {
                UserDetailsModel userdetails = new UserDetailsModel();
                BetDetailsModel betdetails = new BetDetailsModel();


                // Have to check if any field is null
                if(!userdata.Tables[0].Rows[i][0].Equals(DBNull.Value))
                {
                    userdetails.Id = (int)userdata.Tables[0].Rows[i][0];
                }
                if (!userdata.Tables[0].Rows[i][1].Equals(DBNull.Value))
                {
                    userdetails.Name = userdata.Tables[0].Rows[i][1].ToString();
                }
                if (!userdata.Tables[0].Rows[i][2].Equals(DBNull.Value))
                {
                    userdetails.Email = userdata.Tables[0].Rows[i][2].ToString();
                }
                if (!userdata.Tables[0].Rows[i][3].Equals(DBNull.Value))
                {
                    userdetails.Password = userdata.Tables[0].Rows[i][3].ToString();
                }
                if (!userdata.Tables[0].Rows[i][4].Equals(DBNull.Value))
                {
                    userdetails.Age = (int)userdata.Tables[0].Rows[i][4];
                }
                if (!userdata.Tables[0].Rows[i][5].Equals(DBNull.Value))
                {
                    userdetails.IsActive = (bool)userdata.Tables[0].Rows[i][5];
                }
                if (!userdata.Tables[0].Rows[i][6].Equals(DBNull.Value))
                {
                    userdetails.Balance = Convert.ToDecimal(userdata.Tables[0].Rows[i][6]);
                }
                if (!userdata.Tables[0].Rows[i][7].Equals(DBNull.Value))
                {
                    betdetails.Stake = Convert.ToDecimal(userdata.Tables[0].Rows[i][7]);
                }
                if (!userdata.Tables[0].Rows[i][8].Equals(DBNull.Value))
                {
                    betdetails.Odd = (double)userdata.Tables[0].Rows[i][8];
                }
                if (!userdata.Tables[0].Rows[i][9].Equals(DBNull.Value))
                {
                    betdetails.Color = (int)userdata.Tables[0].Rows[i][9];
                }
                if (!userdata.Tables[0].Rows[i][10].Equals(DBNull.Value))
                {
                    betdetails.Number = (int)userdata.Tables[0].Rows[i][10];
                }
                if (!userdata.Tables[0].Rows[i][11].Equals(DBNull.Value))
                {
                    betdetails.Even = (bool)userdata.Tables[0].Rows[i][11];
                }
                if (!userdata.Tables[0].Rows[i][12].Equals(DBNull.Value))
                {
                    betdetails.FirstNumber = (int)userdata.Tables[0].Rows[i][12];
                }
                if (!userdata.Tables[0].Rows[i][13].Equals(DBNull.Value))
                {
                    betdetails.FirstNumber = (int)userdata.Tables[0].Rows[i][13];
                }

                model.detailsModel.Add(new UserDetailsModel());
                model.betDetails.Add(new BetDetailsModel());                
            }


            return model;
        }
    }
}