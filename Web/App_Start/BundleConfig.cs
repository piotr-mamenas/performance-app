using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterAppBundles(bundles);
            RegisterVendorBundles(bundles);
        }

        private static void RegisterAppBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Content/app/app.js"));
        }

        private static void RegisterVendorBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/vendor/jquery").Include(
                "~/Content/vendor/scripts/jquery/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendor/jqueryval").Include(
                "~/Content/vendor/scripts/jquery/jquery.unobtrusive*",
                "~/Content/vendor/scripts/jquery/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/vendor/modernizr").Include(
                "~/Content/vendor/scripts/modernizr/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/vendor/scripts")
                .Include("~/Content/vendor/scripts/bootstrap/bootstrap.js")
                .Include("~/Content/vendor/scripts/respond/respond.js")
                .IncludeDirectory("~/Content/vendor/scripts/datatables","*.js", true));

            bundles.Add(new StyleBundle("~/bundles/vendor/styles")
                .Include("~/Content/vendor/styles/bootstrap/bootstrap.css")
                .Include("~/Content/vendor/styles/bootstrap/bootstrap-theme.css")
                .Include("~/Content/vendor/styles/font-awesome/font-awesome.css")
                .IncludeDirectory("~/Content/vendor/styles/datatables/css","*.css", true));
        }
    }
}
