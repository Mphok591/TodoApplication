using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using TodoApplication.Models;


namespace TodoApplication.Controllers
{
    public class UserLoginController : Controller
    {
        // GET: UserLogin
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Authorize(TodoApplication.Models.UserLogin userLogin)
        {
            using (TDatabaseEntities db = new TDatabaseEntities())
            {
                var loginDetails = db.UserLogins.Where(x => x.UserName == userLogin.UserName && x.Password == userLogin.Password).FirstOrDefault();
                if (loginDetails == null)
                {
                    userLogin.basicLoginValidate = "Please enter the correct username or password";
                    return View("Index", userLogin);
                }
                else
                {
                    Session["Id"] = loginDetails.Id;
                    return RedirectToAction("Index", "Task");
                }
            }
        }
        
    }
}