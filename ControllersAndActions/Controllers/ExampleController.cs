using ControllersAndActions.Infrastructure;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;
using System.Xml.Linq;

namespace ControllersAndActions.Controllers
{

    public class ExampleController : Controller
    {
        //
        // GET: /Example/


        public ViewResult Index()
        {
            return View("HomePage");
        }

        public ViewResult ActionNameEqualViewName()
        {
            return View();
        }

        public ViewResult TransferDataByViewDataModel()
        {
            return View((object)"Hello World");
        }

        public ViewResult TransferDataByViewData()
        {
            ViewData["Message"] = "Hello";
            ViewData["Date"] = DateTime.Now;
            return View();
        }

        public ViewResult TransferDataByViewBag()
        {
            ViewBag.Message = "Hello";
            ViewBag.Date = DateTime.Now;
            return View();
        }

        public RedirectResult Redirect()
        {
           return Redirect("/Example/Index");
        }

        public RedirectToRouteResult RedirectToRoute()
        {
            return RedirectToRoute(new { controller = "Example", 
                                         action = "Index", 
                                         ID = "MyID" 
                                       });
        }

        public RedirectToRouteResult RedirectToAction()
        {
            return RedirectToAction("Index", "Example");
        }

        public RedirectToRouteResult TransferDataByTempData()
        {
            TempData["Message"] = "Hello";
            TempData["Date"] = DateTime.Now;
            return RedirectToAction("TempDataIndex", "Example");
        }

        public ViewResult TempDataIndex()
        {
            ///data read from tempdata and delete
            ViewBag.Message = TempData["Message"];
            ///by peek method data read from tempdata and dont delete
            ViewBag.Date = TempData.Peek("Date");
            return View();
        }

        public ContentResult TextContent()
        {
            string message = "this is plain text";
            return Content(message, "text/plain", Encoding.Default);
        }

        public ContentResult XMLContent()
        {
            IList<StoryLink> StoryLinkList = new StoryLink().GetAllStories();

            XElement data = new XElement("StoryList", StoryLinkList.Select(e => new XElement("Story",
                                                                                             new XAttribute("title", e.Title),
                                                                                             new XAttribute("description", e.Description),
                                                                                             new XAttribute("link", e.Url)
                                                                                            )
                                                                          )
                                        );
            return Content(data.ToString(), "text/xml");
        }

        /// <summary>
        /// this method by default defined for HttpPost method for use this method for HttpGet method Set JsonRequestBehavior to AllowGet
        /// </summary>
        /// <returns></returns>
        public JsonResult JsonContent()
        {
            IList<StoryLink> StoryLinkList = new StoryLink().GetAllStories();
            return Json(StoryLinkList, JsonRequestBehavior.AllowGet);
        }

        public FileResult TransferFileByName()
        {
            string fileName = @"~\Files\p5pl2e_en.pdf";
            ///when we dont know file MimeType we must set it to application/octet-stream that means MimeType is undefinrd binary
            string contentType = "application/pdf";
            string filedownloadName = "cpuMpdel.pdf";
            return File(fileName, contentType, filedownloadName);
        }

        public FileContentResult TransferFileContent()
        {
            string fileName = @"Files\p5pl2e_en.pdf";
            string contentType = "application/pdf";
            string filedownloadName = "cpuMpdel.pdf";
            Byte[] data = System.IO.File.ReadAllBytes(AppDomain.CurrentDomain.BaseDirectory + fileName);
            return File(data, contentType, filedownloadName);
        }

        public FileStreamResult TransferFileStream()
        {
            string fileName = @"Files\p5pl2e_en.pdf";
            string contentType = "application/pdf";
            string filedownloadName = "cpuMpdel.pdf";
            Stream stream = new FileStream(AppDomain.CurrentDomain.BaseDirectory + fileName, FileMode.Open, FileAccess.Read);            
            return File(stream, contentType, filedownloadName); 
        }

        public HttpStatusCodeResult StatusCode()
        {
            return new HttpStatusCodeResult(404, "URL cannot be serviced");
        }

        public HttpStatusCodeResult HttpNotFoundStatusCode()
        {
            return HttpNotFound();
        }

        public HttpStatusCodeResult UnauthorizedStatusCode()
        {
            return new HttpUnauthorizedResult();
        }

        public RssActionResult RSS()
        {
            IList<StoryLink> StoryLinkList = new StoryLink().GetAllStories();
            RssActionResult<StoryLink> rss =  new RssActionResult<StoryLink>("My Stories", StoryLinkList, e => new XElement("Item",
                                                                                                                            new XAttribute("title", e.Title),
                                                                                                                            new XAttribute("description", e.Description),
                                                                                                                            new XAttribute("link", e.Url)
                                                                                                                           )                                                                                                                       
                                                                            );
            return rss;
        }


    }
}
