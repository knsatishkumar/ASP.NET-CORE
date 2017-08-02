using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using RecaptchaSample.Model;
using PaulMiami.AspNetCore.Mvc.Recaptcha;

namespace RecaptchaSample.Controllers
{
    public class HomeController : Controller
    {
        //public IActionResult Index()
        //{
        //    return View();
        //}

        public IActionResult About()
        {
            ViewData["Message"] = "Your application description page.";

            return View();
        }

        public IActionResult Contact()
        {
            ViewData["Message"] = "Your contact page.";

            return View();
        }

        [ValidateRecaptcha]
        [HttpPost]
        public ActionResult Contact(Contact form)
        {
            if (ModelState.IsValid)
            {
                return RedirectToAction(nameof(ThankYou), new { name = form.Name });
            }

            return View();
        }

        public IActionResult Error()
        {
            return View();
        }


        [HttpGet]
        public IActionResult ThankYou(string name)
        {
            return View(nameof(ThankYou), name);
        }
    }
}
