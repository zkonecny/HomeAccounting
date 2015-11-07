using System;
using System.Web.Mvc;
using HouseAccounting.DTO.Translators;
using HouseAccounting.Web.Models.Categories;
using HouserAccounting.Business.Classes;
using HouserAccounting.Business.Repositories;

namespace HouseAccounting.Web.Controllers
{
    public class CategoryController : Controller
    {
        private readonly IGenericRepository<Category> categoryRepository;
        private readonly IGenericRepository<Person> pesonRepository;
        private readonly ITranslator translator;

        public CategoryController(IGenericRepository<Category> categoryRepository, IGenericRepository<Person> pesonRepository, ITranslator translator)
        {
            this.categoryRepository = categoryRepository;
            this.pesonRepository = pesonRepository;
            this.translator = translator;
        }

        // GET: Category
        public ActionResult Index()
        {
            CategoryListViewModel model = new CategoryListViewModel(categoryRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            CategoryDetailsViewModel model = new CategoryDetailsViewModel(id, categoryRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            CategoryCreateViewModel model = new CategoryCreateViewModel(pesonRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(CategoryCreateViewModel model)
        {
            try
            {
                TryUpdateModel(model.Category);
                var person = translator.TranslateTo<Category>(model.Category);
                categoryRepository.Add(person);

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
            CategoryEditViewModel model = new CategoryEditViewModel(id, categoryRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, CategoryEditViewModel model)
        {
            try
            {
                TryUpdateModel(model.Category);
                var person = translator.TranslateTo<Category>(model.Category);
                categoryRepository.Update(person);

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        // GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            CategoryDeleteViewModel model = new CategoryDeleteViewModel(id, categoryRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, CategoryDeleteViewModel model)
        {
            try
            {
                TryUpdateModel(model.Category);
                var category = translator.TranslateTo<Category>(model.Category);
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
