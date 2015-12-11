using System;
using System.Web.Mvc;
using HouseAccounting.DTO.Translators;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using HouseAccounting.Web.Models.IncomeCategories;
using HouserAccounting.Business.Classes;

namespace HouseAccounting.Web.Controllers
{
    public class IncomeCategoryController : BaseController
    {
        private readonly IIncomeCategoryRepository categoryRepository;
  
        public IncomeCategoryController(
            IIncomeCategoryRepository categoryRepository, 
            IPersonRepository personRepository,
            ITranslator translator)
            : base(personRepository, translator)
        {
            this.categoryRepository = categoryRepository;
        }

        // GET: Category
        public ActionResult Index()
        {
            IncomeCategoryListViewModel model = new IncomeCategoryListViewModel(categoryRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            IncomeCategoryDetailsViewModel model = new IncomeCategoryDetailsViewModel(id, categoryRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            IncomeCategoryCreateViewModel model = new IncomeCategoryCreateViewModel(personRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(IncomeCategoryCreateViewModel model)
        {
            try
            {
                TryUpdateModel(model.Category);
                var category = translator.TranslateTo<IncomeCategory>(model.Category);
                category.Person = personRepository.FindById(model.SelectedPersonId);
                categoryRepository.Add(category);

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        // GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            IncomeCategoryEditViewModel model = new IncomeCategoryEditViewModel(id, categoryRepository, personRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IncomeCategoryEditViewModel model)
        {
            try
            {
                TryUpdateModel(model.Category);
                var category = translator.TranslateTo<IncomeCategory>(model.Category);
                if (model.SelectedPersonId > 0)
                {
                    var personEntity = personRepository.FindById(model.SelectedPersonId);
                    category.Person = translator.TranslateTo<Person>(personEntity);
                }

                categoryRepository.Update(category);

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
            IncomeCategoryDeleteViewModel model = new IncomeCategoryDeleteViewModel(id, categoryRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IncomeCategoryDeleteViewModel model)
        {
            try
            {
                TryUpdateModel(model.Category);
                var category = translator.TranslateTo<IncomeCategory>(model.Category);
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
