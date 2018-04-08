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
            bundles.Add(new ScriptBundle("~/bundles/App").Include(
                "~/Content/App/App.js",
                "~/Content/App/Routing.js"));

            bundles.Add(new ScriptBundle("~/bundles/App/Services").IncludeDirectory(
                "~/Content/App/Services","*Service.js",searchSubdirectories: true));

            bundles.Add(new ScriptBundle("~/bundles/App/Controllers").IncludeDirectory(
                "~/Content/App/Controllers", "*Controller.js", searchSubdirectories: true));

            bundles.Add(new StyleBundle("~/bundles/App/Styles").IncludeDirectory(
                "~/Content/App/Styles","*.css", searchSubdirectories: true));
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
                "~/Content/vendor/scripts/moment/moment.js",
                "~/Content/vendor/scripts/moment/datetime.js",
                "~/Content/vendor/scripts/bootstrap/bootstrap-datetimepicker.min.js",
                "~/Content/vendor/scripts/bootstrap/bootstrap-datepicker.min.js",
                "~/Content/vendor/scripts/bootstrap-select/bootstrap-select.js"));

            bundles.Add(new ScriptBundle("~/bundles/vendor/jqueryval").Include(
                "~/Content/vendor/scripts/jquery/jquery.unobtrusive*",
                "~/Content/vendor/scripts/jquery/jquery.validate*",
                "~/Content/vendor/scripts/jquery/jquery.override*"));

            bundles.Add(new ScriptBundle("~/bundles/vendor/modernizr").Include(
                "~/Content/vendor/scripts/modernizr/modernizr-*"));

            bundles.Add(new StyleBundle("~/bundles/vendor/styles").Include(
                "~/Content/vendor/styles/bootstrap/bootstrap.css",
                "~/Content/vendor/styles/font-awesome/font-awesome.css",
                "~/Content/vendor/styles/datatables/css/datatables.bootstrap.css",
                "~/Content/vendor/styles/datatables/css/dataTables.fontAwesome.css",
                "~/Content/vendor/styles/bootstrap-select/bootstrap-select.css",
                "~/Content/vendor/styles/bootstrap/bootstrap-datetimepicker.min.css",
                "~/Content/vendor/styles/bootstrap/bootstrap-datepicker.min.css"));
        }
    }
}
