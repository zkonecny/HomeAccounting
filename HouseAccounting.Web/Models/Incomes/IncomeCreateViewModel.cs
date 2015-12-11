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
        public readonly string Title = "Nová příjem";

        public IncomeDto Income { get; set; }

        public IEnumerable<PersonDto> Persons { get; private set; }

        public IEnumerable<CategoryDto> Categories { get; private set; }

        public int SelectedPersonId { get; set; }

        public int SelectedCategoryId { get; set; }

        public IncomeCreateViewModel()
        {
            Income = new IncomeDto();
            Persons = new List<PersonDto>();
            Categories = new List<CategoryDto>();
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
        }

        protected override void SetupViewData()
        {
            base.SetupViewData();
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