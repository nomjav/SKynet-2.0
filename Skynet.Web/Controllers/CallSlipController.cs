using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Skynet.Service.Interfaces;
using Skynet.Web.Models;

namespace Skynet.Web.Controllers
{
    public class CallSlipController : Controller
    {

        ICallSlipService _callSlipService;

        public CallSlipController(ICallSlipService callSlipService)
        {
            _callSlipService = callSlipService;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult _CallUsBack([DataSourceRequest] DataSourceRequest request)
        {
            return Json(_callSlipService.CallUsBackJobs(request));
        }


    }
}