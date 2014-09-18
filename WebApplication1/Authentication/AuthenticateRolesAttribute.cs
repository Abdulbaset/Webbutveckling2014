using System.Linq;
using System.Web.Mvc;
using System.Web.Routing;

namespace WebApplication1.Authentication
{
    public class AuthenticateRolesAttribute : ActionFilterAttribute
    {
        public string Roles { get; set; }

        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            if (!IsAuthenticated(filterContext))
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                        {
                            { "controller", "Account" },
                            { "action", "Login" }
                        });
            }
        }

        private bool IsAuthenticated(ActionExecutingContext filterContext)
        {
            var session = filterContext.HttpContext.Session;

            if (session == null)
            {
                return false;
            }

            var role = (string)session["role"];

            if (string.IsNullOrWhiteSpace(role))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Roles))
            {
                return true;
            }

            if (Roles.Split(',').Select(Normalize).Contains(Normalize(role)))
            {
                return true;
            }

            return false;
        }

        private string Normalize(string text)
        {
            return text.Trim().ToUpperInvariant();
        }
    }
}