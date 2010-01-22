using System.Web.Mvc;
using TableLiveEdit.Core.Lib.Data;
using TableLiveEdit.Core.Lib.Startup;
using TableLiveEdit.Core.Models;

namespace TableLiveEdit.Core.Lib.ActionFilters
{
    public class LogRequestAttribute : ActionFilterAttribute
    {
        public override void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var request = Request.Create(filterContext.HttpContext.Request);
            var repository = ServiceLocator.Resolve<IRepository>();
            var exists = repository.FindSingle<Request>(r => r.IpAddress == request.IpAddress);
            if (exists == null)
            {
                repository.Insert(request);
            }
            else
            {
                exists.RepeatRequest();
            }
            repository.Commit();
        }
    }
}
