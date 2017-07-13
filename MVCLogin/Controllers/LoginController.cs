using MVCLogin.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MVCLogin.Controllers
{
    public class LoginController : Controller
    {
        // GET: Login
        public ActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public ActionResult Authorize(MVCLogin.Models.User userModel)
        {
            using (LoginDataBaseEntities db = new LoginDataBaseEntities())
            {
                var userDetails = db.User.Where(x => x.UserName == userModel.UserName && x.Password == userModel.Password).FirstOrDefault();
                if (userDetails == null)
                {
                    userModel.ErrorMeassage = "wrong username or pwd";
                    return View("Index", userModel);
                }
                else
                {
                    Session["UserId"] = userDetails.UserID;
                    return RedirectToAction("Index", "Home");
                }
            }
            

            
        }
    }
}