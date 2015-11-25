using System;
using System.Web.Mvc;
using HouseAccounting.DTO.Translators;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using HouseAccounting.Web.Models.ExpenditureCategories;
using HouserAccounting.Business.Classes;
using HouserAccounting.Business.Repositories;
using LiteDB;

namespace HouseAccounting.Web.Controllers
{
    public class ExpenditureCategoryController : Controller
    {
        private readonly IExpenditureCategoryRepository categoryRepository;
        private readonly IPersonRepository personRepository;
        private readonly ITranslator translator;

        public ExpenditureCategoryController(IExpenditureCategoryRepository categoryRepository, IPersonRepository personRepository, ITranslator translator)
        {
            this.categoryRepository = categoryRepository;
            this.personRepository = personRepository;
            this.translator = translator;
        }

        // GET: Category
        public ActionResult Index()
        {
            ExpenditureCategoryListViewModel model = new ExpenditureCategoryListViewModel(categoryRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            ExpenditureCategoryDetailsViewModel model = new ExpenditureCategoryDetailsViewModel(id, categoryRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            ExpenditureCategoryCreateViewModel model = new ExpenditureCategoryCreateViewModel(personRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(ExpenditureCategoryCreateViewModel model)
        {
            try
            {
                TryUpdateModel(model.Category);
                var category = translator.TranslateTo<ExpenditureCategory>(model.Category);
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
            ExpenditureCategoryEditViewModel model = new ExpenditureCategoryEditViewModel(id, categoryRepository, personRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, ExpenditureCategoryEditViewModel model)
        {
            try
            {
                TryUpdateModel(model.Category);
                var category = translator.TranslateTo<ExpenditureCategory>(model.Category);
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
            ExpenditureCategoryDeleteViewModel model = new ExpenditureCategoryDeleteViewModel(id, categoryRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ExpenditureCategoryDeleteViewModel model)
        {
            try
            {
                TryUpdateModel(model.Category);
                var category = translator.TranslateTo<ExpenditureCategory>(model.Category);
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
