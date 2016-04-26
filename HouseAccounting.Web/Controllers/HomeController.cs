using HouseAccounting.Business.Services;
using HouseAccounting.DTO.Translators;
using HouseAccounting.Infrastructure.Repositories.Repositories;
using HouseAccounting.Web.Models.Home;
using System.Diagnostics;
using System.Web.Mvc;

namespace HouseAccounting.Web.Controllers
{
    public class HomeController : BaseController
    {
        private IExpenditureCategoryRepository expenditureCategoryRepository;
        private IMonthlyStatisticsService monthlyStatisticsService;

        public HomeController(
            IPersonRepository personRepository,
            ITranslator translator,
            IExpenditureCategoryRepository expenditureCategoryRepository,
            IMonthlyStatisticsService monthlyStatisticsService)
            : base(personRepository, translator)
        {
            this.expenditureCategoryRepository = expenditureCategoryRepository;
            this.monthlyStatisticsService = monthlyStatisticsService;
        }

        public ActionResult Index()
        {
            Stopwatch w = new Stopwatch();
            w.Start();
            HomeIndexViewModel model = new HomeIndexViewModel(personRepository, translator,
                expenditureCategoryRepository, monthlyStatisticsService);
            model.LoadViewModelData();
            w.Stop();
            return View(model);
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }
    }
}