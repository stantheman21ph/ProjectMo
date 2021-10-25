using System.Web.Mvc;

namespace ProjectMo.WebAPI.Controllers
{
    public class CorsHandleAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            //base.OnActionExecuting(actionContext);
        }
    }
}