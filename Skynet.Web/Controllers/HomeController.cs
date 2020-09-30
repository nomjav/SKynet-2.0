using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using Kendo.Mvc;
using Kendo.Mvc.Extensions;
using Kendo.Mvc.Infrastructure;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.ViewEngines;
using Skynet.Data.Helpers;
using Skynet.Service.Interfaces;
using Skynet.Service.ViewModels;
using Skynet.Web.Models;

namespace Skynet.Web.Controllers
{
    
    #region Kendo Order By
    public static class AjaxCustomBindingExtensions
    {

        
        public static IEnumerable ApplyOrdersGrouping(this List<MainCallSlipGridModel> data, IList<GroupDescriptor>
            groupDescriptors)
        {
            if (groupDescriptors != null && groupDescriptors.Any())
            {
                Func<IEnumerable<MainCallSlipGridModel>, IEnumerable<AggregateFunctionsGroup>> selector = null;
                foreach (var group in groupDescriptors.Reverse())
                {
                    if (selector == null)
                    {
                        if (group.Member == "StateAbbreviation")
                        {
                            selector = Orders => BuildInnerGroup(Orders, o => o.StateAbbreviation);
                        }
                        else if (group.Member == "CreatedOn")
                        {
                            selector = Orders => BuildInnerGroup(Orders, o => o.CreatedOn);
                        }
                        else if (group.Member == "CustomerName")
                        {
                            selector = Orders => BuildInnerGroup(Orders, o => o.CustomerName);
                        }
                        else if (group.Member == "ExpectedDate")
                        {
                            selector = Orders => BuildInnerGroup(Orders, o => o.ExpectedDate);
                        }
                        else if (group.Member == "ETA")
                        {
                            selector = Orders => BuildInnerGroup(Orders, o => o.ETA);
                        }
                        else if (group.Member == "TimeInCurrentStatus")
                        {
                            selector = Orders => BuildInnerGroup(Orders, o => o.TimeInCurrentStatus);
                        }
                        else if (group.Member == "JobDescription")
                        {
                            selector = Orders => BuildInnerGroup(Orders, o => o.JobDescription);
                        }
                        else if (group.Member == "EquipmentName")
                        {
                            selector = Orders => BuildInnerGroup(Orders, o => o.EquipmentName);
                        }
                        else if (group.Member == "PrimaryContractor")
                        {
                            selector = Orders => BuildInnerGroup(Orders, o => o.PrimaryContractor);
                        }
                        else if (group.Member == "ContractorBusinessName")
                        {
                            selector = Orders => BuildInnerGroup(Orders, o => o.ContractorBusinessName);
                        }
                        else if (group.Member == "StoreLocationName")
                        {
                            selector = Orders => BuildInnerGroup(Orders, o => o.StoreLocationName);
                        }
                        else if (group.Member == "City")
                        {
                            selector = Orders => BuildInnerGroup(Orders, o => o.City);
                        }
                        else if (group.Member == "TimeZoneCode")
                        {
                            selector = Orders => BuildInnerGroup(Orders, o => o.TimeZoneCode);
                        }
                        else if (group.Member == "JobStatusCode")
                        {
                            selector = Orders => BuildInnerGroup(Orders, o => o.JobStatusCode);
                        }
                    }
                    else
                    {
                        if (group.Member == "City")
                        {
                            selector = BuildGroup(o => o.City, selector);
                        }
                        else if (group.Member == "StateAbbreviation")
                        {
                            selector = BuildGroup(o => o.StateAbbreviation, selector);
                        }
                        else if (group.Member == "CreatedOn")
                        {
                            selector = BuildGroup(o => o.CreatedOn, selector);
                        }
                        else if (group.Member == "CustomerName")
                        {
                            selector = BuildGroup(o => o.CustomerName, selector);
                        }
                        else if (group.Member == "ExpectedDate")
                        {
                            selector = BuildGroup(o => o.ExpectedDate, selector);
                        }
                        else if (group.Member == "ETA")
                        {
                            selector = BuildGroup(o => o.ETA, selector);
                        }
                        else if (group.Member == "TimeInCurrentStatus")
                        {
                            selector = BuildGroup(o => o.TimeInCurrentStatus, selector);
                        }
                        else if (group.Member == "JobDescription")
                        {
                            selector = BuildGroup(o => o.JobDescription, selector);
                        }
                        else if (group.Member == "EquipmentName")
                        {
                            selector = BuildGroup(o => o.EquipmentName, selector);
                        }
                        else if (group.Member == "PrimaryContractor")
                        {
                            selector = BuildGroup(o => o.PrimaryContractor, selector);
                        }
                        else if (group.Member == "ContractorBusinessName")
                        {
                            selector = BuildGroup(o => o.ContractorBusinessName, selector);
                        }
                        else if (group.Member == "StoreLocationName")
                        {
                            selector = BuildGroup(o => o.StoreLocationName, selector);
                        }
                        else if (group.Member == "TimeZoneCode")
                        {
                            selector = BuildGroup(o => o.TimeZoneCode, selector);
                        }
                        else if (group.Member == "JobStatusCode")
                        {
                            selector = BuildGroup(o => o.JobStatusCode, selector);
                        }
                    }
                }

                return selector.Invoke(data).ToList();
            }

            return data.ToList();
        }

