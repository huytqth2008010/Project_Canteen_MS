using System.Web;
using System.Web.Optimization;

namespace Project_Canteen_MS
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
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
            // add css theme admin
            bundles.Add(new StyleBundle("~/canteen/css").Include(
                      "~/Content/canteen/css/styles.css"
                ));
            // add js theme admin
            bundles.Add(new ScriptBundle("~/canteen/js").Include(
                        "~/Content/canteen/js/datatables-simple-demo.js",
                        "~/Content/canteen/js/litepicker.js",
                        "~/Content/canteen/js/scripts.js"
                ));
            // add css theme web
            bundles.Add(new StyleBundle("~/webcanteen/css").Include(
                    "~/Content/webcanteen/css/animate.css",
                    "~/Content/webcanteen/css/baguetteBox.min.css",
                    "~/Content/webcanteen/css/bootstrap.min.css",
                    "~/Content/webcanteen/css/classic.css",
                    "~/Content/webcanteen/css/classic.date.css",
                    "~/Content/webcanteen/css/classic.time.css",
                    "~/Content/webcanteen/css/custom.css",
                    "~/Content/webcanteen/css/font-awesome.min.css",
                    "~/Content/webcanteen/css/responsive.css",
                    "~/Content/webcanteen/css/style.css",
                    "~/Content/webcanteen/css/superslides.css",
                    "~/Content/webcanteen/bootstrap-theme.css"
              ));
            //add js theme web
            bundles.Add(new ScriptBundle("~/webcanteen/js").Include(
                   "~/Content/webcanteen/js/jquery-3.2.1.min.js",
                       "~/Content/webcanteen/js/jquery.mapify.js",
                       "~/Content/webcanteen/js/jquery.superslides.min.js",
                       "~/Content/webcanteen/js/baguetteBox.min.js",
                       "~/Content/webcanteen/js/bootstrap.min.js",
                       "~/Content/webcanteen/js/contact-form-script.js",
                       "~/Content/webcanteen/js/custom.js",
                       "~/Content/webcanteen/js/form-validator.min.js",
                       "~/Content/webcanteen/js/images-loded.min.js",
                       "~/Content/webcanteen/js/isotope.min.js",
                       "~/Content/webcanteen/js/legacy.js",
                       "~/Content/webcanteen/js/picker.date.js",
                       "~/Content/webcanteen/js/picker.js",
                       "~/Content/webcanteen/js/picker.time.js",
                       "~/Content/webcanteen/js/popper.min.js"
               ));

        }
    }
}
