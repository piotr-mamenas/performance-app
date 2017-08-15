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

            bundles.Add(new ScriptBundle("~/bundles/vendor/modernizr").Include(
                "~/Content/vendor/scripts/modernizr/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/vendor/bootstrap").Include(
                "~/Content/vendor/scripts/bootstrap/bootstrap.js",
                "~/Content/vendor/scripts/respond/respond.js"));

            bundles.Add(new StyleBundle("~/Content/vendor/css").Include(
                "~/Content/vendor/styles/bootstrap.css",
                "~/Content/vendor/styles/bootstrap-theme.css",
                "~/Content/vendor/styles/font-awesome.css").IncludeDirectory("~/Content/vendor/styles/datatables/css","*.css", true));
        }
    }
}
