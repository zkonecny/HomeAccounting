using System.Collections.Generic;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;

namespace HouseAccounting.Web.Models.Expenditures
{
    public class ExpenditureListViewModel : ViewModelBase
    {
        private readonly ITranslator translator;
        private readonly IPersonRepository personRepository;
        private readonly IExpenditureRepository expenditureRepository;
        public readonly string Title = "Seznam výdajů";

        public IEnumerable<ExpenditureDto> Expenditures { get; private set; }

        public ExpenditureListViewModel(
            IPersonRepository personRepository, 
            ITranslator translator,
            IExpenditureRepository expenditureRepository)
        {
            this.personRepository = personRepository;
            this.translator = translator;
            this.expenditureRepository = expenditureRepository;
        }

        protected override void SetupViewData()
        {
            base.SetupViewData();
            LoadData();
        }

        private void LoadData()
        {
            PageTitle = Title;

            var expenditures = expenditureRepository.GetAll();
            Expenditures = translator.TranslateTo<IEnumerable<ExpenditureDto>>(expenditures);
        }
    }
}