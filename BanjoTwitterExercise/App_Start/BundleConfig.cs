﻿using System.Web;
using System.Web.Optimization;

namespace BanjoTwitterExercise
{
    public class BundleConfig
    {
        // For more information on bundling, visit http://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

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
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));


            // angularJS scripts
            bundles.Add(new ScriptBundle("~/bundles/angular")
                .Include("~/Scripts/angular.min.js")
                .Include("~/Scripts/angular-*")
                .Include("~/Scripts/angular/app.js")
                .Include("~/Scripts/plugins/moment/moment.js")
                .IncludeDirectory("~/Scripts/angular-animate", "*.js", true)
                .IncludeDirectory("~/Scripts/angular-aria", "*.js", true)
                .IncludeDirectory("~/Scripts/angular-material", "*.js", true)
                .IncludeDirectory("~/Scripts/angular-ui", "*.js", true)
                .IncludeDirectory("~/Scripts/angular", "*.js", true)
                .IncludeDirectory("~/Scripts/plugins", "*.js", true)
            );

        }
    }
}
