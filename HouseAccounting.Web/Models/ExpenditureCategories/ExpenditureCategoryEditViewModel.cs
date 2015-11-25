﻿using System.Collections.Generic;
using System.Linq;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;

namespace HouseAccounting.Web.Models.ExpenditureCategories
{
    public class ExpenditureCategoryEditViewModel : ExpenditureCategoryDetailsViewModel
    {
        private readonly IPersonRepository personRepository;

        public IEnumerable<PersonDto> Persons { get; private set; }

        public int SelectedPersonId { get; set; }

        public ExpenditureCategoryEditViewModel()
        {
        }

        public ExpenditureCategoryEditViewModel(int personId, IExpenditureCategoryRepository repository, IPersonRepository personRepository,
            ITranslator translator)
            : base(personId, repository, translator)
        {
            this.personRepository = personRepository;
        }

        protected override void SetupViewData()
        {
            base.SetupViewData();
            PageTitle = Title;
            var persons = personRepository.GetAll();
            var personList = persons.Select(person => translator.TranslateTo<PersonDto>(person)).ToList();
            personList.Insert(0, new PersonDto());
            Persons = personList;
            if (Category.Person != null)
            {
                this.SelectedPersonId = Category.Person.Id;
            }
        }
    }
}