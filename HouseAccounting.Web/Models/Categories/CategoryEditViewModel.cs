using HouseAccounting.DTO.Translators;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using HouserAccounting.Business.Classes;
using HouserAccounting.Business.Repositories;

namespace HouseAccounting.Web.Models.Categories
{
    public class CategoryEditViewModel : CategoryDetailsViewModel
    {
        public CategoryEditViewModel()
        {
        }

        public CategoryEditViewModel(int personId, ICategoryRepository repository, ITranslator translator)
            : base(personId, repository, translator)
        {

        }
    }
}