using System.Collections.Generic;
using System.Linq;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;

namespace HouseAccounting.Web.Models.ExpenditureCategories
{
    public class ExpenditureCategoryCreateViewModel : ViewModelBase
    {
        private readonly IPersonRepository personRepository;
        private readonly ITranslator translator;
        public readonly string Title = "Nová kategorie";

        public CategoryDto Category { get; set; }

        public IEnumerable<PersonDto> Persons { get; private set; }

        public int SelectedPersonId { get; set; }

        public ExpenditureCategoryCreateViewModel()
        {
            Category = new CategoryDto();
            Persons = new List<PersonDto>();
        }

        public ExpenditureCategoryCreateViewModel(IPersonRepository personRepository, ITranslator translator)
        {
            this.personRepository = personRepository;
            this.translator = translator;
            Category = new CategoryDto();
        }

        protected override void SetupViewData(int page)
        {
            base.SetupViewData(page);
            PageTitle = Title;
            var persons = personRepository.GetAll();
            var personList = persons.Select(person => translator.TranslateTo<PersonDto>(person)).ToList();
            personList.Insert(0, new PersonDto());
            Persons = personList;
        }
    }
}