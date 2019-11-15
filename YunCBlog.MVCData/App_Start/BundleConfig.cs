using System.Web;
using System.Web.Optimization;

namespace YunCBlog.MVCData
{
    public class BundleConfig
    {
        // 有关捆绑的详细信息，请访问 https://go.microsoft.com/fwlink/?LinkId=301862
        public static void RegisterBundles(BundleCollection bundles)
        {
            //bundles.Add(new ScriptBundle("~/bundles/jquery").Include(
            //            "~/Scripts/jquery-{version}.js"));

            //bundles.Add(new ScriptBundle("~/bundles/jqueryval").Include(
            //            "~/Scripts/jquery.validate*"));

            //// 使用要用于开发和学习的 Modernizr 的开发版本。然后，当你做好
            //// 生产准备就绪，请使用 https://modernizr.com 上的生成工具仅选择所需的测试。
            //bundles.Add(new ScriptBundle("~/bundles/modernizr").Include(
            //            "~/Scripts/modernizr-*"));

            bundles.Add(new ScriptBundle("~/bundles/bootstrap").Include(
                      "~/Scripts/jquery.min.js",
                      "~/Scripts/jquery.easyfader.min.js",
                      "~/Scripts/scrollReveal.js",
                      "~/Scripts/common.js"));

            bundles.Add(new StyleBundle("~/Content/css").Include(
                      "~/Content/base.css",
                      "~/Content/index.css",
                      "~/Content/m.css"));


            bundles.Add(new StyleBundle("~/AdminLogin/css").Include(
                      "~/Areas/Admin/css/font.css",
                      //"~/Areas/Admin/css/theme1999.min.css",
                      "~/Areas/Admin/css/login.css",
                      "~/Areas/Admin/css/xadmin.css"));
            bundles.Add(new ScriptBundle("~/adminjs/loginjs").Include(
                      "~/Areas/Admin/lib/layui/layui.js"));


            bundles.Add(new StyleBundle("~/Admin/css").Include(
                      "~/Areas/Admin/css/font.css",
                      //"~/Areas/Admin/css/theme1999.min.css",
                      "~/Areas/Admin/css/xadmin.css"));
            bundles.Add(new ScriptBundle("~/admin/js").Include(
                      "~/Areas/Admin/js/xadmin.js"));
            bundles.Add(new ScriptBundle("~/admin/layui").Include(
                     "~/Areas/Admin/lib/layui/layui.js"));


        }
    }
}
