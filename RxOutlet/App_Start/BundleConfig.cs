using System.Web;
using System.Web.Optimization;

namespace RxOutlet
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js",
                        "~/Scripts/jquery.countdown.js",
                        "~/Scripts/jquery.plugin.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            // Use the development version of Modernizr to develop with and learn from. Then, when you're
            // ready for production, use the build tool at http://modernizr.com to pick only the tests you need.
            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/bootstrap.js",
                      "~/Scripts/respond.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/animate.css",
                     "~/Content/bootstrap.css",
                      "~/Content/site.css",
                      "~/Content/reset.css",
                      "~/Content/bootstrap.min.css",
                       "~/Content/easyzoom.css",
                      "~/Content/font-awesome.min.css",
                       "~/Content/font-awesome.min1.css",
                       "~/Content/global.css",
                       "~/Content/global-circle.css",
                        "~/Content/jquery.autocomplete.css",
                      "~/Content/owl.carousel.css",
                      "~/Content/jquery-ui.css",
                      "~/Content/animate.css",
                      "~/Content/global.css",
                      "~/Content/style.css",
                      "~/Content/responsive.css",
                        "~/Content/style.css",
                       "~/Content/style-circle.css",
                      "~/Content/AutoSearchStyle.css",
                       "~/Content/ace-ie.min.css",
                        "~/Content/ace-part2.min.css",
                         "~/Content/ace-rtl.min.css",
                          "~/Content/ace-skins.min.css",
                           "~/Content/ace.min.css",
    "~/Content/bootstrap-colorpicker.min.css",
                             "~/Content/bootstrap-datepicker3.min.css",
                              "~/Content/bootstrap-datetimepicker.min.css",
                               "~/Content/bootstrap-duallistbox.min.css",
                                "~/Content/bootstrap-editable.min.css",
                                 "~/Content/bootstrap-multiselect.min.css",
                                  "~/Content/bootstrap-timepicker.min.css",
                                   "~/Content/chosen.min.css",
                                    "~/Content/datepicker.css",
                                     "~/Content/daterangepicker.min.css",
                                     "~/Content/colorbox.min.css",
                            "~/Content/select2.min.css",
                             "~/Content/prettify.min.css",
                              "~/Content/jquery.gritter.min.css",
                               "~/Content/jquery-ui.min.css",
                                "~/Content/jquery-ui.custom.min.css",
                                 "~/Content/fullcalendar.min.css",
                                  "~/Content/fonts.googleapis.com.css",
                                   "~/Content/dropzone.min.css"
  
                      ));
        }
    }
}
