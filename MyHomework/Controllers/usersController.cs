using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace MyHomework.Controllers
{
    [Authorize]
    public class usersController : Controller
    {
        // GET: users
        public ActionResult Index()
        {
            if (User.Identity.IsAuthenticated)
            {
                var user = User.Identity;
                ViewBag.Name = user.Name;


                return View();
            }
            else
            {
                ViewBag.Name = "Not Logged In";
            }
                return View();
        }
    }
}