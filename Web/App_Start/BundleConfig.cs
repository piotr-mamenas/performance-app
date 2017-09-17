using System.Web.Optimization;

namespace Web
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            RegisterVendorBundles(bundles);
            RegisterAppBundles(bundles);
        }

        private static void RegisterAppBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/app").Include(
                "~/Content/app/app.js",
                "~/Content/app/routing.js"));

            bundles.Add(new ScriptBundle("~/bundles/app/services").IncludeDirectory(
                "~/Content/app/services","*Service.js",searchSubdirectories: true));

            bundles.Add(new ScriptBundle("~/bundles/app/controllers").IncludeDirectory(
                "~/Content/app/controllers", "*Controller.js", searchSubdirectories: true));

            bundles.Add(new StyleBundle("~/bundles/app/styles").IncludeDirectory(
                "~/Content/app/styles","*.css", searchSubdirectories: true));
        }

        private static void RegisterVendorBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/vendor/lib").Include(
                "~/Content/vendor/scripts/jquery/jquery-{version}.js",
                "~/Content/vendor/scripts/bootstrap/bootstrap.js",
                "~/Content/vendor/scripts/respond/respond.js",
                "~/Content/vendor/scripts/bootbox/bootbox.js",
                "~/Content/vendor/scripts/datatables/jquery.datatables.js",
                "~/Content/vendor/scripts/datatables/datatables.bootstrap.js",
                "~/Content/vendor/scripts/underscore/underscore.js",
                "~/Content/vendor/scripts/moment/moment.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendor/jqueryval").Include(
                "~/Content/vendor/scripts/jquery/jquery.unobtrusive*",
                "~/Content/vendor/scripts/jquery/jquery.validate*",
                "~/Content/vendor/scripts/jquery/jquery.override*"));

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
