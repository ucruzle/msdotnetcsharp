using System.Web;
using System.Web.Optimization;

namespace TesteCodeFirst.MVC
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new ScriptBundle("~/bundles/autoNumeric").Include(
                      "~/Scripts/autoNumeric/autoNumeric*"));

            bundles.Add(new ScriptBundle("~/bundles/maskedinput").Include(
                      "~/Scripts/jquery.maskedinput*"));

            // Validações no padrão brasileiro
            bundles.Add(new ScriptBundle("~/bundles/validations_pt-br").Include(
                        "~/Scripts/jquery.validate.custom.pt-br*",
                        "~/Scripts/field.masks.custom.pt-br*"));


            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));
        }
    }
}