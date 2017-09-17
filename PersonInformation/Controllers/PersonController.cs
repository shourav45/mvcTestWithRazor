using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace PersonInformation.Controllers
{
    using System.Security.Cryptography.X509Certificates;

    using LogicLayer.BusinessLogic;
    using LogicLayer.BusinessObject;

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
            
            Person p=new Person();
            p.Name = ViewBag.Name;
            p.Email = ViewBag.Email;
            p.Mobile = ViewBag.Mobile;
            p.Address = ViewBag.Address;
            PersonInfoHandler ph=new PersonInfoHandler();
            if (ph.Insert(p) == true) ViewBag.message = "Data Inserted";
            return View();
        }

        public ActionResult Showinfo()
        {
            PersonInfoHandler ph = new PersonInfoHandler();
            List<Person> alldataList=new List<Person>();
            alldataList = ph.GetAll();
            ViewBag.data = alldataList;
            return View();
        }
    }
}