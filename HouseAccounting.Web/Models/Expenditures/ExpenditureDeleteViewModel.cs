using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;

namespace HouseAccounting.Web.Models.Expenditures
{
    public class ExpenditureDeleteViewModel : ViewModelBase
    {
        private readonly ITranslator translator;
        private readonly int id;
        private readonly IExpenditureRepository expenditureRepository;
        public readonly string Title = "Smazat výdaj";

        public ExpenditureDto Expenditure { get; private set; }

        public ExpenditureDeleteViewModel()
        {
            this.Expenditure = new ExpenditureDto();
        }

        public ExpenditureDeleteViewModel(int id, IExpenditureRepository expenditureRepository, ITranslator translator)
        {
            this.id = id;
            this.expenditureRepository = expenditureRepository;
            this.translator = translator;
        }

        protected override void SetupViewData(int page)
        {
            base.SetupViewData(page);
            PageTitle = Title;
            var category = expenditureRepository.FindById(id);
            Expenditure = translator.TranslateTo<ExpenditureDto>(category);
        }
    }
}