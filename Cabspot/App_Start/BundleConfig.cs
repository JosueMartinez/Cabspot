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
                      //"~/Scripts/bootstrap-datepicker.js",//datepicker
                      "~/Scripts/jasny-bootstrap.min.js"  //fileinput espanol

                      ));  

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.min.css"
                      //"~/Content/site.css",
                      //"~/Content/datepicker.css",   //datepicker
                      //"~/Content/gridmvc.datepicker.min.css",  //datepicker
                      //"~/Content/jasny-bootstrap.min.css"  //fileinput
                      ));
            
            //Gentella template------------------------------------------------------
            bundles.Add(new StyleBundle("~/Content/gentella").Include(
                    "~/Content/animate.min.css",
                    "~/Content/custom.css",
                    "~/Content/icheck/flat/green.css",
                    "~/Content/floatexamples.css",
                    "~/Content/dataTables.tableTools.css"
                ));

            bundles.Add(new ScriptBundle("~/bundles/gentella").Include(
                    "~/Scripts/nporgress.js",
                    "~/Scripts/custom.js",
                    "~/Scripts/skycons/skycons.js",
                    "~/Scripts/wizard/jquery.smartWizard.js",
                    "~/Scripts/input_mask/jquery.inputmask.js",
                    "~/Scripts/spin.js",
                    "~/Scripts/Datatables/jquery.dataTables.js",
                    "~/Scripts/Datatables/dataTables.tableTools.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/notify").Include(
                    "~/Scripts/notify/pnotify.buttons.js",
                    "~/Scripts/notify/pnotify.core.js",
                    "~/Scripts/notify/pnotify.nonblock.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/gauge").Include(
                    "~/Scripts/gauge/gauge.min.js",
                    "~/Scripts/gauge/gauge_demo.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/chart").Include(
                    "~/Scripts/chartjs/chart.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/progress").Include(
                    "~/Scripts/progressbar/bootstrap-progressbar.min.js",
                    "~/Scripts/nicescroll/jquery.nicescroll.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/icheck").Include(
                    "~/Scripts/icheck/icheck.min.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/daterangepicker").Include(
                    "~/Scripts/moment.min.js",
                    "~/Scripts/datepicker/daterangepicker.js"
                ));

            bundles.Add(new ScriptBundle("~/bundles/flot").Include(

                "~/Scripts/flot/jquery.flot.js",
                "~/Scripts/flot/jquery.flot.pie.js",
                "~/Scripts/flot/jquery.flot.orderBars.js",
                "~/Scripts/flot/jquery.flot.time.min.js",
                "~/Scripts/flot/date.js",
                "~/Scripts/flot/jquery.flot.spline.js",
                "~/Scripts/flot/jquery.flot.stack.js",
                "~/Scripts/flot/curvedLines.js",
                "~/Scripts/flot/jquery.flot.resize.js"
    
                ));

            bundles.Add(new ScriptBundle("~/bundles/worldmap").Include(

               "~/Scripts/maps/jquery-jvectormap-2.0.1.min.js",
                "~/Scripts/maps/gdp-data.js",
                "~/Scripts/maps/jquery-jvectormap-world-mill-en.js",
                "~/Scripts/maps/jquery-jvectormap-us-aea-en.js" 

               ));

            //---------------------------------------------------------------------------
            //font-awesome
            bundles.Add(new StyleBundle("~/Content/fa", @"//maxcdn.bootstrapcdn.com/font-awesome/4.4.0/css/font-awesome.min.css"));
        }
    }
}
