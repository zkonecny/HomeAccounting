using System.Collections.Generic;
using System.Linq;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;

namespace HouseAccounting.Web.Models.Expenditures
{
    public class ExpenditureEditViewModel : ExpenditureDetailsViewModel
    {
        private readonly IPersonRepository personRepository;
        private readonly IExpenditureCategoryRepository expenditureCategoryRepository;

        public IEnumerable<PersonDto> Persons { get; private set; }

        public IEnumerable<CategoryDto> Categories { get; private set; }

        public int SelectedPersonId { get; set; }

        public int SelectedCategoryId { get; set; }

        public ExpenditureEditViewModel()
        {
        }

        public ExpenditureEditViewModel(int personId, IExpenditureRepository expenditureRepository, IPersonRepository personRepository,
            ITranslator translator, IExpenditureCategoryRepository expenditureCategoryRepository)
            : base(personId, expenditureRepository, translator)
        {
            this.personRepository = personRepository;
            this.expenditureCategoryRepository = expenditureCategoryRepository;
        }

        protected override void SetupViewData()
        {
            base.SetupViewData();
            PageTitle = Title;
            var persons = personRepository.GetAll();
            var personList = persons.Select(person => translator.TranslateTo<PersonDto>(person)).ToList();
            personList.Insert(0, new PersonDto());
            Persons = personList;
            if (Expenditure.Person != null)
            {
                this.SelectedPersonId = Expenditure.Person.Id;
            }

            var categories = expenditureCategoryRepository.GetAll();
            Categories = categories.Select(category => translator.TranslateTo<CategoryDto>(category)).ToList();
            
            if (Expenditure.Category != null)
            {
                this.SelectedCategoryId = Expenditure.Category.Id;
            }
        }
    }
}