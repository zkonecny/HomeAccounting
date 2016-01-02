﻿using HouseAccounting.DTO.Translators;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using HouseAccounting.Web.Models.Expenditures;
using HouserAccounting.Business.Classes;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace HouseAccounting.Web.Controllers
{
    public class ExpenditureController : BaseController
    {
        private IExpenditureRepository expenditureRepository;
        private IExpenditureCategoryRepository expenditureCategoryRepository;

        public ExpenditureController(
            IPersonRepository personRepository,
            ITranslator translator,
            IExpenditureCategoryRepository expenditureCategoryRepository,
            IExpenditureRepository expenditureRepository)
            : base(personRepository, translator)
        {
            this.expenditureCategoryRepository = expenditureCategoryRepository;
            this.expenditureRepository = expenditureRepository;
        }

        public ActionResult Index()
        {
            ExpenditureListViewModel model = new ExpenditureListViewModel(personRepository, translator, expenditureRepository);
            model.LoadViewModelData();
            return View(model);
        }

        public ActionResult Details(int id)
        {
            ExpenditureDetailsViewModel model = new ExpenditureDetailsViewModel(id, expenditureRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        public ActionResult Create()
        {
            ExpenditureCreateViewModel model = new ExpenditureCreateViewModel(personRepository, translator, expenditureCategoryRepository);
            model.LoadViewModelData();
            return View(model);
        }

        public ActionResult CreateForPerson(int personId, int expenditureCategoryId)
        {
            ExpenditureCreateViewModel model = new ExpenditureCreateViewModel(personRepository, translator, 
                expenditureCategoryRepository, personId: personId, expenditureCategoryId: expenditureCategoryId);
            model.LoadViewModelData();
            return View("Create", model);
        }

        [HttpPost]
        public ActionResult Create(ExpenditureCreateViewModel model)
        {
            try
            {
                TryUpdateModel(model.Expenditure);
                var expenditure = translator.TranslateTo<Expenditure>(model.Expenditure);
                if (model.SelectedPersonId > 0)
                {
                    expenditure.Person = personRepository.FindById(model.SelectedPersonId);
                }

                if (model.SelectedCategoryId > 0)
                {
                    expenditure.Category = expenditureCategoryRepository.FindById(model.SelectedCategoryId);
                }

                expenditureRepository.Add(expenditure);

                return RedirectToAction("Index");
            }
            catch (Exception exception)
            {
                return View();
            }
        }

        public ActionResult Edit(int id)
        {
            ExpenditureEditViewModel model = new ExpenditureEditViewModel(id, expenditureRepository, personRepository, translator, expenditureCategoryRepository);
            model.LoadViewModelData();
            return View(model);
        }

        [HttpPost]
        public ActionResult Edit(int id, ExpenditureEditViewModel model)
        {
            try
            {
                TryUpdateModel(model.Expenditure);
                var category = translator.TranslateTo<Expenditure>(model.Expenditure);
                if (model.SelectedPersonId > 0)
                {
                    var personEntity = personRepository.FindById(model.SelectedPersonId);
                    category.Person = translator.TranslateTo<Person>(personEntity);
                }

                if (model.SelectedCategoryId > 0)
                {
                    var categoryEntity = expenditureCategoryRepository.FindById(model.SelectedCategoryId);
                    category.Category = translator.TranslateTo<ExpenditureCategory>(categoryEntity);
                }

                expenditureRepository.Update(category);

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
            ExpenditureDeleteViewModel model = new ExpenditureDeleteViewModel(id, expenditureRepository, translator);
            model.LoadViewModelData();
            return View(model);
        }

        //// POST: Category/Delete/5
        [HttpPost]
        public ActionResult Delete(int id, ExpenditureDeleteViewModel model)
        {
            try
            {
                TryUpdateModel(model.Expenditure);
                var expenditure = translator.TranslateTo<Expenditure>(model.Expenditure);
                expenditureRepository.Remove(expenditure);

                return RedirectToAction("Index");
            }
            catch
            {
                return View();
            }
        }
    }
}