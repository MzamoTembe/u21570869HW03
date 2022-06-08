using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using System.IO;
using u21570869_HW03.Models;

namespace u21570869_HW03.Controllers
{
    public class FileController : Controller
    {

        public ActionResult Index()
        {
            
            string[] filelocation = Directory.GetFiles(Server.MapPath("~/Media/Documents")); /*Retrieve document from folder*/
            List<FileModel> files = new List<FileModel>(); /*Makes a list of model/object for the documents*/

            foreach (string file in filelocation) /*Takes each object document */
            {
                files.Add(new FileModel
                {
                    FileName = Path.GetFileName(file), /*assigns name for it*/
                    MediaType = "Document" /*specifies the file type*/
                }) ;
            }
            return View(files);

        }

        public ActionResult Delete(string document)
        {
            string location = Server.MapPath("~/Media/Documents/") + document; /*Concatenate the file name*/
            byte[] content = System.IO.File.ReadAllBytes(location); /*Collects all the content of the file*/
            System.IO.File.Delete(location); /*Removes it from the server*/
            return RedirectToAction("Index"); /*Returns you to the Index view*/
        }

        public FileResult Download(string document) /*Returning a File to the user*/
        { 
            string location = Server.MapPath("~/Media/Documents/") + document; /*Concatenate the file name*/
            byte[] content = System.IO.File.ReadAllBytes(location); /*Collects all the content of the file*/
            return File(content, "application/octet-stream", document); /*Multipurpose Internet Mail Extensions to identify the file being downloaded*/
        }

    }
}