using System;
using System.Web.Mvc;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories;
using HouseAccounting.Infrastructure.Repositories.Interfaces;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using HouseAccounting.Web.Models.Persons;
using HouserAccounting.Business.Classes;
using HouserAccounting.Business.Repositories;

namespace HouseAccounting.Web.Controllers
{
    public class PersonController : Controller
    {
        private readonly IGenericRepository<Person> personRepository;
        private readonly ITranslator translator;

        public PersonController(IGenericRepository<Person> personRepository, ITranslator translator)
        {
            this.personRepository = personRepository;
            this.translator = translator;
        }

        // GET: Person
        public ActionResult Index()
        {
            PersonListViewModel model = new PersonListViewModel(personRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // GET: Person/Details/5
        public ActionResult Details(int id)
        {
            PersonDetailsViewModel model = new PersonDetailsViewModel(id, personRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // GET: Person/Create
        public ActionResult Create()
        {
            PersonCreateViewModel model = new PersonCreateViewModel();
            return View(model);
        }

        // POST: Person/Create
        [HttpPost]
        public ActionResult Create(PersonCreateViewModel model)
        {
            try
            {
                var person = translator.TranslateTo<Person>(model.Person);
                personRepository.Add(person);

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
            PersonEditViewModel model = new PersonEditViewModel(id, personRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // POST: Person/Edit/5
        [HttpPost]
        public ActionResult Edit(int id, PersonEditViewModel model)
        {
            try
            {
                TryUpdateModel(model.Person);
                var person = translator.TranslateTo<Person>(model.Person);
                personRepository.Update(person);

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        // GET: Person/Delete/5
        public ActionResult Delete(int id)
        {
            PersonDeleteViewModel model = new PersonDeleteViewModel(id, personRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        // POST: Person/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, PersonDeleteViewModel model)
        {
            try
            {
                TryUpdateModel(model.Person);
                var person = translator.TranslateTo<Person>(model.Person);
                personRepository.Remove(person);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}
