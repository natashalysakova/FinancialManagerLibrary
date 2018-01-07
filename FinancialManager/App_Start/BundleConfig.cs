using System.Web.Optimization;

namespace FinancialManager
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                "~/Scripts/jquery-3.2.1.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                "~/Scripts/jquery.validate.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryunob").Include(
                "~/Scripts/jquery.unobtrusive-ajax.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/angular").Include(
                "~/Scripts/angular.min.js",
                "~/Scripts/isoCurrency.min.js", 
                "~/Scripts/angular-ui/ui-bootstrap.min.js"));


            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/popper").Include(
                "~/Scripts/umd/popper.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/respond.min.js"));

            bundles.Add(new ScriptBundle("~/bundles/js").Include(
                "~/Scripts/Site.js*").IncludeDirectory("~/Scripts/Controllers", "*.js"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                "~/Content/bootstrap.min.css",
                "~/Content/site.css",
                "~/Content/ui-bootstrap-csp.css"));

        }
    }
}