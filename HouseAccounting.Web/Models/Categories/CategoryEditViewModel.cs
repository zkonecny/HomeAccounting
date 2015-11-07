using HouseAccounting.DTO.Translators;
using HouserAccounting.Business.Classes;
using HouserAccounting.Business.Repositories;

namespace HouseAccounting.Web.Models.Categories
{
    public class CategoryEditViewModel : CategoryDetailsViewModel
    {
        public CategoryEditViewModel()
        {
        }

        public CategoryEditViewModel(int personId, IGenericRepository<Category> repository, ITranslator translator)
            : base(personId, repository, translator)
        {

        }
    }
}