using System.Web.Mvc;
using System.Web.Routing;

namespace TableLiveEdit.Core.Lib.Routing
{
    public static class RouteRegistrar
    {
        public static void RegisterRoutes(RouteCollection routes)
        {
            routes.IgnoreRoute("{resource}.axd/{*pathInfo}");

            const string defaultResource = "Home";
            routes.MapRoute("CreateResource", "{controller}", new { controller = defaultResource, action = "Create", id = string.Empty }, new { method = new HttpMethodConstraint("POST") });
            routes.MapRoute("DeleteResource", "{controller}/{id}", new { controller = defaultResource, action = "Delete", id = 0 }, new { id = @"\d+", method = new HttpMethodConstraint("DELETE") });
            routes.MapRoute("EditResource", "{controller}/{id}/Edit", new { controller = defaultResource, action = "Edit", id = 0 }, new { id = @"\d+", method = new HttpMethodConstraint("GET") });
            routes.MapRoute("IndexResource", "{controller}", new { controller = defaultResource, action = "Index", id = string.Empty }, new { method = new HttpMethodConstraint("GET") });
            routes.MapRoute("NewResource", "{controller}/New", new { controller = defaultResource, action = "New", id = 0 }, new { method = new HttpMethodConstraint("GET") });
            routes.MapRoute("ShowResource", "{controller}/{id}", new { controller = defaultResource, action = "Show", id = 0 }, new { id = @"\d+", method = new HttpMethodConstraint("GET") });
            routes.MapRoute("UpdateResource", "{controller}/{id}", new { controller = defaultResource, action = "Update", string.Empty }, new { id = @"\d+", method = new HttpMethodConstraint("POST", "PUT") });

            //routes.MapRoute("IndexHome", string.Empty, new { controller = "Home", action = "Index", id = string.Empty });
        }

        
    }
}