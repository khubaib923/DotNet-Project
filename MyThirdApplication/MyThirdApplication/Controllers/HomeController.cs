

using Microsoft.AspNetCore.Mvc;
using MyThirdApplication.Model;

namespace MyThirdApplication.Controllers
{
    [Controller]
    public class Home:Controller
    {
        [Route("/")]
        [Route("index")]
        [Route("name")]
        public string Index()
        {
            return "khubaib";
        }

        [Route("contact-us")]
        public string contact()
        {
            return "03482499660";
        }
        [Route("about")]
        public string about()
        {
            return "i am khubaib irfan";
        }
        [Route("contentpage")]
        public ContentResult contentPage()
        {
            //return new ContentResult()
            //{
            //    Content="<h1>Khubaib Irfan</h1>",
            //    ContentType="text/html",

            //};

            return Content("<b>khubaib Irfan</b>","text/html");
        }

        [Route("Person")]
        public JsonResult PersonJson()
        {
            Person p = new Person()
            {
                Id=Guid.NewGuid(),
                FirstName="Khubaib",
                LastName="Irfan",
                Age=24
            };

            return new JsonResult(p);
            //return Json(new {success=true,data=p});

        }
        [Route("file-download")]
        public VirtualFileResult FileDownload()
        {
            /*return new VirtualFileResult("labtask.pdf","application/pdf");*/
            return File("labtask.pdf", "application/pdf");
        }

        [Route("file-download2")]
        public PhysicalFileResult FileDownLoad2()
        {
            //return new PhysicalFileResult(@"C:\Users\TECHNEZO\Desktop\Bug Report 1.pdf", "application/pdf");
            return PhysicalFile(@"C:\Users\TECHNEZO\Desktop\Bug Report 1.pdf", "application/pdf");
        }
        [Route("file-download3")]
        public FileContentResult FileDownload3()
        {
            byte[] byteFile = System.IO.File.ReadAllBytes(@"C:\Users\TECHNEZO\Desktop\Bug Report 1.pdf");
            //return new FileContentResult(byteFile,"application/pdf");
            return File(byteFile,"application/pdf");
        }

        [Route("book")]
        public IActionResult Book()
        
        {
            if (!Request.Query.ContainsKey("bookid"))
            {
                //Response.StatusCode = 400;
                //return Content("Book id is not supplied");
                //return new StatusCodeResult(200);
                //return StatusCode(200);
                return Unauthorized("Book id is not supplied"); 

            }

            if (string.IsNullOrEmpty(Convert.ToString(Request.Query["bookid"])))
            {
                //Response.StatusCode = 400;
                //return Content("Book id can't be null or empty");
                return NotFound("Book id can't be null or empty");
            }
            int bookid = Convert.ToInt32(Request.Query["bookid"]);
            if (bookid <= 0)
            {
                //Response.StatusCode = 400;
                //return Content("Book id can't be less than and equal to zero");
                return BadRequest("Book id can't be less than and equal to zero");
            }
            if (bookid > 1000)
            {
                Response.StatusCode = 400;
                return Content("Book id can't be more than 1000");
            }
            if (Convert.ToBoolean(Request.Query["isloggedin"])==false)
            {
                Response.StatusCode = 400;
                return Content("User must be authenciated");
            }

            //return File("labtask.pdf", "application/pdf");
            //return new RedirectToActionResult("Books","Store",new { id=1 },true);
            //return RedirectToAction("Books", "Store", new { id = bookid });
            //return RedirectToActionPermanent("Books", "Store", new { id = bookid });
            //return new LocalRedirectResult($"/store/books",permanent:true);
            //return LocalRedirect($"/store/books");
            //return LocalRedirectPermanent($"/store/books");
            //return new RedirectResult("https://youtube.com/");
            //return Redirect("https://youtube.com/");
            return RedirectPermanent("https://youtube.com/");

        }




    }
}
