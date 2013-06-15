using System.Web;
using System.Web.Optimization;

namespace DisasterReliefHub
{
    public class BundleConfig
    {
        // For more information on Bundling, visit http://go.microsoft.com/fwlink/?LinkId=254725
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Resource/js/jquery/jquery-1.8.2.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryui").Include(
                        "~/Resource/js/jquery/jquery-ui-1.8.24.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Resource/js/jquery/jquery.unobtrusive-ajax.js",
                        "~/Resource/js/jquery/jquery.validate.unobtrusive.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Resource/js/modernizr-2.6.2.js"));

            bundles.Add(new StyleBundle("~/Resource/css").Include("~/Resource/css/site.css"));

            bundles.Add(new StyleBundle("~/Resource/css/themes/base/css").Include(
                        "~/Resource/css/themes/base/jquery.ui.core.css",
                        "~/Resource/css/themes/base/jquery.ui.resizable.css",
                        "~/Resource/css/themes/base/jquery.ui.selectable.css",
                        "~/Resource/css/themes/base/jquery.ui.accordion.css",
                        "~/Resource/css/themes/base/jquery.ui.autocomplete.css",
                        "~/Resource/css/themes/base/jquery.ui.button.css",
                        "~/Resource/css/themes/base/jquery.ui.dialog.css",
                        "~/Resource/css/themes/base/jquery.ui.slider.css",
                        "~/Resource/css/themes/base/jquery.ui.tabs.css",
                        "~/Resource/css/themes/base/jquery.ui.datepicker.css",
                        "~/Resource/css/themes/base/jquery.ui.progressbar.css",
                        "~/Resource/css/themes/base/jquery.ui.theme.css"));
        }
    }
}