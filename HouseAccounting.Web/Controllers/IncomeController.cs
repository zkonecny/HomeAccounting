using HouseAccounting.DTO.Translators;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using HouseAccounting.Web.Models.Incomes;
using HouseAccounting.Business.Classes;
using System;
using System.Web.Mvc;

namespace HouseAccounting.Web.Controllers
{
    public class IncomeController : BaseController
    {
        private IIncomeRepository incomeRepository;
        private IIncomeCategoryRepository incomeCategoryRepository;

        public IncomeController(
            IPersonRepository personRepository,
            ITranslator translator,
            IIncomeCategoryRepository incomeCategoryRepository,
            IIncomeRepository incomeRepository)
            : base(personRepository, translator)
        {
            this.incomeCategoryRepository = incomeCategoryRepository;
            this.incomeRepository = incomeRepository;
        }

        // GET: Income
        public ActionResult Index()
        {
            IncomeListViewModel model = new IncomeListViewModel(personRepository, translator, incomeRepository);
            model.LoadViewModelData();
            return View(model);
        }

        // GET: Category/Details/5
        public ActionResult Details(int id)
        {
            IncomeDetailsViewModel model = new IncomeDetailsViewModel(id, incomeRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // GET: Category/Create
        public ActionResult Create()
        {
            IncomeCreateViewModel model = new IncomeCreateViewModel(personRepository, translator, incomeCategoryRepository);
            model.LoadViewModelData();
            return View(model);
        }

        // POST: Category/Create
        [HttpPost]
        public ActionResult Create(IncomeCreateViewModel model)
        {
            try
            {
                TryUpdateModel(model.Income);
                var income = translator.TranslateTo<Income>(model.Income);
                if (model.SelectedPersonId > 0)
                {
                    income.Person = personRepository.FindById(model.SelectedPersonId);
                }

                if (model.SelectedCategoryId > 0)
                {
                    income.Category = incomeCategoryRepository.FindById(model.SelectedCategoryId);
                }

                incomeRepository.Add(income);

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        //// GET: Category/Edit/5
        public ActionResult Edit(int id)
        {
            IncomeEditViewModel model = new IncomeEditViewModel(id, incomeRepository, personRepository, translator, incomeCategoryRepository);
            model.LoadViewModelData();
            return View(model);
        }

        //// POST: Category/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, IncomeEditViewModel model)
        {
            try
            {
                TryUpdateModel(model.Income);
                var category = translator.TranslateTo<Income>(model.Income);
                if (model.SelectedPersonId > 0)
                {
                    var personEntity = personRepository.FindById(model.SelectedPersonId);
                    category.Person = translator.TranslateTo<Person>(personEntity);
                }

                if (model.SelectedCategoryId > 0)
                {
                    var categoryEntity = incomeCategoryRepository.FindById(model.SelectedCategoryId);
                    category.Category = translator.TranslateTo<IncomeCategory>(categoryEntity);
                }

                incomeRepository.Update(category);

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        //// GET: Category/Delete/5
        public ActionResult Delete(int id)
        {
            IncomeDeleteViewModel model = new IncomeDeleteViewModel(id, incomeRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        //// POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, IncomeDeleteViewModel model)
        {
            try
            {
                TryUpdateModel(model.Income);
                var income = translator.TranslateTo<Income>(model.Income);
                incomeRepository.Remove(income);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}