        private static Func<IEnumerable<MainCallSlipGridModel>, IEnumerable<AggregateFunctionsGroup>>
            BuildGroup<T>(Expression<Func<MainCallSlipGridModel, T>> groupSelector, Func<IEnumerable<MainCallSlipGridModel>,
            IEnumerable<AggregateFunctionsGroup>> selectorBuilder)
        {
            var tempSelector = selectorBuilder;
            return g => g.GroupBy(groupSelector.Compile())
                         .Select(c => new AggregateFunctionsGroup
                         {
                             Key = c.Key,
                             HasSubgroups = true,
                             Member = groupSelector.MemberWithoutInstance(),
                             Items = tempSelector.Invoke(c).ToList()
                         });
        }

        private static IEnumerable<AggregateFunctionsGroup> BuildInnerGroup<T>(IEnumerable<MainCallSlipGridModel>
            group, Expression<Func<MainCallSlipGridModel, T>> groupSelector)
        {
            return group.GroupBy(groupSelector.Compile())
                    .Select(i => new AggregateFunctionsGroup
                    {
                        Key = i.Key,
                        Member = groupSelector.MemberWithoutInstance(),
                        Items = i.ToList()
                    });
        }

    }

    #endregion
    public class HomeController : Controller
    {

        IDispatchBoard _DispatchBoardService;
        private ICompositeViewEngine _viewEngine;

        //public Utility(ICompositeViewEngine viewEngine)
        //{
        //    _viewEngine = viewEngine;
        //}
        public HomeController(IDispatchBoard DispatchBoardService, ICompositeViewEngine viewEngine)
        {
            _DispatchBoardService = DispatchBoardService;
            _viewEngine = viewEngine;
        }

        public IActionResult Index()
        {
            var dropdowns = _DispatchBoardService.PrepareDropDowns();
            ViewBag.States = dropdowns.States;
            ViewBag.Countries = dropdowns.Countries;
            ViewBag.County = dropdowns.Counties;
            ViewBag.Equipment = dropdowns.Equipments;
            ViewBag.PaymentMethods = dropdowns.PaymentMethods;
            ViewBag.AdTypes = dropdowns.AdTypes;
            ViewBag.JobType = dropdowns.JobTypes;
            ViewBag.JobStatus = dropdowns.JobStatuses;
            //ViewBag.Contractors = dropdowns.Contractors;
            ViewBag.discrepancy = dropdowns.DicrepencyList;
            return View();
        }

        public JsonResult MainCallSlipData([DataSourceRequest] DataSourceRequest request, [FromForm] CallSlipModel model)
        {
            //ViewBag.CanAccessMarkups = CanAccessInvoices;
            try
            {
                var gridModel = _DispatchBoardService.GetMainCallSlipData(request, model);
                IEnumerable data = gridModel.listCallslips.ApplyOrdersGrouping(request.Groups);
                return Json(new DataSourceResult { Data = data, Total = gridModel.Total });
            }
            catch (Exception exception)
            {
                //Logger.LogException(exception.Message, exception);
                return Json(new { success = false });
            }
        }


