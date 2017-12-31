using System.Web.Mvc;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;

namespace Web.Controllers
{
    public class MarketDataController : BaseController
    {
        public MarketDataController(ILogger logger)
            : base(logger)
        {
        }

        public ActionResult Index()
        {
            return View();
        }

        public ActionResult ListExchangeRates()
        {
            return View();
        }

        public ActionResult ListPrices()
        {
            return View();
        }
    }
}