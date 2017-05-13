using System.Collections.Generic;
using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;

namespace HouseAccounting.Web.Models.ExpenditureCategories
{
    public class ExpenditureCategoryListViewModel : ViewModelBase
    {
        private readonly ITranslator translator;
        private readonly IExpenditureCategoryRepository repository;
        public readonly string Title = "Seznam kategorií";

        public IEnumerable<CategoryDto> Categories { get; private set; }

        public ExpenditureCategoryListViewModel(IExpenditureCategoryRepository repository, ITranslator translator)
        {
            this.repository = repository;
            this.translator = translator;
        }

        protected override void SetupViewData(int page)
        {
            base.SetupViewData(page);
            LoadData();
        }

        private void LoadData()
        {
            PageTitle = Title;

            var categories = this.repository.GetAll();

            Categories = this.translator.TranslateTo<IEnumerable<CategoryDto>>(categories);
        }
    }
}