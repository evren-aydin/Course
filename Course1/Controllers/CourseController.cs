using Microsoft.AspNetCore.Mvc;
using Course1.Models;
using Course1.Controllers;

namespace Course1.Controllers
{
    public class CourseController : Controller
    {
        public IActionResult Index(){
            var model = Repository.Applications;
            return View(model);
        }
        public IActionResult Apply(){
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public IActionResult Apply([FromForm] Candidate model)
        {
            if(Repository.Applications.Any(c=> c.Email.Equals(model.Email)))
            {
                ModelState.AddModelError("","There is alredy application for you.");
            }


            if(ModelState.IsValid){
            Repository.Add(model);
            return View("FeedBack", model);
            }
            return View();
        }


    }
}