using System;
using System.Text;
using System.Web.Mvc;
using Forloop.HtmlHelpers;

namespace CustomHtmlHelpers
{
    public static class RequireJSHelper
    {
        /// <summary>
        /// Returns a javascript function that will initialize a given module.  Builds view model and initializes it
        /// </summary>
        /// <param name="helper">override helper</param>
        /// <param name="module">view model to initialize</param>
        /// <param name="bindControlName">html control to bind view model to (knockout js)</param>
        /// <param name="dependencies">modules for requirejs to load that the view is dependant on</param>
        /// <returns></returns>
        public static void AddInitRequireJSModule(this HtmlHelper helper, string module, string bindControlName, string[] dependencies = null)
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

            helper.AddScriptBlock(script.ToString());
        }
    }
}