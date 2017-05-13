using System;
using System.Collections.Generic;
using System.Linq;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;

namespace HouseAccounting.Web.Models.Incomes
{
    public class IncomeCreateViewModel : ViewModelBase
    {
        private readonly IPersonRepository personRepository;
        private readonly ITranslator translator;
        private readonly IIncomeCategoryRepository incomeCategoryRepository;
        public readonly string Title = "Nový příjem";

        public IncomeDto Income { get; set; }

        public IEnumerable<PersonDto> Persons { get; private set; }

        public IEnumerable<CategoryDto> Categories { get; private set; }

        public int SelectedPersonId { get; set; }

        public int SelectedCategoryId { get; set; }

        public IncomeCreateViewModel()
        {

        }

        public IncomeCreateViewModel(
            IPersonRepository personRepository,
            ITranslator translator,
            IIncomeCategoryRepository incomeCategoryRepository)
        {
            this.personRepository = personRepository;
            this.translator = translator;
            this.incomeCategoryRepository = incomeCategoryRepository;
            Income = new IncomeDto();
            Income.Created = DateTime.Now;
        }

        protected override void SetupViewData(int page)
        {
            base.SetupViewData(page);
            PageTitle = Title;
            var persons = personRepository.GetAll();
            var personList = persons.Select(person => translator.TranslateTo<PersonDto>(person)).ToList();
            personList.Insert(0, new PersonDto());
            Persons = personList;

            var categories = incomeCategoryRepository.GetAll();
            Categories = categories.Select(category => translator.TranslateTo<CategoryDto>(category)).ToList();
        }
    }
}