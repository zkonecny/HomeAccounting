using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;

namespace HouseAccounting.Web.Models.Expenditures
{
    public class ExpenditureDetailsViewModel : ViewModelBase
    {
        protected readonly ITranslator translator;
        protected readonly int id;
        protected readonly IExpenditureRepository expenditureRepository;
        public readonly string Title = "Detail výdaje";

        public ExpenditureDto Expenditure { get; private set; }

        public ExpenditureDetailsViewModel()
        {
            Expenditure = new ExpenditureDto();
        }

        public ExpenditureDetailsViewModel(int id, IExpenditureRepository expenditureRepository, ITranslator translator)
        {
            this.id = id;
            this.expenditureRepository = expenditureRepository;
            this.translator = translator;
        }

        protected override void SetupViewData()
        {
            base.SetupViewData();
            PageTitle = Title;
            var expenditure = expenditureRepository.FindById(id);
            Expenditure = this.translator.TranslateTo<ExpenditureDto>(expenditure);
        }
    }
}