using System.Web.Mvc;

namespace TableLiveEdit.Core.Lib.Extensions
{
    public static class ExtensionsOfUrlHelper
    {
        public static string IncludeCss(this UrlHelper url, string file)
        {
            var path = string.Format("~/Content/Stylesheets/{0}", file);
            return string.Format("<link rel=\"stylesheet\" type=\"text/css\" href=\"{0}\"/>", url.Content(path));
        }

        public static string IncludeJs(this UrlHelper url, string file)
        {
            var path = string.Format("~/Content/Scripts/{0}", file);
            return string.Format("<script type=\"text/javascript\" lang=\"javascript\" src=\"{0}\"></script>", url.Content(path));
        }
    }
}
