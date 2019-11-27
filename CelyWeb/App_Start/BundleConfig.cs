using System.Web;
using System.Web.Optimization;

namespace CelyWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {

            bundles.Add(new ScriptBundle("~/bundles/javascripts").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/jquery.validate*",
                 "~/Scripts/bootstrap.js",
                  "~/Scripts/site.js",
                  "~/Scripts/jquery.dataTables.js",
                  "~/Scripts/toastr.js",
                  "~/Scripts/typeahead.bundle.js"
                ));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                     ));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/typeahead.css",
                      "~/Content/toastr.css",
                      "~/Content/site.css"));
        }
    }
}
