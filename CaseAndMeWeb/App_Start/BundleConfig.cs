using System.Web;
using System.Web.Optimization;

namespace CaseAndMeWeb
{
    public class BundleConfig
    {
        // For more information on bundling, visit https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at https://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/owl-carousel.js",
                      "~/Scripts/jquery-confirm.js",
                      "~/Scripts/jquery.bootstrap-touchspin.js",
                      "~/Scripts/site.js",
                      "~/Scripts/chartjs/Chart.bundle.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/font-awesome.css",
                      "~/Content/owl-carousel.css",
                      "~/Content/owl-theme.css",
                      "~/Content/jquery.bootstrap-touchspin.css",
                      "~/Content/jquery-confirm.css",
                      "~/Content/site.css"));

            bundles.Add(new ScriptBundle("~/bundles/datatables").Include(
                        "~/Scripts/Datatables/datatables.js"));

            bundles.Add(new StyleBundle("~/Content/datatables").Include(
                      "~/Content/Datatables/datatables.css",
                     "~/Content/Datatables/datatables.Theme.css"));
        }
    }
}
