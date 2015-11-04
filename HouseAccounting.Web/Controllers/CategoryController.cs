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
    public class CategoryController : Controller
    {
        private readonly IDbProvider dbProvider;
        private readonly IGenericRepository<Category> categoryRepository;

        public CategoryController()
        {
            dbProvider = new DbProvider();
            categoryRepository = new GenericRepository<Category>(dbProvider);
        }

        // GET: Category
        public ActionResult Index()
        {
            var categories = categoryRepository.GetAll();
            return View(categories);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(Category category)
        {
            try
            {
                categoryRepository.Add(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Category/Edit/5
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

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            var category = categoryRepository.FindById(id);
            return View(category);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, Category category)
        {
            try
            {
                categoryRepository.Remove(category);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
