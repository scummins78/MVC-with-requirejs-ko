using System;
using System.Text;
using System.Web.Mvc;

namespace MVC_with_requirejs
{
    public static class RequireJSHelper
    {
        public static MvcHtmlString InitModule(this HtmlHelper helper, string module, string bindControlName, string[] dependencies = null)
        {
            var script = new StringBuilder();
            var depString = new StringBuilder();
            if (dependencies != null)
            {
                foreach (var dependency in dependencies)
                {
                    depString.AppendFormat("\"{0}\",", dependency);
                }
            }

            script.AppendLine("<script>");
            script.AppendFormat("   require([{0} \"domReady!\"],{1}", depString, Environment.NewLine);
            script.AppendLine("       function(){");
            script.AppendFormat("           require([\"{0}\"]{1},", module, Environment.NewLine);
            script.AppendLine("                 function (Module) {");
            script.AppendFormat("                   var bindCt = document.getElementById(\"{0}\");{1}", bindControlName, Environment.NewLine);
            script.AppendLine("                     var viewModel = new Module();");
            script.AppendLine("                     viewModel.init(bindCt);");
            script.AppendLine("                 }");
            script.AppendLine("             );");
            script.AppendLine("         }");
            script.AppendLine("     );");
            script.AppendLine("</script>");

            return new MvcHtmlString(script.ToString());
        }
    }
}