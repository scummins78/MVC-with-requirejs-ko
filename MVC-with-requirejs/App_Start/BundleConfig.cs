using System.Web;
using System.Web.Optimization;

namespace MVC_with_requirejs
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new Bundle("~/bundles/require").Include(
                "~/Scripts/require.js"));

            bundles.Add(new Bundle("~/bundles/lib").Include(
                "~/Scripts/jquery-{version}.js",
                "~/Scripts/knockout-{version}.js"));

            bundles.Add(new Bundle("~/bundles/domReady").Include(
                "~/Scripts/domReady.js"));

            bundles.Add(new ScriptBundle("~/bundles/common").Include(
                "~/Scripts/App/Services/*.js"));

            // empty bundle for view model scripts.  We will add to this
            // bundle in each partial when needed
            bundles.Add(new ScriptBundle("~/bundles/viewmodels"));

            BundleTable.EnableOptimizations = true;
        }
    }
}