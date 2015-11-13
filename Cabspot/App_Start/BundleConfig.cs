using System.Web;
using System.Web.Optimization;

namespace Cabspot
{
    public class BundleConfig
    {
        

        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.UseCdn = true;

            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js",
                      "~/Scripts/bootstrap-datepicker.js",//datepicker
                      "~/Scripts/jasny-bootstrap.min.js"  //fileinput espanol

                      ));  

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/datepicker.css",   //datepicker
                      "~/Content/gridmvc.datepicker.min.css",  //datepicker
                      "~/Content/jasny-bootstrap.min.css"  //fileinput
                      ));

            
            //admin template bundle-------------------------------------------------------------
            bundles.Add(new StyleBundle("~/Content/admin").Include(
                    "~/Content/metisMenu.min.css",
                    "~/Content/sb-admin-2.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/admin").Include(
                    "~/Scripts/metisMenu.min.js",
                    "~/Scripts/sb-admin-2.js"
                ));

            //font-awesome
            bundles.Add(new StyleBundle("~/Content/fa", @"//maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css"));

            
        }
    }
}
