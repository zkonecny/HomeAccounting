using System.Linq;
using System.Collections.Generic;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;

namespace HouseAccounting.Web.Models.Incomes
{
    public class IncomeListViewModel : ViewModelBase
    {
        private readonly ITranslator translator;
        private readonly IPersonRepository personRepository;
        private readonly IIncomeRepository incomeRepository;
        public readonly string Title = "Seznam příjmů";

        public IEnumerable<IncomeDto> Incomes { get; private set; }

        public IncomeListViewModel(
            IPersonRepository personRepository, 
            ITranslator translator,
            IIncomeRepository incomeRepository)
        {
            this.personRepository = personRepository;
            this.translator = translator;
            this.incomeRepository = incomeRepository;
        }

        protected override void SetupViewData(int page)
        {
            base.SetupViewData(page);
            LoadData();
        }

        private void LoadData()
        {
            PageTitle = Title;

            var incomes = incomeRepository.GetAll().OrderByDescending(income => income.Created);
            Incomes = translator.TranslateTo<IEnumerable<IncomeDto>>(incomes);
        }
    }
}