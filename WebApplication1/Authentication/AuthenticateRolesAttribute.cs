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
            var role = (string)filterContext.HttpContext.Session["role"];
            
            if (!IsAuthenticated(role))
            {
                filterContext.Result = new RedirectToRouteResult(
                    new RouteValueDictionary
                        {
                            {"controller", "Account"},
                            {"action", "Login"}

                        });
            }
        }

        private bool IsAuthenticated(string role)
        {
            if (string.IsNullOrWhiteSpace(role))
            {
                return false;
            }

            if (string.IsNullOrWhiteSpace(Roles))
            {
                return true;
            }

            if (Roles.Split(',').Contains(role))
            {
                return true;
            }

            return false;

        }
    }
}