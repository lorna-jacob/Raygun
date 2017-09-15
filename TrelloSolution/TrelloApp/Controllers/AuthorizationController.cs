using System.Net;
using System.Web.Mvc;

namespace TrelloApp.Controllers
{
    public class AuthorizationController : Controller
    {
        public ActionResult Index()
        {            
            ViewBag.BoardsUrl = Url.Action("Index", "Boards");

            return View();
        }

        public ActionResult Token()
        {
            var token = Request.Form.Get("token");
            Session["TrelloToken"] = Request.Form.Get("token");

            return new HttpStatusCodeResult(HttpStatusCode.NoContent);
        }
    }
}