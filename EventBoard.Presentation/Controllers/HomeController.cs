using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using EventBoard.DataAccess.EntityFramework;

namespace EventBoard.Presentation.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Maximus()
        {
            return View();
        }

        //public ActionResult ChangeData()
        //{
        //    //var userId = User.Identity.GetUserId();

        //    //// Fetch the userprofile
        //    ////UserProfile user = db.UserProfiles.FirstOrDefault(u => u.UserName.Equals(username));
        //    //var user = UserManager.FindById(User.Identity.GetUserId());
        //    //// Construct the viewmodel
        //    //UserProfileEdit model = new UserProfileEdit();
        //    //model.FirstName = user.FirstName;
        //    //model.SecondName = user.SecondName;
        //    //model.Email = user.Email;
        //    //model.BirthDate = Convert.ToDateTime(user.BirthDate);
        //    //model.PhoneNumber = user.PhoneNumber;
        //    //model.Maximus = user.Maximus;


        //    //return View(model);
        //}
    }
}