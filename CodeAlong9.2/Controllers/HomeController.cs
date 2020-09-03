using CodeAlong9._2.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.Text.RegularExpressions;

namespace CodeAlong9._2.Controllers
{
    public class HomeController : Controller
    {
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            ViewBag.Message = "Your application description page.";

            return View();
        }

        public ActionResult Contact()
        {
            ViewBag.Message = "Your contact page.";

            return View();
        }

        public ActionResult Error()
        {
            return View();
        }

        [HttpGet]
        public ActionResult Register()
        {
            return View();
        }

        [HttpPost] //This will keep the info out of the URL bar.
        public ActionResult Save(string username, string emailaddress, string password, string currentstate, string roastpreference, string musicpreference)
        {

            //Basic Regex password component, pulled from the internet.
            bool validPassword = (!(password is null) && password != "" && Regex.IsMatch(password, @"^(?=.*\d)(?=.*[a-z])(?=.*[A-Z])(?=.*[a-zA-Z]).{8,}$"));

            //Doesn't work.
            ViewData["passwordcolor"] = validPassword ? "#20FF20" : "#FF2020";

            bool validEmail = (emailaddress.Contains("@"));


            //Validation x2
            if (!validEmail)
            {
                return View("EmailError");
            }

            if (!validPassword)
            {
                return View("PasswordError");
            }



            string hiddenpassword = "";
            foreach(char c in password)
            {
                hiddenpassword += "*";
            }



            WebUser user = new WebUser()
            {

                Username = username,
                Email = emailaddress,
                State = currentstate,
                Roast = roastpreference,
                Music = musicpreference,
                Password = password,
                Hidden = hiddenpassword
            };

            

            return View(user);
        }

        [HttpPost]
        private ActionResult RedirectToActionPreserveMethod(string v1, string v2)
        {
            return Redirect(v1);
        }





        //Controller action includes validation for at least 2 fields(2 points each = 4 points).
    }
}