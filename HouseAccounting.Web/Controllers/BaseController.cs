using HouseAccounting.DTO.Translators;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using System.Web.Mvc;

namespace HouseAccounting.Web.Controllers
{
    public class BaseController : Controller
    {
        protected readonly IPersonRepository personRepository;
        protected readonly ITranslator translator;

        public BaseController(IPersonRepository personRepository, ITranslator translator)
        {
            this.personRepository = personRepository;
            this.translator = translator;
        }
    }
}