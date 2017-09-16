using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonInformation.Controllers
{
    using System.Security.Cryptography.X509Certificates;

   

    public class PersonController : Controller
    {
       
        // GET: Person
        public ActionResult Input()
        {
          
            return View();
        }

        [HttpPost]
        public ActionResult Input( FormCollection frm)
        {
           
            ViewBag.Name = frm["personname"].ToString();
            ViewBag.Email = frm["personemail"].ToString();
            ViewBag.Mobile = frm["personmobile"].ToString();
            ViewBag.Address = frm["personaddress"].ToString();
            
            return View("Showinfo");
        }

        public ActionResult Showinfo(string name, string email, string mobile,string address)
        {
            ViewBag.Name = name;
            ViewBag.Email = email;
            ViewBag.Mobile = mobile;
            ViewBag.Address = address;
            return View(ViewBag);
        }
    }
}