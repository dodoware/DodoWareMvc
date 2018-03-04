using DodoWare.Mvc.Models.Base;
using DodoWare.Mvc.Models.Discount;
using DodoWare.Mvc.Models.Fraction;
using DodoWare.Mvc.Models.Percent;
using DodoWare.Mvc.Models.Ratio;
using System;
using System.Web.Mvc;

namespace DodoWare.Mvc.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Help()
        {
            return View("Help");
        }

        [HttpGet]
        public ActionResult Home()
        {
            return View("Home");
        }

        [HttpGet]
        public ActionResult About()
        {
            return View("About");
        }

        [HttpGet]
        public ActionResult Contact()
        {
            return View("Contact");
        }

        [HttpGet]
        public ActionResult Percents()
        {
            return View("Percents");
        }

        [HttpGet]
        public ActionResult Discount()
        {
            return View("Discount");
        }

        [HttpPost]
        public ActionResult DoDiscount(DiscountInput input)
        {
            var discountWorker = new DiscountWorker(input);
            discountWorker.Go();
            ViewBag.Worker = discountWorker;
            var viewName = discountWorker.HasError() ? "Discount" : "DiscountResult";
            return View(viewName);
        }

        [HttpGet]
        public ActionResult Ratio()
        {
            return View("Ratio");
        }

        [HttpGet]
        public ActionResult Ratio2()
        {
            return View("Ratio2");
        }

        [HttpPost]
        public ActionResult DoRatio(RatioInput input)
        {
            var ratioWorker = new RatioWorker(input);
            ratioWorker.Go();
            ViewBag.Worker = ratioWorker;
            var viewName = ratioWorker.HasError() ? "Ratio" : "RatioResult";
            return View(viewName);
        }

        [HttpGet]
        public ActionResult Fractions()
        {
            return View("Fractions");
        }

        [HttpGet]
        public ActionResult Fraction(string id)
        {
            try
            {
                ViewBag.FractionOperation = FractionOperation.GetFractionOperation(id);
            }
            catch (Exception ex)
            {
                ViewBag.Worker = new BaseWorker { LogicError = $"Failed to get fraction operation for '{id}'.\n{ex.Message}" };
                return View("Fractions");
            }
            return View("Fraction");
        }
        
        [HttpPost]
        public ActionResult DoFraction(FractionInput input)
        {
            var fractionWorker = new FractionWorker(input);
            fractionWorker.Go();
            ViewBag.Worker = fractionWorker;
            ViewBag.FractionOperation = fractionWorker.Operation;
            var viewName = fractionWorker.HasError() ? "Fraction" : "FractionResult";
            return View(viewName);
        }

        [HttpGet]
        public ActionResult Percent(string id)
        {
            try
            {
                ViewBag.Scenario = PercentWorker.GetScenario(id);
            }
            catch (Exception ex)
            {
                ViewBag.Worker = new BaseWorker { LogicError = $"Failed to get percent scenario for '{id}'.\n{ex.Message}" };
                ViewBag.Error = ex.Message;
            }
            return View("Percent");
        }

        [HttpPost]
        public ActionResult DoPercent(PercentInput input)
        {
            var percentWorker = new PercentWorker(input);
            ViewBag.Worker = percentWorker;
            percentWorker.Go();
            ViewBag.Scenario = percentWorker.Scenario;
            var viewName = percentWorker.HasError() ? "Percent" : "PercentResult";
            return View(viewName);
        }
    }
}
