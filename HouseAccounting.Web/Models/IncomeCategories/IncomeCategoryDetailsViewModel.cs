using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;

namespace HouseAccounting.Web.Models.IncomeCategories
{
    public class IncomeCategoryDetailsViewModel : ViewModelBase
    {
        protected readonly ITranslator translator;
        protected readonly int id;
        protected readonly IIncomeCategoryRepository repository;
        public readonly string Title = "Detail osoby";

        public CategoryDto Category { get; private set; }

        public IncomeCategoryDetailsViewModel()
        {
            Category = new CategoryDto();
        }

        public IncomeCategoryDetailsViewModel(int id, IIncomeCategoryRepository repository, ITranslator translator)
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