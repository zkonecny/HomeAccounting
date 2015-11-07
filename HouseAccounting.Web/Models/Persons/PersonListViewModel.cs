﻿using System.Collections.Generic;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouserAccounting.Business.Classes;
using HouserAccounting.Business.Repositories;

namespace HouseAccounting.Web.Models.Persons
{
    public class PersonListViewModel : ViewModelBase
    {
        private readonly ITranslator translator;
        private readonly IGenericRepository<Person> repository;
        public readonly string Title = "Seznam osob";

        public IEnumerable<PersonDto> Persons { get; private set; }

        public PersonListViewModel(IGenericRepository<Person> repository, ITranslator translator)
        {
            this.repository = repository;
            this.translator = translator;
        }

        protected override void SetupViewData()
        {
            base.SetupViewData();
            LoadData();
        }

        private void LoadData()
        {
            PageTitle = Title;

            var persons = repository.GetAll();

            Persons = translator.TranslateTo<IEnumerable<PersonDto>>(persons);
        }
    }
}