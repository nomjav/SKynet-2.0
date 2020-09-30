using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace Skynet.Data.Helpers
{
    public static class Utility
    {
        //private static ICompositeViewEngine _viewEngine;

        //public Utility(ICompositeViewEngine viewEngine)
        //{
        //    _viewEngine = viewEngine;
        //}
        public static string RenderPartialViewToString(this ControllerContext ControllerContext, ViewDataDictionary ViewData, ITempDataDictionary TempData, string viewName, object model, ICompositeViewEngine _viewEngine)
        {
            if (string.IsNullOrEmpty(viewName))
                viewName = ControllerContext.ActionDescriptor.ActionName;

            ViewData.Model = model;

            using (var writer = new StringWriter())
            {
                ViewEngineResult viewResult =
                    _viewEngine.FindView(ControllerContext, viewName, false);

                ViewContext viewContext = new ViewContext(
                    ControllerContext,
                    viewResult.View,
                    ViewData,
                    TempData,
                    writer,
                    new HtmlHelperOptions()
                );

                viewResult.View.RenderAsync(viewContext);

                return writer.GetStringBuilder().ToString();
            }
        }
    }
}
