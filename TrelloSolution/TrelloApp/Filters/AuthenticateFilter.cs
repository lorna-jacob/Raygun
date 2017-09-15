using System.Web.Mvc;
using System.Web.Routing;

namespace TrelloApp.Filters
{
    public class Authenticate : System.Web.Mvc.ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext ctx)
        {
            var haveTrelloToken = !string.IsNullOrWhiteSpace(ctx.HttpContext.Session["TrelloToken"] as string);
            if (haveTrelloToken) return;

            ctx.Result = new RedirectToRouteResult(
                new RouteValueDictionary
                {
                    {"controller", "Home"},
                    {"action", "Index"}
                }
            );
        }
    }
}