        public JsonResult GetNumberOfJobsByStatus()
        {
            List<string> jobStatuses = _DispatchBoardService.NumberOfJobsByStatus();

            return Json(new { Totals = jobStatuses, success = true });
        }

        public JsonResult DailyJobStatusReport([FromBody] Boards boards)
        {
            try
            {
                DailyJobStatusModel tryModel = new DailyJobStatusModel();
                tryModel = _DispatchBoardService.JobStatusReport(boards.InState, boards.OutOfState, boards.Citibank, boards.Aiss, boards.Project);
                return Json(new { success = true, message = "Job Alert History Found!", model = tryModel });
            }
            catch (Exception exception)
            {
                //Logger.LogException(exception.Message, exception);
                return Json(new { success = false, message = "Unable to generate the Daily Job Status Report, please try again." });
            }
        }

        public JsonResult GetJobDetailsById([FromBody] Boards boards)
        {
            try
            {
                var dropdowns = _DispatchBoardService.PrepareDropDowns();
                ViewBag.States = dropdowns.States;
                ViewBag.Countries = dropdowns.Countries;
                ViewBag.County = dropdowns.Counties;
                ViewBag.Equipment = dropdowns.Equipments;
                ViewBag.PaymentMethods = dropdowns.PaymentMethods;
                ViewBag.AdTypes = dropdowns.AdTypes;
                ViewBag.JobType = dropdowns.JobTypes;
                ViewBag.JobStatus = dropdowns.JobStatuses;
                ViewBag.discrepancy = dropdowns.DicrepencyList;
                int id = Convert.ToInt32(boards.CallSlipId);
                CallSlipModel model = _DispatchBoardService.GetJobDetailsById(id, boards.prevCallSlipId);
                var serviceView = Utility.RenderPartialViewToString(this.ControllerContext, ViewData, TempData, "_Service", model, _viewEngine);
                var backgroundColor = model.BackgroundColor;
                var textColor = model.FontColor;
                return Json(
                    new
                    {
                        backgroundColor, textColor,
                        serviceView,
                        //lockedUserName = lockedUserName,
                        success = true,
                        message = "Job found.",
                        //OnDateDayName = dateday,
                        //ftString,
                        //ttString,
                        //lat,
                        //lng,
                        //logs,
                        //StoreChange
                    });
            }
            catch (Exception exception)
            {
                //Logger.LogException(exception.Message, exception);
                return Json(new { success = false, message = "Unable to get the Job Information, please try again." });
            }
        }

        public JsonResult GetContractorsByJobId([FromBody]Boards board)
        {
            try
            {
                var techAndContractors = _DispatchBoardService.GetContractorsByJobId(board.CallSlipId);

                return Json(
                   new { contractors = techAndContractors.ContractorList, technicians = techAndContractors.TechList, /*canAccessReceipts = CanAccessReceipts,*/ success = true });
            }
            catch (Exception ex)
            {
                //Logger.LogException(ex.Message, ex);
                return Json(new { success = false, message = "Unable to get the Contractor Information, please try again." });
            }
        }

        public JsonResult GetTablesDataByJobId([FromBody]TableDataModel board)
        {
            try
            {
                var tablesLists = _DispatchBoardService.GetTablesDataByJobId(board);

                return Json(
                   new { Location = tablesLists.locationList, Emails = tablesLists.emailList, ContractorActiveJobs = tablesLists.ContractorActiveList, TechnicianHistoryList = tablesLists.TechnicianActiveList, listMessages = tablesLists.smsList, success = true });
            }
            catch (Exception ex)
            {
                //Logger.LogException(ex.Message, ex);
                return Json(new { success = false, message = "Unable to get the Tables Data, please try again." });
            }
        }
        
        public JsonResult GetPaymentsByJobId([FromBody]TableDataModel board)
        {
            try
            {
                var listPayments = _DispatchBoardService.GetPaymentsByJobId(board.CallSlipId);

                return Json(new { payments = listPayments, success = true });
            }
            catch (Exception ex)
            {
                //Logger.LogException(ex.Message, ex);
                return Json(new { success = false, message = "Unable to get the Tables Data, please try again." });
            }
        }

