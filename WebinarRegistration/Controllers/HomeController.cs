using System;
using System.Web.Mvc;
using WebinarRegistration.Services;

namespace WebinarRegistration.Controllers
{
    public class HomeController : Controller
    {
        private readonly IWebinarService _webinarService;

        public HomeController(IWebinarService webinarService)
        {
            _webinarService = webinarService;
        }

        public ActionResult Index()
        {
            return RedirectToRoute(Settings.WebinarByYearRoute, new { year = DateTime.UtcNow.Year - 4 });
        }

        [Route("home/webinars/{year:int}")]
        public ActionResult Webinars(int year)
        {
            ViewBag.year = year;
            var webinars = _webinarService.GetWebinarsByYear(year);
            return View(webinars);
        }
    }
}