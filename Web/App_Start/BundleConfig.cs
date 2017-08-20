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
            bundles.Add(new ScriptBundle("~/bundles/vendor/lib").Include(
                "~/Content/vendor/scripts/jquery/jquery-{version}.js",
                "~/Content/vendor/scripts/bootstrap/bootstrap.js",
                "~/Content/vendor/scripts/respond/respond.js",
                "~/Content/vendor/scripts/bootbox/bootbox.js",
                "~/Content/vendor/scripts/datatables/jquery.datatables.js",
                "~/Content/vendor/scripts/datatables/datatables.bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendor/jqueryval").Include(
                "~/Content/vendor/scripts/jquery/jquery.unobtrusive*",
                "~/Content/vendor/scripts/jquery/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/vendor/modernizr").Include(
                "~/Content/vendor/scripts/modernizr/modernizr-*"));

            bundles.Add(new StyleBundle("~/bundles/vendor/styles").Include(
                "~/Content/vendor/styles/bootstrap/bootstrap.css",
                "~/Content/vendor/styles/bootstrap/bootstrap-theme.css",
                "~/Content/vendor/styles/font-awesome/font-awesome.css",
                "~/Content/vendor/styles/datatables/css/datatables.bootstrap.css",
                "~/Content/vendor/styles/datatables/css/dataTables.fontAwesome.css"));
        }
    }
}
