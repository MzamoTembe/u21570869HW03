 using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21570869_HW03.Models;
using System.IO;

namespace u21570869_HW03.Controllers
{
    public class ImageController : Controller
    {
        // GET: Image
        public ActionResult Index()
        {

            string[] filelocation = Directory.GetFiles(Server.MapPath("~/Media/Images")); /*Retrieve Image from folder*/
            List<FileModel> files = new List<FileModel>(); /*Makes a list of model/object for the Images*/

            foreach (string file in filelocation) /*Takes each object Image */
            {
                files.Add(new FileModel
                {
                    FileName = Path.GetFileName(file), /*assigns name for it*/
                    MediaType = "Image" /*specifies the file type*/
                });
            }
            return View(files);
        }

        public ActionResult Delete(string image)
        {

            string location = Server.MapPath("~/Media/Images/") + image; /*Concatenate the file name*/
            byte[] content = System.IO.File.ReadAllBytes(location); /*Collects all the content of the file*/
            System.IO.File.Delete(location); /*Removes it from the server*/
            return RedirectToAction("Index"); /*Returns you to the Index view*/
        }

        public FileResult Download(string image)
        {
            string location = Server.MapPath("~/Media/Images/") + image; /*Concatenate the file name*/
            byte[] content = System.IO.File.ReadAllBytes(location); /*Collects all the content of the file*/
            return File(content, "application/octet-stream", image); /*Multipurpose Internet Mail Extensions to identify the file being downloaded*/
        }
    }
}