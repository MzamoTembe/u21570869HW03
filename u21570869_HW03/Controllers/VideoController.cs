using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using u21570869_HW03.Models;
using System.IO;

namespace u21570869_HW03.Controllers
{
    public class VideoController : Controller
    {
        // GET: Video
        public ActionResult Index()
        {

            string[] filelocation = Directory.GetFiles(Server.MapPath("~/Media/Videos")); /*Retrieve video from folder*/
            List<FileModel> files = new List<FileModel>(); /*Makes a list of model/object for the videos*/

            foreach (string file in filelocation) /*Takes each object video */
            {
                files.Add(new FileModel
                {
                    FileName = Path.GetFileName(file), /*assigns name for it*/
                    MediaType = "Video" /*specifies the file type*/
                });
            }
            return View(files);
        }

        public ActionResult Delete(string video)
        {
            string location = Server.MapPath("~/Media/Videos/") + video; /*Concatenate the file name*/
            byte[] content = System.IO.File.ReadAllBytes(location); /*Collects all the content of the file*/
            System.IO.File.Delete(location); /*Removes it from the server*/
            return RedirectToAction("Index"); /*Returns you to the Index view*/
        }

        public FileResult Download(string video)
        {
            string location = Server.MapPath("~/Media/Videos/") + video; /*Concatenate the file name*/
            byte[] content = System.IO.File.ReadAllBytes(location); /*Collects all the content of the file*/
            return File(content, "application/octet-stream", video); /*Multipurpose Internet Mail Extensions to identify the file being downloaded*/
        }
    }
}