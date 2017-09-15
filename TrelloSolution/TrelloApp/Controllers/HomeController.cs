using System;
using System.Configuration;
using System.Web;
using System.Web.Mvc;
using System.Web.Routing;
using TrelloApp.Core;

namespace TrelloApp.Controllers
{
    public class HomeController : BaseController
    {
        public HomeController(IUnitOfWork unitOfWork) : base(unitOfWork) { }

        public ActionResult Index()
        {                            
            // If the Token is not empty, redirect to Boards page
            if (!string.IsNullOrWhiteSpace(Token))
            {
                return new RedirectToRouteResult(
                    new RouteValueDictionary
                    {
                        {"controller", "Boards"},
                        {"action", "Index"}
                    }
                );
            }            

            // Otherwise, redirect user for login and authorization
            var uriBuilder = new UriBuilder("https://trello.com/1/authorize");
            var parameters = HttpUtility.ParseQueryString(string.Empty);
            parameters["expiration"] = "never";
            parameters["name"] = ConfigurationManager.AppSettings["AppName"];
            parameters["key"] = ConfigurationManager.AppSettings["AppKey"];
            parameters["scope"] = "read,write";
            parameters["callback_method"] = "fragment";
            parameters["redirect_uri"] = Request.Url + "Authorization/Index";
            uriBuilder.Query = parameters.ToString();
            ViewBag.AuthorizationUrl = uriBuilder.Uri;

            return View();
        }
    }
}