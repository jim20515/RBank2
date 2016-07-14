using System.Web;
using System.Web.Optimization;

namespace Demo
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //BundleTable.EnableOptimizations = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*",
                        "~/js/jquery.validate.bootstrap.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css"));

            // Admin
            bundles.Add(new ScriptBundle("~/bundles/Admin").Include(
                "~/Scripts/bootstrap.js",
                "~/Scripts/respond.js",
                "~/Scripts/metisMenu.js",
                "~/Scripts/DataTables/jquery.dataTables.js",
                "~/Scripts/DataTables/dataTables.bootstrap.js",
                "~/js/jquery.dataTables.columnFilter.custom.js",
                "~/Scripts/DataTables/dataTables.tableTools.js",
                "~/Scripts/DataTables/dataTables.colVis.js",
                "~/Scripts/bootstrap-select.min.js",
                "~/Scripts/bootstrap-datepicker.min.js",
                "~/Scripts/bootstrap-colorpicker.min.js",
                "~/Scripts/locales/bootstrap-datepicker.zh-TW.min.js",
                "~/Scripts/Sortable.min.js",
                "~/js/jquery.sortable.modal.js"
            ));

            bundles.Add(new StyleBundle("~/Content/Admin").Include(
                "~/Content/bootstrap.css",
                "~/Content/metisMenu.css",
                "~/Content/font-awesome.css",
                "~/Content/ionicons.css",
                "~/Content/jquery-datatables-column-filter/media/js/jquery.dataTables.columnFilter.css",
                "~/Content/DataTables/css/dataTables.tableTools.css",
                "~/Content/DataTables/css/dataTables.bootstrap.css",
                "~/Content/DataTables/css/dataTables.colVis.css",
                "~/Content/DataTables/css/select.bootstrap.css",
                "~/Content/bootstrap-select.css",
                "~/Content/bootstrap-datepicker3.css",
                //"~/Content/bootstrap-colorpicker/css/bootstrap-colorpicker.css",
                "~/css/checkbox_radio.css",
                "~/css/sortable-admin.css",
                "~/css/custom-admin.css"
            ));

        }
    }
}
