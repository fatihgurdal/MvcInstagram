using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MVCInstagramFatih.App_Start
{
    public class BundleConfig
    {
        public static void RegisterBundle(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/js/PageEnd").Include(
                "~/Scripts/jquery-1.10.1.min.js",
                "~/Scripts/jquery-ui.min.js",
                "~/Scripts/bootstrap.min.js",
                "~/Scripts/jquery.isotope.min.js",
                "~/Scripts/jquery.isotope.perfectmasonry.js",
                "~/Scripts/jquery.raty.min.js",
                "~/Scripts/jquery.flexslider.js",
                "~/Scripts/jquery.mousewheWel.js",
                "~/Scripts/jquery.mCustomScrollbar.js",
                "~/Scripts/jquery.hoverdir.js",
                "~/Scripts/jquery.selectBoxIt.min.js",
                "~/Scripts/jquery.fancybox.pack.js",
                "~/Scripts/main.js"
                ));
            bundles.Add(new StyleBundle("~/Css/PageStart").Include(
                    "~/Content/bootstrap.min.css",
                    "~/Content/font-awesome.min.css",
                    "~/Content/typicons.css",
                    "~/Content/flexslider.css",
                    "~/Content/jquery.selectBoxIt.css",
                    "~/Content/jquery.fancybox.css",
                    "~/Content/main.css",
                    "~/Content/hint.css"
                ));

            bundles.Add(new StyleBundle("~/Js/PageStart").Include(
                    "~/Scripts/modernizr-2.6.2-respond-1.1.0.min.js"                    
                ));
            BundleTable.EnableOptimizations = true;
        }
    }
}