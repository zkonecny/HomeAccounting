using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;

namespace HouseAccounting.Web.Models.ExpenditureCategories
{
    public class ExpenditureCategoryDetailsViewModel : ViewModelBase
    {
        protected readonly ITranslator translator;
        protected readonly int id;
        protected readonly IExpenditureCategoryRepository repository;
        public readonly string Title = "Detail osoby";

        public CategoryDto Category { get; private set; }

        public ExpenditureCategoryDetailsViewModel()
        {
            Category = new CategoryDto();
        }

        public ExpenditureCategoryDetailsViewModel(int id, IExpenditureCategoryRepository repository, ITranslator translator)
        {
            this.id = id;
            this.repository = repository;
            this.translator = translator;
        }

        protected override void SetupViewData(int page)
        {
            base.SetupViewData(page);
            PageTitle = Title;
            var category = this.repository.FindById(id);
            Category = this.translator.TranslateTo<CategoryDto>(category);
        }
    }
}