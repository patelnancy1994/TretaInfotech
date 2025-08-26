using System.Web.Mvc;
using System.Configuration;
namespace BulkLetters.Controllers
{
    public class UploadController : Controller
    {
        public UploadController()
        {
        }

        [HttpGet]
        public ActionResult Index()
        {
            string apiUrl = ConfigurationManager.AppSettings["ApiBaseUrl"];
            ViewBag.ApiBaseUrl = apiUrl;
            return View();
        }
    }
}