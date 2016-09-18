﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;

namespace MvcKnowledgeSystem
{
    public class BundleConfig
    {
        public static void RegisterBundles(BundleCollection bundles)
        {
            bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
                        "~/Scripts/jquery-{version}.js"));

            bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
                        "~/Scripts/jquery.validate*"));

            bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
                        "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                "~/Scripts/bootstrap.js"));

            bundles.Add(new ScriptBundle("~/bundles/createtest").Include(
                "~/Scripts/createtest.js"));

            bundles.Add(new ScriptBundle("~/bundles/pagination").Include(
                "~/Scripts/pagination.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/bootstrap.css",
                      "~/Content/site.css"));

            bundles.Add(new StyleBundle("~/Content/mainlayout").Include(
                      "~/Content/mainlayout.css"));

            bundles.Add(new StyleBundle("~/Content/adminlayout").Include(
                      "~/Content/adminlayout.css"));

            bundles.Add(new StyleBundle("~/Content/createtest").Include(
                  "~/Content/createtest.css"));         
        }
    }
}