        public JsonResult GetPaymentMethodsByJobId([FromBody]TableDataModel board)
        {
            try
            {

                var listCreditCards = _DispatchBoardService.GetPaymentMethodsByJobId(board.CallSlipId);

               
                return Json(
                   new { cards = listCreditCards, success = true });
            }
            catch (Exception ex)
            {
                //Logger.LogException(ex.Message, ex);
                return Json(new { success = false, message = "Unable to get the Job Payment Information, please try again." });
            }
        }

        public JsonResult GetNotesAndDocumentsByJobId([FromBody]TableDataModel board)
        {
            try
            {
                var NotesDocumets = _DispatchBoardService.GetNotesAndDocumentsByJobId(board.CallSlipId);

                return Json(
                   new { Notes = NotesDocumets.notesList, Documents = NotesDocumets.docsList, success = true });
            }
            catch (Exception ex)
            {
                //Logger.LogException(ex.Message, ex);
                return Json(new { success = false, message = "Unable to get the Tables Data, please try again." });
            }
        }

        public JsonResult GetJobProgressBarDetails([FromBody]Boards board)
        {
            try
            {
                var model = _DispatchBoardService.GetJobProgressBarDetails(board.CallSlipId);

                return Json(
                   new { model = model, success = true });
            }
            catch (Exception ex)
            {
                //Logger.LogException(ex.Message, ex);
                return Json(new { success = false, message = "Unable to get the ProgressBar Data, please try again." });
            }
        }

        public JsonResult JobStatusHistory([FromBody]Boards board)
        {
            try
            {
                var listModel = _DispatchBoardService.JobStatusHistory(board.CallSlipId);

                return Json(
                   new { listModel = listModel, success = true });
            }
            catch (Exception ex)
            {
                //Logger.LogException(ex.Message, ex);
                return Json(new { success = false, message = "Unable to get the ProgressBar Data, please try again." });
            }
        }


        public JsonResult GetPartsDetailsByCallSlipId([FromBody]Boards board)
        {
            try
            {
                if (string.IsNullOrEmpty(board.CallSlipId))
                {
                    return Json(new { success = false, message = "No Job is selected at the moment." });
                }
                var model = _DispatchBoardService.GetPartsDetails(board.CallSlipId);
                return Json(new { success = true, parts = model.multiEstList, stateExempt = model.StateExempt });
            }
            catch (Exception exception)
            {
                //Logger.LogException(exception.Message, exception);
                return Json(new { success = false, message = "Unable to get the parts, please try again." });
            }
        }

        public JsonResult LoadParts(string query)
        {
            try {
                var parts = _DispatchBoardService.GetAllParts(query);
                return Json(parts);

            }
            catch (Exception ex)
            {
                return Json(new { success = false, message = "Unable to get the parts, please try again." });
            }
        }

        public JsonResult GetPartsByCallSlipId([FromBody]MultiEstimates board)
        {
            try
            {
                if (string.IsNullOrEmpty(board.CallSlipId))
                {
                    return Json(new { success = false, message = "No Job is selected at the moment." });
                }
                var listModel = _DispatchBoardService.GetPartsByCallSlipId(board.CallSlipId, board.EstimateNumber);

                return Json(
                   new { success = true, message = "parts exist.", parts = listModel.jobPart, total = listModel.subtotal, stateExempt = listModel.StateExempt });
            }
            catch (Exception ex)
            {
                //Logger.LogException(ex.Message, ex);
                return Json(new { success = false, message = "Unable to get the ProgressBar Data, please try again." });
            }
        }

        public JsonResult GetPartDetails([FromBody]MultiEstimates estimate)
        {
            try
            {

                var jobPart = _DispatchBoardService.GetPartDetails(estimate.PartName, estimate.CustomerName, estimate.JobPartId);
                return Json(new { success= true, message="Part Found", part = jobPart });
            }
            catch (Exception exception)
            {
                //Logger.LogException(exception.Message, exception);
                return Json(new { success = false, message = "Unable to get the part, please try again." });
            }
        }

        public PartialViewResult ProgressBar()
        {
            return PartialView("_ProgressBar");
        }


        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
