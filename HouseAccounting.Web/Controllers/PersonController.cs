using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using HouseAccounting.Infrastructure.Repositories;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using HouseAccounting.Model.Classes;
using HouseAccounting.Model.Repositories;

namespace HouseAccounting.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly IDbProvider dbProvider;
        private readonly IGenericRepository<Person> userRepository;

        public PersonController()
        {
            dbProvider = new DbProvider();
            userRepository = new GenericRepository<Person>(dbProvider);
        }

        // GET: Person
        public ActionResult Index()
        {
            var users = userRepository.GetAll();
            return View(users);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(Person user)
        {
            try
            {
                userRepository.Add(user);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add update logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, FormCollection collection)
        {
            try
            {
                // TODO: Add delete logic here

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
