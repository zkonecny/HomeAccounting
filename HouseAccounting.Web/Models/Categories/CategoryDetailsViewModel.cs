using HouseAccounting.DTO.Translators;
using HouseAccounting.DTOS;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using HouserAccounting.Business.Classes;
using HouserAccounting.Business.Repositories;

namespace HouseAccounting.Web.Models.Categories
{
    public class CategoryDetailsViewModel : ViewModelBase
    {
        private readonly ITranslator translator;
        private readonly int id;
        private readonly ICategoryRepository repository;
        public readonly string Title = "Detail osoby";

        public CategoryDto Category { get; private set; }

        public CategoryDetailsViewModel()
        {
            Category = new CategoryDto();
        }

        public CategoryDetailsViewModel(int id, ICategoryRepository repository, ITranslator translator)
        {
            this.id = id;
            this.repository = repository;
            this.translator = translator;
        }

        protected override void SetupViewData()
        {
            base.SetupViewData();
            PageTitle = Title;
            var category = this.repository.FindById(id);
            Category = this.translator.TranslateTo<CategoryDto>(category);
        }
    }
}