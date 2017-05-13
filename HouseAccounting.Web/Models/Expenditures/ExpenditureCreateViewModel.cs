using System;
using System.Collections.Generic;
using System.Linq;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;

namespace HouseAccounting.Web.Models.Expenditures
{
    public class ExpenditureCreateViewModel : ViewModelBase
    {
        private readonly IPersonRepository personRepository;
        private readonly ITranslator translator;
        private readonly IExpenditureCategoryRepository expenditureCategoryRepository;
        public readonly string Title = "Nový výdaj";

        public ExpenditureDto Expenditure { get; set; }

        public IEnumerable<PersonDto> Persons { get; private set; }

        public IEnumerable<CategoryDto> Categories { get; private set; }

        public int SelectedPersonId { get; set; }

        public int SelectedCategoryId { get; set; }

        public ExpenditureCreateViewModel()
        {
        }

        public ExpenditureCreateViewModel(
            IPersonRepository personRepository,
            ITranslator translator,
            IExpenditureCategoryRepository expenditureCategoryRepository,
            int personId = 0,
            int expenditureCategoryId = 0)
        {
            this.personRepository = personRepository;
            this.translator = translator;
            this.expenditureCategoryRepository = expenditureCategoryRepository;
            Expenditure = new ExpenditureDto();
            Expenditure.Created = DateTime.Now;
            SelectedPersonId = personId;
            SelectedCategoryId = expenditureCategoryId;
            Persons = new List<PersonDto>();
            Categories = new List<CategoryDto>();
        }

        protected override void SetupViewData(int page)
        {
            base.SetupViewData(page);
            PageTitle = Title;
            if (SelectedPersonId == 0 && SelectedCategoryId == 0)
            {
                SetAllPersons();
                SetAllCategories();
            }
            else
            {
                SetPersons();
                SetCategories();
            }
        }

        private void SetPersons()
        {
            if (SelectedPersonId > 0)
            {
                var person = personRepository.FindById(SelectedPersonId);
                Persons = new PersonDto[] { translator.TranslateTo<PersonDto>(person) };
            }
        }

        private void SetAllPersons()
        {
            var persons = personRepository.GetAll();
            var personList = persons.Select(person => translator.TranslateTo<PersonDto>(person)).ToList();
            personList.Insert(0, new PersonDto());
            Persons = personList;
        }

        private void SetCategories()
        {
            if (SelectedCategoryId > 0)
            {
                var category = expenditureCategoryRepository.FindById(SelectedCategoryId);
                Categories = new CategoryDto[] { translator.TranslateTo<CategoryDto>(category) };
            }
        }

        private void SetAllCategories()
        {
            var categories = expenditureCategoryRepository.GetAll();
            Categories = categories.Select(category => translator.TranslateTo<CategoryDto>(category)).ToList();
        }
    }
}