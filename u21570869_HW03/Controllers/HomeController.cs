using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21570869_HW03.Models;

namespace u21570869_HW03.Controllers
{
    public class HomeController : Controller
    {
        [HttpGet]
        public ActionResult Index()
        {
            return View();
        }

        public ActionResult About()
        {
            return View();
        }

        [HttpPost]
        public ActionResult Index(HttpPostedFileBase files, FormCollection form) //INSIDE HOME
        {
            //collects the radio button type through th FormCollection class
            var option = Convert.ToString(Request.Form["option"]);

            //if statement to put files in the correct locations
            if (option == "Document")
            {
                //will only execute if there is actually a file posted
                if (files != null)
                { 
                    var name = Path.GetFileName(files.FileName); //Gets the name
                    var location = Path.Combine(Server.MapPath("~/Media/Documents"), name); /*Concatenates the path and the name for the save*/
                    files.SaveAs(location); /*Then saves it to the location*/
                }
            }
            else if (option == "Image")
            {
                if (files != null)
                {
                    var name = Path.GetFileName(files.FileName);
                    var location = Path.Combine(Server.MapPath("~/Media/Images"), name);
                    files.SaveAs(location);
                }
            }
            else if (option == "Video")
            {
                if (files != null)
                {
                    var name = Path.GetFileName(files.FileName);
                    var location = Path.Combine(Server.MapPath("~/Media/Videos"), name);
                    files.SaveAs(location);
                }
            }
            else
            {
                ViewBag.alert = "Please select a document";
            }
            return RedirectToAction("Index");
        }
    }
}