using app.DataLayer.Context;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Filters;

namespace app.DataLayer.Attributes
{
    public class InitializeApp : ActionFilterAttribute
    {
        private readonly IUnitOfWork db;
        public InitializeApp(IUnitOfWork db)
        {
            this.db = db;
        }
        public override Task OnActionExecutionAsync(ActionExecutingContext context, ActionExecutionDelegate next)
        {
            var controller = context.Controller as Controller;
            if (controller == null)
            {
                return null;
            }

            if (context.HttpContext.User.Identity.IsAuthenticated)
            {
                var user = db.Users.Where(x => x.UserName == context.HttpContext.User.Identity.Name).FirstOrDefault();
                if (user != null)
                {
                    controller.ViewBag.avatar = "/images/avatar.jpg";
                    controller.ViewBag.userName = user.UserName;
                    controller.ViewBag.fullName = user.fullName;
                }
            }

            return base.OnActionExecutionAsync(context, next);
        }
    }
}
