using System.Collections.Generic;
using System.Linq;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;

namespace HouseAccounting.Web.Models.Incomes
{
    public class IncomeEditViewModel : IncomeDetailsViewModel
    {
        private readonly IPersonRepository personRepository;
        private readonly IIncomeCategoryRepository incomeCategoryRepository;

        public IEnumerable<PersonDto> Persons { get; private set; }

        public IEnumerable<CategoryDto> Categories { get; private set; }

        public int SelectedPersonId { get; set; }

        public int SelectedCategoryId { get; set; }

        public IncomeEditViewModel()
        {
        }

        public IncomeEditViewModel(int personId, IIncomeRepository incomeRepository, IPersonRepository personRepository,
            ITranslator translator, IIncomeCategoryRepository incomeCategoryRepository)
            : base(personId, incomeRepository, translator)
        {
            this.personRepository = personRepository;
            this.incomeCategoryRepository = incomeCategoryRepository;
        }

        protected override void SetupViewData(int page)
        {
            base.SetupViewData(page);
            PageTitle = Title;
            var persons = personRepository.GetAll();
            var personList = persons.Select(person => translator.TranslateTo<PersonDto>(person)).ToList();
            personList.Insert(0, new PersonDto());
            Persons = personList;
            if (Income.Person != null)
            {
                this.SelectedPersonId = Income.Person.Id;
            }

            var categories = incomeCategoryRepository.GetAll();
            Categories = categories.Select(category => translator.TranslateTo<CategoryDto>(category)).ToList();
            
            if (Income.Category != null)
            {
                this.SelectedCategoryId = Income.Category.Id;
            }
        }
    }
}