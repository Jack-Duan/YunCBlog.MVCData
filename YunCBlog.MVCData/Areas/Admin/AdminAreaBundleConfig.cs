using System.Web;
using System.Web.Optimization;

namespace YunCBlog.MVCData
{
    internal static class AdminAreaBundleConfig
    {
        internal static void RegisterBundles(BundleCollection bundles)
        {                       
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



            bundles.Add(new StyleBundle("~/editor/css").Include(
                      "~/plugins/editor_md/examples/css/style.css",
                      "~/plugins/editor_md/css/editormd.css",
                      "~/plugins/editor_md/css/editormd.preview.css"));


            bundles.Add(new ScriptBundle("~/editor/js").Include(
                       "~/plugins/editor_md/examples/js/jquery.min.js",
                        "~/plugins/editor_md/lib/marked.min.js",
                        "~/plugins/editor_md/lib/prettify.min.js",
                        "~/plugins/editor_md/lib/raphael.min.js",
                        "~/plugins/editor_md/lib/underscore.min.js",
                        "~/plugins/editor_md/lib/sequence-diagram.min.js",
                        "~/plugins/editor_md/lib/flowchart.min.js",
                        "~/plugins/editor_md/lib/jquery.flowchart.min.js",
                        "~/plugins/editor_md/editormd.min.js",
                        "~/plugins/editor_md/editormd.js"));
        }
    }
}
