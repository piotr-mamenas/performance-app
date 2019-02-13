using System.Web.Mvc;
using Core.Interfaces;
using Ninject.Extensions.Logging;
using Web.Controllers.Templates;

namespace Web.Controllers
{
    [Authorize]
    [RoutePrefix("marketdata")]
    public class MarketDataController : BaseController
    {
        public MarketDataController(IUnitOfWork unitOfWork, ILogger logger)
            : base(logger, unitOfWork)
        {
        }

        [Route("")]
        public ActionResult Index()
        {
            return RedirectToAction("ListPrices");
        }

        [Route("exchangerates")]
        public ActionResult ListExchangeRates()
        {
            return View();
        }

        [Route("prices")]
        public ActionResult ListPrices()
        {
            return View();
        }
    }
}