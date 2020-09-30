
using Kendo.Mvc.Extensions;
using Kendo.Mvc.UI;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using Skynet.Data.Helpers;
using Skynet.Data.Models;
using Skynet.Repository.Interfaces;
using Skynet.Repository.Repositories;
using Skynet.Service.Interfaces;
using Skynet.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Globalization;
using System.Linq;
using System.Text.RegularExpressions;

namespace Skynet.Service.Services
{
    public class DispatchBoard : IDispatchBoard
    {
        private IUnitOfWork _unitOfWork;
        private AcademyLockSmith_LiveContext _context;
        public DispatchBoard(AcademyLockSmith_LiveContext context, IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
            _context = context;
        }


        public GridModel GetMainCallSlipData([DataSourceRequest]DataSourceRequest request, CallSlipModel model)
        {
            DateTime today = DateTime.Now;
            var job = new List<vwJobs>();
            IQueryable<vwJobs> jobs = Enumerable.Empty<vwJobs>().AsQueryable();
            PagedList<vwJobs> paged = null;
            // PagedList<vwJob> paged;

            if (!String.IsNullOrEmpty(model.SearchType) && model.SearchType.Equals("2"))
            {
                var usrReviewedJobs = _unitOfWork.GenericRepository<UserJobsRecord>().GetAsQuerable(x => x.UserId == 10332).OrderByDescending(e => e.Id).DistinctBy(p => p.JobId).Take(15)
                    .OrderByDescending(q => q.ViewedOn).Select(w => w.JobId).ToList();
                if (usrReviewedJobs.Count > 0)
                {
                    //jobs = _unitOfWork.vwJobRepository.GetAsQuerable(t => usrReviewedJobs.Contains(t.Id), t =>t.OrderBy(d => usrReviewedJobs.IndexOf(d.Id)));
                    jobs = _unitOfWork.GenericRepository<vwJobs>().GetAsQuerable(t => usrReviewedJobs.Contains(t.Id)).ToList().OrderBy(d => usrReviewedJobs.IndexOf(d.Id)).AsQueryable();
                }

                //if (command.SortDescriptors.Any())
                //{
                //    jobs = jobs.Sort(command.SortDescriptors) as IQueryable<vwJob>;
                //}
                //paged = new PagedList<vwJob>(jobs.ToList(), 0, 15);
            }
            else
            {
                // if user is set to view all jobs
                if (1 == 1)
                {
                    jobs = _unitOfWork.GenericRepository<vwJobs>().GetAsQuerable(null,
                        o => o.OrderBy(x => x.StatusOrder).ThenByDescending(x => x.Id), "", false);
                }
                //else
                //{
                //    jobs = _unitOfWork.vwJobRepository.GetAsQuerable(x => (x.JobTypeId == ALSContext.Current.User.CurrentBoardType),
                //        o => o.OrderBy(x => x.StatusOrder).ThenByDescending(x => x.Id), "", false);
                //}

                #region filter jobs

                if (model.Search)
                {
                    // search by job id
                    if (model.Id != 0)
                    {
                        jobs = jobs.Where(x => x.Id == model.Id);
                    }
                    // filter by work order i.e. ponumber
                    else if (!string.IsNullOrEmpty(model.PONumber))
                    {
                        jobs = jobs.Where(x => x.PONumber.Contains(model.PONumber));
                    }
                    else
                    {
                        //filter by job status
                        if (model.JobStatusId != 0 && model.JobStatusId != null)
                        {
                            jobs = jobs.Where(x => x.JobStatusId == model.JobStatusId);
                            // GetCustomFilterJobsByStatus(jobs);
                        }

                        // search by job city
                        if (!string.IsNullOrEmpty(model.City))
                        {
                            jobs = jobs.Where(x => x.City.Contains(model.City));
                        }

                        // search by job state
                        if (model.StateId != 0)
                        {
                            jobs = jobs.Where(x => x.StateId == model.StateId);
                        }

                        // filter by dispatch time
                        if (!string.IsNullOrEmpty(model.TimeDispatched))
                        {
                            DateTime timeDispatched = Convert.ToDateTime(model.TimeDispatched);
                            jobs =
                                jobs.Where(x => x.DispatchedTime != null && x.DispatchedTime.Value.Year == timeDispatched.Year && x.DispatchedTime.Value.Month == timeDispatched.Month && x.DispatchedTime.Value.Day == timeDispatched.Day);
                        }

                        // fitler by date range
                        if (!string.IsNullOrEmpty(model.FromDate) && !string.IsNullOrEmpty(model.ToDate))
                        {
                            DateTime dateFrom = Convert.ToDateTime(model.FromDate);
                            DateTime dateTo = Convert.ToDateTime(model.ToDate);
                            jobs =
                                jobs.Where(
                                    x =>
                                        x.CreatedOn.Date >= dateFrom.Date &&
                                        x.CreatedOn.Date <= dateTo.Date);
                        }
                        else
                        {
                            // this filter will work in two ways
                            //  1. filter by main date filter on the dispatch board, over the blue bar
                            //  2. and when the search panel is shown and user entered the From Date
                            if (!string.IsNullOrEmpty(model.FromDate))
                            {
                                DateTime dateFrom = Convert.ToDateTime(model.FromDate);
                                jobs = jobs.Where(x => x.CreatedOn.Year == dateFrom.Year && x.CreatedOn.Month == dateFrom.Month && x.CreatedOn.Day == dateFrom.Day);
                            }
                        }

                        //filter by dispatchboard type     InState: 3,  OutOfState: 4,   CitiBank: 7,   AissJobs: 8               /* Arslan */    
                        //filter by dispatchboard type     regional: 3,  corporate: 4,   CitiBank: 7,   walmart: 8   , projects: 9            /* Noman */  Task # 1262  
                        if (!((model.cbInState) && (model.cbOutOfState) && (model.cbCitiBank) && (model.cbAissJobs) && (model.cbProjects)))
                        {
                            if (model.cbInState)
                            {
                                if (model.cbOutOfState)
                                {
                                    if (model.cbCitiBank)
                                    {
                                        if (model.cbAissJobs)
                                            jobs = jobs.Where(x => x.JobTypeId == 3 || x.JobTypeId == 4 || x.JobTypeId == 7 || x.JobTypeId == 8);
                                        else if (model.cbProjects)
                                            jobs = jobs.Where(x => x.JobTypeId == 3 || x.JobTypeId == 4 || x.JobTypeId == 7 || x.JobTypeId == 9);
                                        else
                                            jobs = jobs.Where(x => x.JobTypeId == 3 || x.JobTypeId == 4 || x.JobTypeId == 7);
                                    }
                                    else if (model.cbAissJobs)
                                        jobs = jobs.Where(x => x.JobTypeId == 3 || x.JobTypeId == 4 || x.JobTypeId == 8);
                                    else if (model.cbProjects)
                                        jobs = jobs.Where(x => x.JobTypeId == 3 || x.JobTypeId == 4 || x.JobTypeId == 9);
                                    else
                                        jobs = jobs.Where(x => x.JobTypeId == 3 || x.JobTypeId == 4);
                                }
                                else if (model.cbCitiBank)
                                {
                                    if (model.cbAissJobs)
                                        jobs = jobs.Where(x => x.JobTypeId == 3 || x.JobTypeId == 7 || x.JobTypeId == 8);
                                    else if (model.cbProjects)
                                        jobs = jobs.Where(x => x.JobTypeId == 3 || x.JobTypeId == 7 || x.JobTypeId == 9);
                                    else
                                        jobs = jobs.Where(x => x.JobTypeId == 3 || x.JobTypeId == 7);
                                }
                                else if (model.cbAissJobs)
                                    if (model.cbProjects)
                                        jobs = jobs.Where(x => x.JobTypeId == 3 || x.JobTypeId == 8 || x.JobTypeId == 9);
                                    else
                                        jobs = jobs.Where(x => x.JobTypeId == 3 || x.JobTypeId == 8);
                                else if (model.cbProjects)
                                    jobs = jobs.Where(x => x.JobTypeId == 3 || x.JobTypeId == 9);
                                else
                                    jobs = jobs.Where(x => x.JobTypeId == 3);
                            }

                            else if (model.cbOutOfState)
                            {
                                if (model.cbCitiBank)
                                {
                                    if (model.cbAissJobs)
                                        if (model.cbProjects)
                                            jobs = jobs.Where(x => x.JobTypeId == 4 || x.JobTypeId == 7 || x.JobTypeId == 8 || x.JobTypeId == 9);
                                        else
                                            jobs = jobs.Where(x => x.JobTypeId == 4 || x.JobTypeId == 7 || x.JobTypeId == 8);
                                    else if (model.cbProjects)
                                        jobs = jobs.Where(x => x.JobTypeId == 4 || x.JobTypeId == 7 || x.JobTypeId == 9);
                                    else
                                        jobs = jobs.Where(x => x.JobTypeId == 4 || x.JobTypeId == 7);
                                }
                                //if (model.cbAissJobs)
                                //    jobs = jobs.Where(x => x.JobTypeId == 4 || x.JobTypeId == 7 || x.JobTypeId == 8);
                                //else
                                //    jobs = jobs.Where(x => x.JobTypeId == 4 || x.JobTypeId == 7);
                                else if (model.cbAissJobs)
                                {
                                    if (model.cbProjects)
                                        jobs = jobs.Where(x => x.JobTypeId == 4 || x.JobTypeId == 8 || x.JobTypeId == 9);
                                    else
                                        jobs = jobs.Where(x => x.JobTypeId == 4 || x.JobTypeId == 8);
                                }
                                //jobs = jobs.Where(x => x.JobTypeId == 4 || x.JobTypeId == 8);
                                else if (model.cbProjects)
                                {
                                    jobs = jobs.Where(x => x.JobTypeId == 4 || x.JobTypeId == 9);
                                }
                                else
                                    jobs = jobs.Where(x => x.JobTypeId == 4);
                            }

                            else if (model.cbCitiBank)
                            {
                                if (model.cbAissJobs)
                                    if (model.cbProjects)
                                        jobs = jobs.Where(x => x.JobTypeId == 7 || x.JobTypeId == 8 || x.JobTypeId == 9);
                                    else
                                        jobs = jobs.Where(x => x.JobTypeId == 7 || x.JobTypeId == 8);
                                else if (model.cbProjects)
                                    jobs = jobs.Where(x => x.JobTypeId == 7 || x.JobTypeId == 9);
                                else
                                    jobs = jobs.Where(x => x.JobTypeId == 7);
                            }

                            else if (model.cbAissJobs)
                            {
                                if (model.cbProjects)
                                    jobs = jobs.Where(x => x.JobTypeId == 8 || x.JobTypeId == 9);
                                else
                                    jobs = jobs.Where(x => x.JobTypeId == 8);
                            }
                            else if (model.cbProjects)
                            {
                                jobs = jobs.Where(x => x.JobTypeId == 9);
                                //var job = _unitOfWork.JobRepository.Get(x => x.projectId != null);
                                //HashSet<long> diffID = new HashSet<long>(job.Select(x => x.Id));
                                //jobs = jobs.Where(x => diffID.Contains(x.Id));
                            }

                        }


                        //filter by customer type
                        if (model.CustomerTypeId != 5 && model.CustomerTypeId != 0)
                        {
                            //jobs = model.CustomerTypeId == 3 ? jobs.Where(x => x.IsAuto) : jobs.Where(x => x.CustomerType == model.CustomerTypeId);
                            jobs = jobs.Where(x => x.CustomerType == model.CustomerTypeId);
                        }

                        //filter by contractor name
                        if (model.ContractorId != 0)
                        {
                            jobs = jobs.Where(x => x.JobContractorMapping.Any(jcm => jcm.ContractorId == model.ContractorId));
                        }

                        // filter by date range
                        if (!string.IsNullOrEmpty(model.ExpectedFromTime) && !string.IsNullOrEmpty(model.ExpectedToTime))
                        {
                            DateTime efDate = Convert.ToDateTime(model.ExpectedFromTime);
                            DateTime etDate = Convert.ToDateTime(model.ExpectedToTime);
                            //Work Date
                            jobs =
                                jobs.Where(
                                    x =>
                                        x.ExpectedDate.Value.Date >= efDate.Date &&
                                        x.ExpectedDate.Value.Date <= etDate.Date);

                            ////Created/Booked Date
                            //jobs =
                            //  jobs.Where(
                            //      x =>
                            //          EntityFunctions.TruncateTime(x.CreatedOn) >= efDate.Date &&
                            //          EntityFunctions.TruncateTime(x.CreatedOn) <= etDate.Date);
                        }

                        if (!string.IsNullOrEmpty(model.BookedFromTime) && !string.IsNullOrEmpty(model.BookedToTime))
                        {
                            DateTime efDate = Convert.ToDateTime(model.BookedFromTime);
                            DateTime etDate = Convert.ToDateTime(model.BookedToTime);
                            //Work Date
                            jobs =
                                jobs.Where(
                                    x =>
                                        x.CreatedOn.Date >= efDate.Date &&
                                        x.CreatedOn.Date <= etDate.Date);

                            ////Created/Booked Date
                            //jobs =
                            //  jobs.Where(
                            //      x =>
                            //          EntityFunctions.TruncateTime(x.CreatedOn) >= efDate.Date &&
                            //          EntityFunctions.TruncateTime(x.CreatedOn) <= etDate.Date);
                        }

                        // filter by single date
                        if (!string.IsNullOrEmpty(model.ExpectedFromTime) && string.IsNullOrEmpty(model.ExpectedToTime))
                        {
                            DateTime efDate = Convert.ToDateTime(model.ExpectedFromTime);
                            jobs = jobs.Where(x => x.ExpectedDate.Value.Year == efDate.Year && x.ExpectedDate.Value.Month == efDate.Month && x.ExpectedDate.Value.Day == efDate.Day);
                        }

                        // filter by store number
                        if (!string.IsNullOrEmpty(model.StoreNumber))
                        {
                            jobs = jobs.Where(x => x.StoreNumber.Equals(model.StoreNumber));
                        }

                        // filter by store name
                        if (!string.IsNullOrEmpty(model.StoreLocationName))
                        {
                            jobs = jobs.Where(x => x.StoreName.Contains(model.StoreLocationName));
                        }

                        // filter by customer name
                        if (!string.IsNullOrEmpty(model.CustomerName))
                        {
                            jobs = jobs.Where(x => x.CustomerName.Contains(model.CustomerName));
                        }

                        // filter by customer WO
                        if (!string.IsNullOrEmpty(model.WorkOrder2))
                        {
                            jobs = jobs.Where(x => x.WorkOrder2.Contains(model.WorkOrder2));
                        }

                        // filter by phone number
                        if (!string.IsNullOrEmpty(model.Phone))
                        {
                            jobs = jobs.Where(x => x.Phone.Equals(model.Phone) || x.Phone.Contains(model.Phone));
                        }

                        // fiter by receipt number in 
                        if (!string.IsNullOrEmpty(model.ReceiptNumber))
                        {
                            jobs = jobs.Where(j => j.JobPayments.Any(r => r.ReceiptNumber.Contains(model.ReceiptNumber)));
                        }

                        // fiter by tech first name
                        if (!string.IsNullOrEmpty(model.TechFirstName))
                        {
                            jobs = jobs.Where(j => j.JobContractorMapping.Any(r => r.Contractor.FirstName.Contains(model.TechFirstName)));
                        }

                        // fiter by tech last name
                        if (!string.IsNullOrEmpty(model.TechLastName))
                        {
                            jobs = jobs.Where(j => j.JobContractorMapping.Any(r => r.Contractor.LastName.Contains(model.TechLastName)));
                        }

                        // fiter by receipt number in 
                        if (!string.IsNullOrEmpty(model.TechCompanyName))
                        {
                            jobs = jobs.Where(j => j.JobContractorMapping.Any(r => r.Contractor.BusinessName.Contains(model.TechCompanyName)));
                        }

                        // filter by job address
                        if (!string.IsNullOrEmpty(model.Address))
                        {
                            jobs = jobs.Where(j => j.Address.Contains(model.Address));
                        }

                        // filter by job POTrackingNumber
                        if (!string.IsNullOrEmpty(model.POTrackingNumber))
                        {
                            jobs = jobs.Where(j => j.PurchaseOrders.Any(p => p.TrackingNumber.Contains(model.POTrackingNumber)));
                        }

                        //old: commented in acc with task #942 in tasksheet. see comments there.
                        // Exclude the WallMart Jobs If Clicked from the Second Row of No Boxes
                        //if (model.ExcludeWallMartJobs.HasValue && model.ExcludeWallMartJobs.Value)
                        //{
                        //    DateTime todayDate = DateTime.Today.AddDays(1).AddTicks(-1);
                        //    //jobs = jobs.Where(t => !t.CustomerName.Contains("WalMart") && t.ExpectedDate <= todayDate && t.JobTypeId != 7 && t.JobTypeId != 8);
                        //    jobs = jobs.Where(t => !t.CustomerName.Contains("WalMart") && t.ExpectedDate <= todayDate);
                        //}

                        //new: in acc with task #942
                        if (model.ExcludeWallMartJobs.HasValue && model.ExcludeWallMartJobs.Value)
                        {
                            DateTime todayDate = DateTime.Today.AddDays(1).AddTicks(-1);
                            jobs = jobs.Where(t => t.ExpectedDate <= todayDate);
                        }

                        // filter by locked status 
                        jobs = jobs.Where(j => j.Locked == model.Locked);
                    }
                }
                else
                {
                    jobs = jobs.Where(x => x.CreatedOn.Year == DateTime.Now.Year
                            && x.CreatedOn.Month == DateTime.Now.Month
                            && x.CreatedOn.Day == DateTime.Now.Day && !x.Locked);
                }


                if (model.SearchType == "3")
                {
                    // status  0, 4, 4.3, 4.5, 5
                    jobs = jobs.Where(x => x.JobStatusId == 22 || x.JobStatusId == 8 || x.JobStatusId == 27 || x.JobStatusId == 7 || x.JobStatusId == 6);
                }
                else if (model.SearchType == "4")
                {
                    jobs = jobs.Where(x => x.JobStatusId == 9 || x.JobStatusId == 10 || x.JobStatusId == 23);
                }
                else if (model.SearchType == "5")
                {
                    jobs = jobs.Where(x => x.JobStatusId == 4 || x.JobStatusId == 24 || x.JobStatusId == 36 || x.JobStatusId == 14 || x.JobStatusId == 17);
                }
                else if (model.SearchType == "6")
                {
                    jobs = jobs.Where(x => x.JobStatusId == 31 || x.JobStatusId == 32);
                }

                #endregion


                if (request.Filters.Any())
                {
                    jobs = jobs.Where(request.Filters) as IQueryable<vwJobs>;
                }

                if (request.Sorts.Any())
                {
                    jobs = jobs.Sort(request.Sorts) as IQueryable<vwJobs>;
                }
                if (request.PageSize == 0)
                    request.PageSize = 100;

                paged = new PagedList<vwJobs>(jobs, request.Page - 1, request.PageSize);
            }

            var userJobRecoreds = _unitOfWork.GenericRepository<UserJobsRecord>().GetAsQuerable(x => x.UserId == 10332).OrderByDescending(e => e.Id).DistinctBy(p => p.JobId).Take(15)
                      .OrderByDescending(q => q.ViewedOn).AsQueryable();

            List<MainCallSlipGridModel> listModel = ModelBuilders.CallSlipModelBuilder.PrepareJobsForModel(paged, model.SearchType, userJobRecoreds);
            //var data = listModel.ToDataSourceResult(request);
            GridModel gm = new GridModel();
            gm.listCallslips = listModel;
            gm.Total = jobs.Count();
            return gm;
        }



        public DailyJobStatusModel JobStatusReport(bool InState, bool OutOfState, bool Citibank, bool Aiss, bool Project)
        {
            DateTime todayDate = DateTime.Today.AddDays(1).AddTicks(-1);
            //DateTime fromDate = DateTime.Now.AddMonths(-1);
            //fromDate = Convert.ToDateTime(fromDate.ToShortDateString());
            var listModel = new List<DailyJobStatusModel>();
            var tryModel = new DailyJobStatusModel();
            var sequence = new[]
            {
                    "-3-HotCub", "00-Not Assigned", "4-Assigned", "4.5-Tech Dispatched Info", "5-Going", "-1-Return",
                    "-1.5- Parts On Order", "-2-CUB",
                    "5.1-Follow up", "5.2-Follow up with Tech only", "5.3-Follow up with Store only"
                };
            List<JobStatus> statusList =
                _unitOfWork.GenericRepository<JobStatus>().GetAsQuerable()
                    .Where(
                        t =>
                            t.Code == -3 || t.Code == 0 || t.Code == 4 || t.Code == 4.5 || t.Code == 5 || t.Code == -1 ||
                            t.Code == -1.5 || t.Code == -2 || t.Code == 5.1 ||
                            t.Code == 5.2 || t.Code == 5.3)
                    .ToList();

            int totalStatus = statusList.Count();
            foreach (JobStatus status in statusList.OrderBy(x => Array.IndexOf(sequence, x.Name)))
            {
                var models = new DailyJobStatusModel();
                IQueryable<Job> jobs =
                    _unitOfWork.GenericRepository<Job>().GetAsQuerable()
                        //.Where(t => t.JobStatusId == status.Id && t.OnDate >= fromDate && t.JobType.Id != 7 && t.JobType.Id != 8 && t.CustomerId != 1572)
                        //.Where(
                        //    t =>
                        //        t.OnDate <= todayDate && t.JobStatusId == status.Id && !t.Customer.FirstName.Contains("WalMart"));
                        .Where(
                            t =>
                                t.OnDate <= todayDate && t.JobStatusId == status.Id);
                if (InState == false)
                {
                    jobs = jobs.Where(t => t.JobTypeId != 3);
                }
                if (OutOfState == false)
                {
                    jobs = jobs.Where(t => t.JobTypeId != 4);
                }
                if (Citibank == false)
                {
                    jobs = jobs.Where(t => t.JobTypeId != 7);
                }
                if (Aiss == false)
                {
                    jobs = jobs.Where(t => t.JobTypeId != 8);
                }
                if (Project == false)
                {
                    jobs = jobs.Where(t => t.JobTypeId != 9);
                }
                models.Id = status.Id;
                models.StatusCode = status.Code;
                models.TotalJobs = jobs.Count();
                models.Status = status.Name;
                models.Colour = status.BackgroundColorHex;
                models.FontColor = status.FontColorHex;
                listModel.Add(models);
            }
            tryModel.TotalStatus = totalStatus;
            tryModel.ReportGenerated = true;
            tryModel.DailyJobStatusList = listModel;
            return tryModel;
        }

        public CallSlipModel GetJobDetailsById(long JobId, string PreviousJobId)
        {
            List<Job> callslip = _unitOfWork.GenericRepository<Job>().GetAsQuerable(x => x.Id == JobId).ToList();
            if (callslip.Count() < 1)
            {
                //return Json(new { success = false, message = "Job not found." });
            }
            string dateday = "";
            string ftString = "";
            string ttString = "";
            double lat = 0;
            double lng = 0;
            bool StoreChange = false;
            var model = new CallSlipModel();
            model.CanAccessInvoices = true;
            //var token = _unitOfWork.OAuthTokenRepository.Get().LastOrDefault();

            foreach (var detail in callslip)
            {
                var customer = _unitOfWork.GenericRepository<Customer>().GetSingle(x => x.Id == detail.CustomerId);
                model.Id = detail.Id;
                model.CustomerId = detail.CustomerId;
                var WebAddress = _unitOfWork.GenericRepository<WebAddressManager>().GetAsQuerable(t => t.CustomerId == detail.CustomerId).FirstOrDefault();
                if (WebAddress != null)
                {
                    model.CustomerWebAddress = true;
                }
                //model.HasUrgentNote = detail.Customer.HasUrgentNote;
                model.UrgentNoteDetails = customer != null ? (customer.HasUrgentNote ? (!String.IsNullOrEmpty(customer.UrgentNoteDetails) ? customer.UrgentNoteDetails
                    : "") : "") : "";
                model.StoreUrgentNoteDetails = detail.Store != null ? (detail.Store.HasUrgentNotes ? (!String.IsNullOrEmpty(detail.Store.UrgentNoteDetails) ? detail.Store.UrgentNoteDetails
                    : "") : "") : "";

                model.CustomerTripCharges = customer.TripCharges.HasValue ? customer.TripCharges.Value : 0;
                model.CustomerHourlyLabour = customer.HourlyLabour.HasValue ? customer.HourlyLabour.Value : 0;
                model.AutoUpdateCustomer = customer.AutoUpdates ? "Enabled" : "Disabled";
                model.HasAISSAssigned = detail.JobContractorMapping.Any(e => !String.IsNullOrEmpty(e.Contractor.BusinessName) && e.Contractor.BusinessName.ToLower().Contains("aiss"));
                model.CanEditEmergencyCheckbox = true;
                model.CustomerTypeId = customer.CustomerType;
                model.CustomerType = Enum.GetName(typeof(CustomerType), detail.IsAuto ? 3 : customer.CustomerType);
                model.JobTypeId = detail.JobTypeId;
                model.DispatchBoardType = _unitOfWork.GenericRepository<JobType>().GetSingle(x => x.Id == model.JobTypeId).Type;
                model.PaymentMethodId = detail.PaymentMethodId;
                model.AddressTypeId = detail.AddressTypeId;
                model.StoreId = detail.StoreId.HasValue && detail.StoreId.Value != null ? detail.StoreId : 0;
                model.AdTypeWebSource = detail.AdTypeWebSource;
                model.AdTypeId = detail.AdTypeId;
                model.AdType = _unitOfWork.GenericRepository<AdType>().GetSingle(x => x.Id == model.AdTypeId).Name;
                model.AdTypeOtherOption = detail.AdTypeOtherOption;
                model.TaxExempt = detail.TaxExempt;
                model.EquipmentId = detail.EquipmentId;
                model.EquipmentName = _unitOfWork.GenericRepository<Equipment>().GetSingle(x => x.Id == model.EquipmentId).Name;
                model.JobStatusId = detail.JobStatusId;
                var jobStatus = _unitOfWork.GenericRepository<JobStatus>().GetSingle(x => x.Id == model.JobStatusId);
                model.JobStatus = jobStatus.Name;
                string lastStatusChangedBy = "";
                var jobLogs = detail.JobLog.AsQueryable().Where(x => x.PrevStatus != x.NewStatus);
                var latestLog = jobLogs.OrderByDescending(t => t.TimeStamp).FirstOrDefault();
                if (latestLog != null)
                {
                    lastStatusChangedBy = latestLog.User.Username;
                }

                model.CurrentStatus = detail.JobStatusId != null
                    ? detail.JobStatus.Name : "N/A";
                if (model.CurrentStatus != null)
                {
                    model.ChangedBy = "[" + lastStatusChangedBy + "]";
                }
                model.StateId = detail.StateId;
                model.State = _unitOfWork.GenericRepository<State>().GetSingle(x => x.Id == model.StateId).Name;
                model.CountyId = detail.CountyId;
                model.CountryId = detail.CountryId;
                model.Country = _unitOfWork.GenericRepository<Country>().GetSingle(x => x.Id == model.CountryId).Name;
                model.CustomerName = ((!String.IsNullOrEmpty(customer.FirstName) ? customer.FirstName : "") + " " + (!String.IsNullOrEmpty(customer.LastName) ? customer.LastName : "")).Trim();
                model.CustomerNTEAmount = customer.NteAmount.ToString();
                model.CustomerNotes = customer.Notes;
                var customerAddress = customer.Address.FirstOrDefault();
                model.CustomerAddressId = customerAddress != null ? customerAddress.Id : 0;
                model.ZipCode = detail.ZipCode;
                model.IsAuto = detail.IsAuto;
                model.PONumber = detail.Ponumber;
                model.Phone = detail.Phone != null ? detail.Phone.TrimEnd('_').TrimEnd('-') : "";
                model.AlternatePhone = detail.AlternatePhone != null ? detail.AlternatePhone.TrimEnd('_').TrimEnd('-') : "";
                model.Locked = detail.Locked;
                model.Address = detail.Address;
                model.City = detail.City;
                model.Street = detail.Street != null ? detail.Street : "";
                model.ApartmentSuite = detail.ApartmentSuite;
                model.BuzzerCode = detail.BuzzerCode;
                model.Fax = detail.Fax;
                model.WorkOrder2 = detail.WorkOrder2;
                model.EmailAddress = detail.EmailAddress;
                model.CalledInBy = detail.CalledInBy;
                model.NTEAmount = detail.Nteamount != null ? Math.Round((double)detail.Nteamount, 2).ToString() : "";
                model.ContactPerson = detail.ContactPerson;
                model.DateIntervalType = detail.DateIntervalType.ToString();
                if (detail.FromTime != null)
                {
                    TimeSpan? ts = detail.FromTime;
                    model.FromTime = string.Format("{0:00}:{1:00}", ts.Value.Hours, ts.Value.Minutes);
                }
                else
                {
                    model.FromTime = "";
                }

                if (detail.ToTime != null)
                {
                    TimeSpan? ts = detail.ToTime;
                    model.ToTime = string.Format("{0:00}:{1:00}", ts.Value.Hours, ts.Value.Minutes);
                }
                else
                {
                    model.ToTime = "";
                }
                //if (detail.AlarmTime != null)
                //{
                //    TimeSpan? ts = detail.AlarmTime;
                //    model.alarmTime = string.Format("{0:00}:{1:00}", ts.Value.Hours, ts.Value.Minutes);
                //}
                //else
                //{
                //    model.alarmTime = "";
                //}

                //model.ToTime = detail.ToTime.HasValue ? detail.ToTime.Value.ToString() : "";
                var alarm = _unitOfWork.GenericRepository<JobAlarms>().GetSingle(x => x.JobId == detail.Id && x.Pending == false);
                if (alarm != null)
                {
                    model.alarmTime = alarm.AlarmTime.ToString();
                    model.pending = alarm.Pending.Value;
                }
                else
                {
                    model.pending = true;
                }
                model.OnDate = detail.OnDate.HasValue ? detail.OnDate.Value.ToString("MM/dd/yy") : "";
                model.IsCOW = detail.IsCow ?? false;
                model.Year = detail.Year;
                model.Make = detail.Make;
                model.Model = detail.Model;
                model.Color = detail.Color;
                model.Notes = detail.Notes;
                model.JobDescription = detail.Description;
                model.SpecialInstructions = !String.IsNullOrEmpty(detail.SpecialInstructions) ? detail.SpecialInstructions : "N/A";
                model.IsEmergency = Convert.ToBoolean(detail.IsEmergency);
                model.Ask = detail.Ask;
                model.CreatedOn = detail.CreatedOn.ToString("MM/dd/yy  hh:mm tt");
                model.EstimateEmailed = detail.EstimateEmailed;
                model.BackgroundColor = jobStatus.BackgroundColorHex ?? "";
                model.FontColor = jobStatus.FontColorHex ?? "";
                model.EstimatePrinted = detail.EstimatePrinted;
                model.IVRNumber = customer.Ivrnumber;
                model.IVRPin = customer.Ivrpin;
                model.TimeDispatched = detail.DispatchedTime != null
                    ? detail.DispatchedTime.Value.ToString("MM/dd/yy  hh:mm tt")
                : "";
                Store store = _unitOfWork.GenericRepository<Store>().GetSingle(x => x.Id == detail.StoreId); //detail.Store;

                model.StoreNotes = store != null ? detail.Store.Notes : "";
                model.StoreNumber = store != null && store.StoreNumber != null ? detail.Store.StoreNumber : "";
                model.StoreLocationName = store != null && store.LocationName != null ? detail.Store.LocationName : "";
                model.HistoricalData = store != null ? detail.Store.HistoricalData : "";
                model.PreferredMethodOfCummunication = Convert.ToBoolean(detail.PreferredCommunicationMethodEmail);
                model.IsFirstLine = "false";// IsFirstLineSystem.ToString().ToLower();

                model.CurrentUserName = "US1000";//ALSContext.Current.User.Username;

                if (!string.IsNullOrEmpty(customer.WrapupNotes))
                {
                    model.CustomerWrapupNotes = Regex.Replace(customer.WrapupNotes, @"\r\n?|\n", "<br/>");
                }

                AdType ad = _unitOfWork.GenericRepository<AdType>().GetSingle(x => x.Id == detail.AdTypeId);
                if (ad.Name == "Internet")
                {
                    model.AdName = ad.Name + " [" + model.AdTypeWebSource + "]";
                }
                else
                {
                    model.AdName = ad != null ? ad.Name : "";
                }

                User bookedBy = _unitOfWork.GenericRepository<User>().GetSingle(x => x.Id == detail.BookedByUserId);
                model.BookedByUserName = bookedBy != null ? bookedBy.Username : "";

                TimeSpan ft = TimeSpan.Parse(model.FromTime);
                TimeSpan tt = TimeSpan.Parse(!String.IsNullOrEmpty(model.ToTime) ? model.ToTime : "00:00");
                DateTime ftTemp = DateTime.ParseExact(ft.ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);
                DateTime ttTemp = DateTime.ParseExact(tt.ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);
                ftString = ftTemp.ToString("hh:mm tt");
                ttString = ttTemp.ToString("hh:mm tt");
                var hasInvoice = detail.Invoice.Any();
                model.InvoiceExist = hasInvoice ? detail.Invoice.Any(x => x.InvoiceDetails.Any()) : false;
                if (model.InvoiceExist)
                {
                    var isApproved = detail.Invoice.AsQueryable().Select(x => x.IsApproved).FirstOrDefault();
                    model.IsApproved = isApproved.HasValue ? isApproved.Value : false;
                }
                else
                {
                    model.IsApproved = false;
                }

                if (detail.Latitude != null && detail.Longtitude != null)
                {
                    lat = Convert.ToDouble(detail.Latitude);
                    lng = Convert.ToDouble(detail.Longtitude);
                }
                else
                {
                    string stateName = "";
                    string countryName = "";
                    ZipCodeData zip = _unitOfWork.GenericRepository<ZipCodeData>().GetSingle(x => x.ZipCode == detail.ZipCode);
                    if (zip != null)
                    {
                        stateName = zip.State.Name;
                        Country country = _unitOfWork.GenericRepository<Country>().GetSingle(x => x.Id == zip.CountryId);
                        if (country != null)
                            countryName = country.Name;
                    }

                    //Get Lat Long for the Job
                    //var address = detail.Address + ", " + detail.City + ", " + stateName + ", " + detail.ZipCode;
                    //GeoResponse response =
                    //    GeoCodeHelper.CallWsCount(address, detail.ZipCode, countryName, 5);

                    //if (response != null && response.Results.Any() && response.Results[0].Geometry != null &&
                    //    response.Results[0].Geometry.Location != null)
                    //{
                    //    detail.Latitude = (decimal)response.Results[0].Geometry.Location.Lat;
                    //    detail.Longtitude = (decimal)response.Results[0].Geometry.Location.Lng;

                    //    _unitOfWork.JobRepository.Update(detail);

                    //    lat = (double)detail.Latitude;
                    //    lng = (double)detail.Longtitude;
                    //}
                }
                model.estimateCreated = detail.JobPart.Any() ? detail.JobPart.DistinctBy(x => x.EstimateNumber).Max(x=>x.EstimateNumber).ToString() : "";
                model.InvoiceCreated = detail.Invoice.Any() ? "fa fa-check" : "";
                model.PaymentCreated = detail.JobPayment.Any() ? detail.JobPayment.Count().ToString() : "";
                model.CommunicationCreated = detail.Smslog.Any() ? detail.Smslog.Count.ToString() : "";
                model.PurchaseOrderCreated = detail.PurchaseOrder.Any() ? detail.PurchaseOrder.Count.ToString() : "";
                dateday = detail.OnDate.Value.ToString("D");
            }
            _unitOfWork.Save();

            // Lock the Job Via Adding it into the Cache and then removing it if there is any entry in prevCallSlipId or after 15 Minutes
            bool isLocked = false;
            var logs = "";
            return model;
            //if (!string.IsNullOrEmpty(PreviousJobId))
            //{
            //    if (CacheHelper.Get<string>(PreviousJobId) == ALSContext.Current.User.Username)
            //    {
            //        CacheHelper.Remove(PreviousJobId);
            //    }
            //}

            //string lockedUserName = "";
            //string currentloggedinuser = ALSContext.Current.User.Username;

            //if (CacheHelper.Exists(CallSlipId))
            //{
            //    lockedUserName = CacheHelper.GetValueByKey<string>(CallSlipId);

            //    if (lockedUserName != currentloggedinuser)
            //    {
            //        isLocked = true;
            //    }
            //}
            //else
            //{
            //    CacheHelper.Add(currentloggedinuser, CallSlipId);
            //}


            //lockedUserName = isLocked ? lockedUserName : "";

            //foreach (var c in HttpRuntime.Cache)
            //{
            //    logs += ((DictionaryEntry)c).Key.ToString() + " == " + ((DictionaryEntry)c).Value.ToString() + "\n";
            //}

            //logs += "locked user is = " + CacheHelper.GetValueByKey<string>(CallSlipId);
            //LogUserJobRecord(id);
        }

        public List<string> NumberOfJobsByStatus()
        {
            List<string> jobStatuses = _context.SP_GetJobCounts.FromSql("EXECUTE dbo.SP_GetJobsCount 0").Select(x => x.Name + ", " + x.JobCount + "," + x.Id + "," + x.BackgroundColorHex + "," + x.FontColorHex +
              "," + x.Code).ToList();

            return jobStatuses;
        }

        public dropdownLists PrepareDropDowns()
        {
            dropdownLists dl = new dropdownLists();

            dl.States = _unitOfWork.GenericRepository<State>().Get();
            dl.Countries = _unitOfWork.GenericRepository<Country>().Get(x => x.Published);
            dl.Counties = _unitOfWork.GenericRepository<County>().Get();
            dl.Equipments = _unitOfWork.GenericRepository<Equipment>().Get();
            dl.PaymentMethods = _unitOfWork.GenericRepository<PaymentMethod>().Get();
            dl.AdTypes = _unitOfWork.GenericRepository<AdType>().Get(x => x.Type == (int)AdTypess.AdType);
            dl.JobTypes = _unitOfWork.GenericRepository<JobType>().Get();
            dl.JobStatuses = _unitOfWork.GenericRepository<JobStatus>().Get(x => x.Published.Value, c => c.OrderBy(i => i.DisplayOrder));
            //dl.Contractors = _unitOfWork.GenericRepository<Contractor>().Get().Select(c => new SelectListItem
            //{
            //    Text = string.Format("{0} {1}", c.FirstName, c.LastName),
            //    Value = c.Id.ToString()
            //}).ToList();
            //ViewBag.CurrentUserBoardType = ALSContext.Current.User.CurrentBoardType;

            var st = new SelectListItem { Value = "0", Text = "Select Discrepancy" };
            var disclist = _unitOfWork.GenericRepository<DiscrepanciesList>().Get().OrderBy(t => t.Id).Select(x => new SelectListItem
            {
                Text = x.Name,
                Value = x.Id.ToString()
            }).ToList();
            disclist.Insert(0, st);
            dl.DicrepencyList = disclist;
            return dl;
        }

        public TechContractorList GetContractorsByJobId(string JobId)
        {
            int jobId = Convert.ToInt32(JobId);
            TechContractorList ListTechContractor = new TechContractorList();
            List<JobContractorMappingModel> listContractors = new List<JobContractorMappingModel>();
            var param = new SqlParameter("@JobId", JobId);
            //List<JobContractorMapping> jcm = _unitOfWork.JobContractorMapping.GetAsQuerable(x => x.JobId == jobId).DistinctBy(x => x.ContractorId).ToList();
            var jcm = _context.SP_GetContractorsByJobID.FromSql("EXECUTE dbo.SP_GetContractorByJobID @JobId", param).DistinctBy(x => x.ContractorId).ToList(); //_unitOfWork.SP_GetContractorByJobID.context.SP_GetContractorByJobID(jobId).DistinctBy(x => x.ContractorId).ToList();
            var techsummary = _unitOfWork.GenericRepository<TechSumary>().Get(x => x.JobId == jobId);
            var users = _unitOfWork.GenericRepository<User>().GetAsQuerable(x => x.Deleted == false);
            var TechniciansList = new List<TechniciansModelSP>();
            if (jcm.Count > 0)
            {
                foreach (var item in jcm)
                {
                    var newItem = new JobContractorMappingModel();
                    newItem.Id = item.Id;
                    newItem.JobId = jobId;
                    newItem.ContractorName = item.ContractorName;
                    newItem.BusinessName = item.BusinessName;
                    newItem.Phone = !String.IsNullOrEmpty(item.MainCompanyPhone) ? item.MainCompanyPhone.TrimEnd('_').TrimEnd('-') : "";
                    newItem.ContractorId = item.ContractorId;
                    newItem.Commission = item.Commission;
                    newItem.NTEAmount = item.NTEAMOUNT;
                    newItem.OriginalNTEAmount = item.InitialNteAmount;
                    newItem.IsPrimary = item.isPrimary;
                    //newItem.ContractorRatings = CalculateContractorRating(item.ContractorId);
                    newItem.ContractorRatings = Convert.ToDouble(item.ContractorRating);
                    newItem.TotalContractorRatings = item.TotalContractorRating.HasValue ? Convert.ToInt64(item.TotalContractorRating.Value) : 0;
                    newItem.hasSubContractors = item.HasTechnicians > 0;
                    if (item.Techsummary > 0)
                    {
                        newItem.hasTechSumary = true;
                    }


                    //var query = _unitOfWork.ContractorRepository.GetAsQuerable(t => t.Id == item.ContractorId).Select(t => t.IsFifityFifty).FirstOrDefault();
                    newItem.IsFiftyFifty = item.isFifityFifty.HasValue ? item.isFifityFifty.Value : false;

                    newItem.RecentNotes = "";
                    //var Id = newItem.ContractorId;

                    newItem.RecentNotes += item.RecentNote;

                    if (item.ReceiptExists > 0)
                    {
                        newItem.ReceiptExist = true;
                    }
                    else
                    {
                        newItem.ReceiptExist = false;
                    }

                    listContractors.Add(newItem);
                }

                var job = _unitOfWork.GenericRepository<Job>().GetSingle(x => x.Id == jobId);
                var technicians = job.JobContractorMapping.Where(x => x.JobId == jobId && x.SubContractorId.HasValue).DistinctBy(x => x.SubContractorId).Select(x => x.SubContractorId).ToList();

                if (technicians.Count > 0 && technicians[0] != null)
                {
                    //newItem.TechniciansList = new List<TechniciansModel>();

                    foreach (var techId in technicians)
                    {
                        TechniciansModelSP Techmodel = new TechniciansModelSP();
                        if (techId != null)
                        {
                            var Tech = _unitOfWork.GenericRepository<Technicians>().GetAsQuerable(t => t.Id == techId).FirstOrDefault();
                            var Contractor = _unitOfWork.GenericRepository<Contractor>().GetAsQuerable(t => t.Id == Tech.ContractorId).FirstOrDefault();
                            Techmodel.AssignContractor = Contractor.BusinessName;
                            Techmodel.BussinessName = Tech.BusinessName;
                            Techmodel.ContractorId = Tech.ContractorId;
                            Techmodel.FirstName = Tech.FirstName;
                            Techmodel.LastName = Tech.LastName;
                            Techmodel.Id = Tech.Id;
                            Techmodel.MainEmailAddress = Tech.MainEmailAddress;
                            Techmodel.MainTechnicianPhone = Tech.MainPhone != null ? Tech.MainPhone.Replace("_", "") : "";
                            TechniciansList.Add(Techmodel);
                        }
                    }
                }

            }
            ListTechContractor.ContractorList = listContractors;
            ListTechContractor.TechList = TechniciansList;
            return ListTechContractor;
        }

        public TablesList GetTablesDataByJobId(TableDataModel param)
        {

            var jobId = Convert.ToInt64(param.CallSlipId);
            #region JobLocationHistory
            var LocationListModel = new List<CallSlipModel>();
            // query to get the date of selected job to set the warranty banner.
            var currentJob = _unitOfWork.GenericRepository<Job>().GetAsQuerable(t => t.Id == jobId).FirstOrDefault();
            var selectedjobDate = currentJob.CreatedOn;

            IQueryable<Job> jobs;

            // if user is set to view all jobs
            //if (ALSContext.Current.User.CurrentBoardType == 1)
            //{
            jobs = _unitOfWork.GenericRepository<Job>().GetAsQuerable(null, o => o.OrderByDescending(x => x.CreatedOn), "", false);
            //}
            //else
            //{
            //    jobs = _unitOfWork.JobRepository.GetAsQuerable(x => (x.JobTypeId == ALSContext.Current.User.CurrentBoardType),
            //       o => o.OrderByDescending(x => x.CreatedOn), "", false);
            //}
            //If not residential, match store id only
            var customer = _unitOfWork.GenericRepository<Customer>().GetSingle(x => x.Id == currentJob.CustomerId);
            if (customer.CustomerType != 2)
            {
                // filter by store number
                if (!String.IsNullOrEmpty(param.storeNo))
                {
                    List<long> store = _unitOfWork.GenericRepository<Store>().Get(x => x.Id == currentJob.StoreId).Select(x => x.Id).ToList();
                    if (store.Any())
                    {
                        //jobs = jobs.Where(x => store.Contains((long)x.StoreId) && x.CreatedOn < selectedjobDate);
                        jobs = jobs.Where(x => store.Contains((long)x.StoreId));
                    }
                }
                else
                {
                    // filter by job address
                    if (!String.IsNullOrEmpty(param.address)) //&& !string.IsNullOrEmpty(customerName))
                    {
                        var specialCharacters = "[.|,]";
                        var address1 = Regex.Replace(param.address, specialCharacters, "");
                        //jobs = jobs.Where(j => j.Address.Contains(address));
                        //jobs = jobs.Where(j => j.Address.Replace(",", "").Replace(".", "").Contains(address1) && j.CustomerId == currentJob.CustomerId);
                        jobs = jobs.Where(j => j.Address.Replace(",", "").Replace(".", "").Replace(" ", "").ToLower().Contains(address1.Replace(" ", "")) && j.CustomerId == currentJob.CustomerId);
                    }
                }
            }
            //if residential, match address
            else
            {
                // filter by job address
                if (!String.IsNullOrEmpty(param.address)) //&& !string.IsNullOrEmpty(customerName))
                {
                    var specialCharacters = "[.|,]";
                    var address1 = Regex.Replace(param.address, specialCharacters, "");
                    //jobs = jobs.Where(j => j.Address.Contains(address));
                    //jobs = jobs.Where(j => j.Address.Replace(",", "").Replace(".", "").Contains(address1) && j.CustomerId == currentJob.CustomerId);
                    jobs = jobs.Where(j => j.Address.Replace(",", "").Replace(".", "").Replace(" ", "").ToLower().Contains(address1.Replace(" ", "")) && j.CustomerId == currentJob.CustomerId);
                }
            }

            List<Job> jobsList = jobs.ToList();

            foreach (Job job in jobsList)
            {
                if (jobId != job.Id)
                {
                    var item = new CallSlipModel();
                    var dateDifferent = selectedjobDate.AddDays(-90);
                    if (job.CreatedOn >= dateDifferent)
                    {
                        item.IsWarrantyBanner = true;
                    }
                    item.CustomerName = ((!String.IsNullOrEmpty(job.Customer.FirstName) ? job.Customer.FirstName : "") + " " + (!String.IsNullOrEmpty(job.Customer.LastName) ? job.Customer.LastName : "")).Trim();
                    item.Id = job.Id;
                    item.JobStatus = job.JobStatus != null ? job.JobStatus.Name : "";
                    item.JobStatusCode = job.JobStatus != null ? job.JobStatus.Code : (double?)null;
                    item.JobStatusId = job.JobStatusId;
                    item.StoreLocationName = job.Store != null ? job.Store.StoreNumber + " - " + job.Store.LocationName : "";
                    item.CustomerType = Enum.GetName(typeof(CustomerType), job.IsAuto ? 3 : job.Customer.CustomerType);
                    item.BackgroundColor = job.JobStatus != null ? job.JobStatus.BackgroundColorHex : "";
                    item.FontColor = job.JobStatus != null ? job.JobStatus.FontColorHex : "";
                    item.City = job.City;
                    item.Phone = job.Phone != null ? job.Phone.TrimEnd('_').TrimEnd('-') : "";
                    item.ZipCode = job.ZipCode;
                    item.State = job.State != null ? job.State.Abbreviation : "";
                    item.ReceiptTotal = 0;
                    if (job.OnDate.HasValue && job.FromTime.HasValue && job.State.TimeZone != null)
                    {
                        DateTime expectedTime = job.OnDate.Value.Add(job.FromTime.Value);
                        //item.ExpectedDateTime = expectedTime.ToString("g");
                        item.ExpectedDateTime = expectedTime.Date.ToString("ddd, M/d/yy h:mmt", new DateTimeFormatInfo { AMDesignator = "a", PMDesignator = "p" });
                    }

                    item.JobDescription = Regex.Replace(job.Description.Replace("\n", "<br>"), "<.*?>", String.Empty);
                    item.JobDescription = item.JobDescription.Replace("&nbsp;", " ");
                    JobContractorMapping pContractor = job.JobContractorMapping.FirstOrDefault(x => x.IsPrimary);
                    if (pContractor != null)
                    {
                        item.PrimaryContractor = !String.IsNullOrEmpty(pContractor.Contractor.FirstName) ? pContractor.Contractor.FirstName + " " + pContractor.Contractor.LastName : pContractor.Contractor.BusinessName;
                        if (pContractor.Job.Receipt.Any())
                        {
                            item.ReceiptTotal = pContractor.Job.Receipt.Where(t => t.ContractorId == pContractor.ContractorId && t.CalculatedTotal != null).Sum(t => Convert.ToDecimal(t.CalculatedTotal));
                        }
                    }

                    if (string.IsNullOrEmpty(item.StoreLocationName))
                        item.StoreLocationName = item.CustomerName;

                    LocationListModel.Add(item);
                }
            }
            #endregion

            #region EmailLogsByCustomerId

            var customerId = Convert.ToInt32(param.CustomerId);
            var emailLog = _unitOfWork.GenericRepository<EmailLog>().GetAsQuerable(t => t.CustomerId == customerId && t.JobId == jobId && t.Type.Contains("Update Customer") && !String.IsNullOrEmpty(t.LogMessage)).OrderByDescending(e => e.MailedOn).ToList();
            //var emailLog = _unitOfWork.EmailLogRepository.GetAsQuerable(t => t.CustomerID == customerId && t.JobID == jobId && t.Subject.ToLower().Contains("notification from")).ToList();

            List<EmailLogModel> EmailListModel = new List<EmailLogModel>();
            if (emailLog.Any())
            {
                EmailListModel.AddRange(emailLog.Select(t => new EmailLogModel
                {
                    Id = t.LogId,
                    subject = t.Subject,
                    Sender = t.MailedFromNavigation.Username ?? "",
                    MailedOn = t.MailedOn.ToString("ddd, M/d/yy h:mt", new DateTimeFormatInfo { AMDesignator = "a", PMDesignator = "p" }),
                    LogMessage = !String.IsNullOrEmpty(t.LogMessage) ? t.LogMessage : ""
                }));
            }

            #endregion

            #region MessagesAndNotifications

            var listMessages = new List<SMSLogModel>();
            IQueryable<Smslog> jobMessages = _unitOfWork.GenericRepository<Smslog>().GetAsQuerable(x => x.JobId == jobId);
            var users = _unitOfWork.GenericRepository<User>().GetAsQuerable(x => x.Deleted == false);
            // get SMSLog
            //ICollection<SMSLog> messages = detail.SMSLogs;
            if (jobMessages.Count() > 0)
            {

                foreach (Smslog message in jobMessages)
                {
                    var smsModel = new SMSLogModel();
                    var user = users.Where(x => x.Id == message.CreatedByUserId).Select(y => y.Username).FirstOrDefault();//_unitOfWork.UserRepository.GetAsQuerable(x => x.Id == message.CreatedByUserId).Select(y => y.Username).FirstOrDefault();
                    if (message.Body.Contains('#'))
                    {
                        smsModel.Body = message.Body.Replace("#", string.Empty);
                        var substr = smsModel.Body;
                        //substr = substr.Substring(7, substr.Length - 7);
                        //smsModel.Body = substr;
                    }
                    else
                    {
                        smsModel.Body = message.Body;
                    }
                    smsModel.From = message.From;
                    smsModel.To = message.To;
                    smsModel.Sent = message.Sent;
                    smsModel.UserAlerted = message.UserAlerted;
                    smsModel.CreatedByUser = user != null ? user : "";
                    smsModel.CreatedByContractor = null;
                    smsModel.DateCreated = message.DateCreated.Value.ToString();
                    smsModel.DateCreatedDate = message.DateCreated.Value;
                    listMessages.Add(smsModel);
                }
            }

            IQueryable<MobileNotification> jobMobileNotifications = _unitOfWork.GenericRepository<MobileNotification>().GetAsQuerable(x => x.JobId == jobId);
            if (jobMobileNotifications.Count() > 0)
            {
                foreach (MobileNotification notification in jobMobileNotifications)
                {
                    var smsModel = new SMSLogModel();
                    var user = users.Where(x => x.Id == notification.CreatedByUserId).Select(y => y.Username).FirstOrDefault();
                    smsModel.Body = notification.Message;
                    smsModel.From = notification.FromDevice ? "iPhone" : "Web";
                    smsModel.To = !notification.FromDevice ? "iPhone" : "Web";
                    smsModel.Sent = true;
                    smsModel.UserAlerted = true;
                    smsModel.CreatedByUser = user != null ? user : "";
                    smsModel.CreatedByContractor = null;
                    smsModel.DateCreated = notification.CreatedOn.Value.ToString();
                    smsModel.DateCreatedDate = notification.CreatedOn.Value;
                    listMessages.Add(smsModel);
                }
            }

            var decrepeniesId = "";
            var jobDescrepencies = _unitOfWork.GenericRepository<Discrepancies>().GetSingle(x => x.JobId == jobId);
            if (jobDescrepencies != null)
            {
                decrepeniesId = jobDescrepencies.Type;
            }
            else
            {
                decrepeniesId = "0";
            }

            #endregion

            #region JobContractorHistory

            var ContractorsActiveListModel = new List<CallSlipModel>();
            IQueryable<Job> jobss;
            //Job pJob = _unitOfWork.JobRepository.GetByID(jobId);

            var currJob = _unitOfWork.GenericRepository<Job>().GetSingle(x => x.Id == jobId);
            if (currJob != null)
            {
                IEnumerable<long> contractors = currJob.JobContractorMapping.Select(t => t.ContractorId);
                //jobs = jobs.Where(j => j.JobContractorMappings.Any(i => contractors.Contains(i.ContractorId)));
                //if (ALSContext.Current.User.CurrentBoardType == 1)
                //{
                //jobs = context.Jobs.AsQueryable().Where(j => j.JobContractorMappings.Any(c => c.ContractorId == cId) && j.JobStatu.Code == 20).OrderByDescending(x => x.CreatedOn).Take(10);
                jobss = _unitOfWork.GenericRepository<JobContractorMapping>().GetAsQuerable().Where(j => contractors.Contains(j.ContractorId) &&
                    (j.Job.JobStatus.Code == 4 || j.Job.JobStatus.Code == 4.5 || j.Job.JobStatus.Code == 5 || j.Job.JobStatus.Code == 5.2))
                        .Select(e => e.Job).OrderByDescending(x => x.Id).Take(50);
                //}
                //else
                //{
                //jobs = context.JobContractorMappings.AsQueryable().Where(j => j.Job.JobTypeId == ALSContext.Current.User.CurrentBoardType && contractors.Contains(j.ContractorId) &&
                //(j.Job.JobStatu.Code == 4 || j.Job.JobStatu.Code == 4.5 || j.Job.JobStatu.Code == 5 || j.Job.JobStatu.Code == 5.2))
                //.Select(e => e.Job).OrderByDescending(x => x.Id).Take(50);
                //}

                foreach (var job in jobss)
                {
                    if (jobId != job.Id)
                    {
                        var item = new CallSlipModel();
                        item.CustomerName = ((!String.IsNullOrEmpty(job.Customer.FirstName) ? job.Customer.FirstName : "") + " " + (!String.IsNullOrEmpty(job.Customer.LastName) ? job.Customer.LastName : "")).Trim();
                        item.Id = job.Id;
                        item.JobStatus = job.JobStatus != null ? job.JobStatus.Name : "";
                        item.JobStatusCode = job.JobStatus != null ? job.JobStatus.Code : (double?)null;
                        item.JobStatusId = job.JobStatusId;
                        item.StoreLocationName = job.Store != null ? job.Store.StoreNumber + " - " + job.Store.LocationName : "";
                        item.CustomerType = Enum.GetName(typeof(CustomerType), job.IsAuto ? 3 : job.Customer.CustomerType);
                        item.BackgroundColor = job.JobStatus != null ? job.JobStatus.BackgroundColorHex : "";
                        item.FontColor = job.JobStatus != null ? job.JobStatus.FontColorHex : "";
                        item.City = job.City;
                        item.Phone = job.Phone != null ? job.Phone.TrimEnd('_').TrimEnd('-') : "";
                        item.ZipCode = job.ZipCode;
                        item.State = job.State != null ? job.State.Abbreviation : "";

                        if (job.OnDate.HasValue && job.FromTime.HasValue && job.State.TimeZone != null)
                        {
                            DateTime expectedTime = job.OnDate.Value.Add(job.FromTime.Value);
                            item.ExpectedDateTime = expectedTime.ToString("ddd, M/d/yy h:mmt", new DateTimeFormatInfo { AMDesignator = "a", PMDesignator = "p" });
                        }

                        item.JobDescription = job.Description;
                        JobContractorMapping pContractor = job.JobContractorMapping.FirstOrDefault(x => x.IsPrimary);
                        if (pContractor != null)
                        {
                            item.PrimaryContractor = pContractor.Contractor.FirstName + " " + pContractor.Contractor.LastName;
                        }

                        if (string.IsNullOrEmpty(item.StoreLocationName))
                            item.StoreLocationName = item.CustomerName;

                        ContractorsActiveListModel.Add(item);
                    }
                }
            }

            #endregion

            #region JobTechnicianHistory

            var TechnicianHistoryList = new List<CallSlipModel>();
            var currJobOnDate = _unitOfWork.GenericRepository<Job>().GetAsQuerable().Where(e => e.Id == jobId).Select(w => w.OnDate).FirstOrDefault();
            var technicianIds = _unitOfWork.GenericRepository<JobContractorMapping>().GetAsQuerable().Where(t => t.JobId == jobId && t.SubContractorId != null).Select(t => t.SubContractorId);
            //Job pJob = _unitOfWork.JobRepository.GetByID(jobId);
            if (currJobOnDate != null && technicianIds.Count() > 0)
            {
                //var contractors = pJob.JobContractorMappings.Select(t => t.SubContractorId).ToList();
                foreach (var technicianId in technicianIds)
                {
                    if (technicianId != null)
                    {
                        //var jobs =
                        //    _unitOfWork.JobContractorMapping.GetAsQuerable()
                        //        .Where(t => t.SubContractorId == technician && t.Job.OnDate == job.OnDate && t.JobId != job.Id)
                        //        .ToList();

                        var techjobs =
                          _unitOfWork.GenericRepository<JobContractorMapping>().GetAsQuerable()
                               .Where(t => t.SubContractorId == technicianId && t.Job.OnDate == currJobOnDate && t.JobId != jobId
                                && (t.Job.JobStatus.Code == 4.5 || t.Job.JobStatus.Code == 5)).OrderByDescending(x => x.Id).Take(10);

                        //foreach (var job in jobs.Where(t => t.Job.JobStatu.Code == 4.5 || t.Job.JobStatu.Code == 5))
                        foreach (var job in techjobs)
                        {
                            var item = new CallSlipModel();
                            item.Id = job.JobId;
                            item.StoreLocationName = job.Job.Store != null ? job.Job.Store.StoreNumber + " - " + job.Job.Store.LocationName : "";
                            item.City = job.Job.City;
                            item.ExpectedDate = Convert.ToDateTime(job.Job.OnDate).ToString();
                            item.JobDescription = job.Job.Description;
                            JobContractorMapping pContractor = job.Job.JobContractorMapping.FirstOrDefault(x => x.IsPrimary);
                            if (pContractor != null)
                            {
                                item.PrimaryContractor = pContractor.Contractor.FirstName + " " + pContractor.Contractor.LastName;
                            }
                            TechnicianHistoryList.Add(item);
                        }
                    }
                }
            }

            #endregion

            TablesList tl = new TablesList();
            tl.locationList = LocationListModel;
            tl.emailList = EmailListModel;
            tl.ContractorActiveList = ContractorsActiveListModel;
            tl.smsList = listMessages;
            tl.TechnicianActiveList = TechnicianHistoryList;
            return tl;
        }

        public NotesDocumentsModel GetNotesAndDocumentsByJobId(string callslipId)
        {
            int jobId = Convert.ToInt32(callslipId);

            #region Notes
            var notesModel = new List<JobNotesModel>();
            IQueryable<JobNotes> jobNotes = _unitOfWork.GenericRepository<JobNotes>().GetAsQuerable(x => x.JobId == jobId);
            //var linkedjob = _unitOfWork.GenericRepository<Job>().GetSingle(x => x.Id == jobId).LinkJobID;
            // get Notes
            var hastechSummary = false;
            var techSummary = _unitOfWork.GenericRepository<TechSumary>().GetAsQuerable(t => t.JobId == jobId && t.Types == "Tech Summary");
            if (techSummary.Count() > 0)
            {
                hastechSummary = true;
            }

            if (jobNotes.Count() > 0)
            {
                var booked = _unitOfWork.GenericRepository<Job>().GetSingle(x => x.Id == jobId);
                foreach (JobNotes item in jobNotes.OrderByDescending(x => x.CreatedOn))
                {
                    var notesmodel = new JobNotesModel();
                    //if (techSummary.Count() > 0)
                    //{
                    //    notesmodel.TechSummary = true;
                    //}
                    //else
                    //{
                    notesmodel.TechSummary = hastechSummary;
                    //}
                    notesmodel.Id = item.Id;
                    notesmodel.JobId = item.JobId;
                    notesmodel.RelatedToInvoice = item.RelatedToInvoice;
                    notesmodel.Notes = item.Notes;
                    notesmodel.CreatedBy = item.CreatedByNavigation != null ? item.CreatedByNavigation.Username : "";
                    //	notesmodel.CreatedOn = item.CreatedOn.Value.ToString("g");
                    notesmodel.CreatedOn = item.CreatedOn.Value.ToString("ddd, M/d/yy h:mmt", new DateTimeFormatInfo { AMDesignator = "a", PMDesignator = "p" });
                    notesmodel.BookedOn = item.CreatedOn.Value;

                    DateTime bookedDate = booked.CreatedOn;
                    System.TimeSpan diff = notesmodel.BookedOn.Value.Subtract(bookedDate);
                    notesmodel.Days = diff.Days;
                    notesmodel.Hours = diff.Hours;
                    notesmodel.Minutes = diff.Minutes;
                    notesmodel.Seconds = diff.Seconds;
                    //String diff2 = (bookedDate - notesmodel.BookedOn).TotalDays.ToString();
                    notesModel.Add(notesmodel);
                }
                //notesModel.Reverse(); // to sort Latest Added note on top.
            }
            #endregion

            #region Documents

            var listDocuments = new List<DocumentModel>();
            Job job = _unitOfWork.GenericRepository<Job>().GetSingle(x => x.Id == jobId);
            if (job.Document.Any())
            {
                foreach (Document item in job.Document.OrderBy(e => e.CreatedOn))
                {
                    //bool flag = false;
                    //if (item.Path.StartsWith("~"))
                    //{
                    //    flag = System.IO.File.Exists(Server.MapPath(item.Path));
                    //}
                    //else
                    //{
                    //    flag = true;
                    //}

                    //var fileExists = CheckFileExists(item.Path);
                    //if (fileExists)
                    //{
                    var document = new DocumentModel();
                    document.Id = item.Id;
                    document.Title = item.Name;
                    document.Path = item.Path;
                    document.Description = item.Descritption;
                    document.CreatedOn = item.CreatedOn.ToString("ddd, M/d/yy h:mt", new DateTimeFormatInfo { AMDesignator = "a", PMDesignator = "p" });
                    if (document.UserName == null)
                    {
                        var userID = _unitOfWork.GenericRepository<User>().GetAsQuerable(x => x.Id == item.CreatedByUserId).Select(y => y.Username).FirstOrDefault();
                        //if (String.IsNullOrEmpty(userID))
                        //{
                        //    userID = _unitOfWork.UserRepository.GetAsQuerable(x => x.Id == item.CreatedByUserId).Select(y => y.Username).FirstOrDefault();
                        //}
                        document.UserName = userID;
                    }

                    listDocuments.Add(document);
                    //}
                }
            }
            #endregion

            NotesDocumentsModel nd = new NotesDocumentsModel();
            nd.docsList = listDocuments;
            nd.notesList = notesModel;
            return nd;
        }

        public ProgressBarModel GetJobProgressBarDetails(string CallslipId)
        {
            int id = Convert.ToInt32(CallslipId);
            var detail = _unitOfWork.GenericRepository<Job>().GetAsQuerable(x => x.Id == id).FirstOrDefault();
            var jobStatusHistoryList = detail.JobLog.AsQueryable().Where(x => (x.NewStatus != null && x.PrevStatus != null) && x.PrevStatus != x.NewStatus);

            ProgressBarModel model = new ProgressBarModel();
            model.UpdateOnCreated = detail.UpdateOnCreated.HasValue ? detail.UpdateOnCreated.Value : false;
            model.UpdateOnAssigned = detail.UpdateOnAssigned.HasValue ? detail.UpdateOnAssigned.Value : false;
            model.UpdateOnDispatched = detail.UpdateOnDisptched.HasValue ? detail.UpdateOnDisptched.Value : false;
            model.UpdateOnDelayed = detail.UpdateOnDelayed.HasValue ? detail.UpdateOnDelayed.Value : false;
            model.UpdateOnCompleted = detail.UpdateOnCompleted.HasValue ? detail.UpdateOnCompleted.Value : false;
            //check if customer has been updated via Portal
            model.UpdatedOnAcceptedInPortal = detail.UpdatedOnAcceptedInPortal.HasValue ? detail.UpdatedOnAcceptedInPortal.Value : false;
            model.UpdatedOnAssignedInPortal = detail.UpdatedOnAssignedInPortal.HasValue ? detail.UpdatedOnAssignedInPortal.Value : false;
            model.UpdatedOnDispatchInPortal = detail.UpdatedOnDispatchInPortal.HasValue ? detail.UpdatedOnDispatchInPortal.Value : false;
            model.UpdatedOnDelayedInPortal = detail.UpdatedOnDelayedInPortal.HasValue ? detail.UpdatedOnDelayedInPortal.Value : false;
            model.UpdatedOnCompleteInPortal = detail.UpdatedOnCompleteInPortal.HasValue ? detail.UpdatedOnCompleteInPortal.Value : false;
            //check if customer has been updated via Email
            model.UpdatedOnAcceptedInEmail = detail.UpdatedOnAcceptedInEmail.HasValue ? detail.UpdatedOnAcceptedInEmail.Value : false;
            model.UpdatedOnAssignedInEmail = detail.UpdatedOnAssignedInEmail.HasValue ? detail.UpdatedOnAssignedInEmail.Value : false;
            model.UpdatedOnDispatchInEmail = detail.UpdatedOnDispatchInEmail.HasValue ? detail.UpdatedOnDispatchInEmail.Value : false;
            model.UpdatedOnDelayedInEmail = detail.UpdatedOnDelayedInEmail.HasValue ? detail.UpdatedOnDelayedInEmail.Value : false;
            model.UpdatedOnCompleteInEmail = detail.UpdatedOnCompleteInEmail.HasValue ? detail.UpdatedOnCompleteInEmail.Value : false;
            //check if customer requires updates
            model.RequireUpdates = detail.Customer.ManualUpdates ? true : false;
            //check if Portal or mail update
            var flag = false;
            var WebAddress = _unitOfWork.GenericRepository<WebAddressManager>().GetAsQuerable(t => t.CustomerId == detail.CustomerId).FirstOrDefault();
            if (WebAddress != null)
            {
                flag = true;
            }
            model.SendUpdateInCustomerEmail = detail.UpdateInCustomerEmail.HasValue ? detail.UpdateInCustomerEmail.Value : false;
            model.SendUpdateInCustomerPortal = detail.UpdateInCustomerPortal.HasValue ? detail.UpdateInCustomerPortal.Value : false;
            return model;
        }

        public List<JobStatusHistoryModel> JobStatusHistory(string CallslipId)
        {
            int id = Convert.ToInt32(CallslipId);
            var jobs = _unitOfWork.GenericRepository<Job>().GetSingle(x => x.Id == id).JobLog.Where(x => x.PrevStatus != x.NewStatus).OrderByDescending(t => t.TimeStamp).ToList();
            List<JobStatusHistoryModel> listModel = new List<JobStatusHistoryModel>();
            var users = _unitOfWork.GenericRepository<User>().GetAsQuerable(x => x.Deleted == false);
            var jobStatus = _unitOfWork.GenericRepository<JobStatus>().GetAsQuerable();

            foreach (var job in jobs)
            {
                JobStatusHistoryModel model = new JobStatusHistoryModel();
                var Updatedon = job.TimeStamp;
                model.TimeStamp = Updatedon;
                var byUser = job.UserId;
                User user = users.Where(x => x.Id == byUser).FirstOrDefault();//_unitOfWork.UserRepository.GetAsQuerable(x => x.Id == byUser).FirstOrDefault();
                model.UserName = user != null ? user.Username : "N/A";
                var prevStatus = job.PrevStatus;
                model.PrevStatus = prevStatus;
                JobStatus status = jobStatus.Where(x => x.Code == prevStatus).FirstOrDefault();//_unitOfWork.JobStatusRepository.GetAsQuerable(x => x.Code == prevStatus).FirstOrDefault();
                model.PreviousStatusName = status != null ? status.Name : "N/A";
                var newStatus = job.NewStatus;
                model.NewStatus = newStatus;
                JobStatus NewStatus = jobStatus.Where(x => x.Code == newStatus).FirstOrDefault();//_unitOfWork.JobStatusRepository.GetAsQuerable(x => x.Code == newStatus).FirstOrDefault();
                model.NewStatusColorHex = NewStatus.BackgroundColorHex;
                model.NewStatusName = NewStatus != null ? NewStatus.Name : "N/A";
                listModel.Add(model);

            }
            return listModel;
        }

        public PartJsonModel GetPartsByCallSlipId(string CallSlipId, long EstimateNumber)
        {

            int callSlipId = Convert.ToInt32(CallSlipId);
            Job job = _unitOfWork.GenericRepository<Job>().GetSingle(x => x.Id == callSlipId);

            //Task 1528
            var customers = _unitOfWork.GenericRepository<CustomerStateMapping>().Get(x => x.StateId == job.StateId).Select(x => x.CustomerId);
            var customerTaxState = _unitOfWork.GenericRepository<State>().GetAsQuerable(x => x.Id == job.StateId && customers.Contains(job.Customer.Id));
            var StateExempt = "";
            if (customerTaxState.Select(x => x.Name).Contains(job.State.Name))
            {
                StateExempt = job.State.Name;
            }
            var model = new List<JobPartModel>();
            SubTotalModel subTotal = null;
            List<JobPart> parts = _unitOfWork.GenericRepository<JobPart>().Get(x => x.JobId == job.Id && x.EstimateNumber == EstimateNumber);
            if (parts.Any())
            {
                foreach (JobPart jobPart in parts)
                {
                    var item = new JobPartModel();
                    item.Id = jobPart.Id;
                    item.EstimateLabel = jobPart.EstimateLabel;
                    item.Title = jobPart.Title;
                    item.Description = jobPart.Description;
                    //  var a = jobPart.CreatedOn.ToString("MM/dd/yy hh:mm:ss");
                    item.CreatedOn = jobPart.CreatedOn.ToString("MM/dd/yy hh:mm:ss");
                    var userId = jobPart.CreatedByUserId;
                    item.CreatedByUser = _unitOfWork.GenericRepository<User>().GetAsQuerable(t => t.Id == userId).Select(t => t.Username).FirstOrDefault();
                    item.UnitPrice = jobPart.UnitPrice;
                    item.Quantity = jobPart.Quantity;
                    item.Type = Enum.GetName(typeof(PartType), Convert.ToInt32(jobPart.Type));
                    // edited for inventory Profit and loss
                    item.LaborCost = jobPart.LaborCost != null ? jobPart.LaborCost : 0;
                    item.TripCost = jobPart.TripCost.HasValue ? jobPart.TripCost.Value : 0;
                    item.OtherCost = jobPart.OtherCost.HasValue ? jobPart.OtherCost.Value : 0;
                    //item.EstimateNumber = jobPart.EstimateNumber.Value;
                    var title = jobPart.Title;
                    prepareJobPartModel(title, item, jobPart, job);
                    model.Add(item);
                }

                model = model.OrderBy(x => x.Type == "ServiceCharge").ThenBy(x => x.Type == "Other").ThenBy(x => x.Type == "Labor").ThenBy(x => x.Type == "Parts").ToList();

                subTotal = new SubTotalModel();
                subTotal.PartsSubTotal = parts.Where(c => c.Type == 1).Sum(x => x.UnitPrice * x.Quantity).ToString();
                subTotal.LaborTotal = parts.Where(c => c.Type == 2).Sum(x => x.UnitPrice * x.Quantity).ToString();
                subTotal.ServiceCharge = parts.Where(c => c.Type == 4).Sum(x => x.UnitPrice * x.Quantity).ToString();
                subTotal.OtherCharges = parts.Where(c => c.Type == 3).Sum(x => x.UnitPrice * x.Quantity).ToString();
                //TaxRate taxRate = _unitOfWork.TaxRateRepository.GetSingle(x => x.ZipCode == job.ZipCode);
                TaxRate taxRate = new TaxRate();
                var taxList = _unitOfWork.GenericRepository<TaxRate>().GetAsQuerable(x => x.ZipCode == job.ZipCode).ToList();
                foreach (var tax in taxList)
                {
                    if (parts.FirstOrDefault().CreatedOn >= tax.CreatedOn)
                    {
                        taxRate = tax;
                    }
                }
                double totalTax = taxRate != null
                    ? ((taxRate.CityTax ?? 0) + (taxRate.CountyTax ?? 0) + (taxRate.StateTax ?? 0) + (taxRate.SpecialRate ?? 0))
                    : 0;

                decimal totalAmount = 0;
                if (job.State.TaxPartsOnly)
                {
                    //In acc with task #1104 in tasksheet
                    var setting = _unitOfWork.GenericRepository<Setting>().GetAsQuerable(t => t.Name.Equals("ServiceTaxForCADate")).FirstOrDefault();
                    if (setting != null && !String.IsNullOrEmpty(setting.Value))
                    {
                        var input = setting.Value;
                        DateTime dateTime = DateTime.ParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                        if (!String.IsNullOrEmpty(job.State.Abbreviation) && job.State.Abbreviation.ToLower().Equals("ca") && (!String.IsNullOrEmpty(subTotal.PartsSubTotal) && ((int)Convert.ToDouble(subTotal.PartsSubTotal) != 0))
                            && (!String.IsNullOrEmpty(subTotal.ServiceCharge) && ((int)Convert.ToDouble(subTotal.ServiceCharge) != 0)) && job.JobPart.FirstOrDefault().CreatedOn >= dateTime)
                        {
                            subTotal.PartsTax = subTotal.PartsTax ?? (job.Customer.TaxExempt || job.TaxExempt
                                         ? "0.00"
                                         : (totalTax * Convert.ToDouble(subTotal.PartsSubTotal)).ToString("N"));
                            totalAmount = Math.Round(
                                (Convert.ToDecimal(subTotal.PartsSubTotal) + Convert.ToDecimal(subTotal.OtherCharges) +
                                 Convert.ToDecimal(subTotal.LaborTotal) + Convert.ToDecimal(subTotal.ServiceCharge)), 3);
                            var totalLessTrip = totalAmount - Convert.ToDecimal(subTotal.ServiceCharge);
                            var serviceTax = (job.Customer.TaxExempt || job.TaxExempt)
                               ? 0
                               : totalTax * ((double)((Convert.ToDecimal(subTotal.PartsSubTotal) / totalLessTrip) * Convert.ToDecimal(subTotal.ServiceCharge)));
                            var partsTotalTax = Convert.ToDouble(subTotal.PartsTax) + serviceTax;
                            subTotal.PartsTax = partsTotalTax.ToString("N");
                            double partsTotal = Convert.ToDouble(subTotal.PartsSubTotal) + Convert.ToDouble(partsTotalTax);
                            subTotal.PartsTotal = partsTotal.ToString("N");
                            totalAmount = Math.Round(
                            (Convert.ToDecimal(subTotal.PartsTotal) + Convert.ToDecimal(subTotal.OtherCharges) +
                             Convert.ToDecimal(subTotal.LaborTotal) + Convert.ToDecimal(subTotal.ServiceCharge)), 3);
                            subTotal.SubTotal = (Convert.ToDouble(totalAmount) - Convert.ToDouble(partsTotalTax)).ToString("N");
                        }
                        else
                        {
                            subTotal.PartsTax = subTotal.PartsTax ?? (job.Customer.TaxExempt || job.TaxExempt
                                         ? "0.00"
                                         : (totalTax * Convert.ToDouble(subTotal.PartsSubTotal)).ToString("N"));
                            double partsTotal = Convert.ToDouble(subTotal.PartsSubTotal) + Convert.ToDouble(subTotal.PartsTax);
                            subTotal.PartsTotal = partsTotal.ToString("N");
                            totalAmount = Math.Round(
                                 (Convert.ToDecimal(subTotal.PartsTotal) + Convert.ToDecimal(subTotal.OtherCharges) +
                                  Convert.ToDecimal(subTotal.LaborTotal) + Convert.ToDecimal(subTotal.ServiceCharge)), 3);
                            subTotal.SubTotal = (Convert.ToDouble(totalAmount) - Convert.ToDouble(subTotal.PartsTax)).ToString("N");
                        }
                        subTotal.Total = (Convert.ToDouble(totalAmount)).ToString("N");
                    }
                    else
                    {
                        subTotal.PartsTotal = subTotal.PartsSubTotal;
                        totalAmount = Math.Round(
                            (Convert.ToDecimal(subTotal.PartsTotal) + Convert.ToDecimal(subTotal.OtherCharges) +
                             Convert.ToDecimal(subTotal.LaborTotal) + Convert.ToDecimal(subTotal.ServiceCharge)), 3);

                        subTotal.PartsTax = subTotal.PartsTax ?? (job.Customer.TaxExempt || job.TaxExempt
                                          ? "0.00"
                                          : (totalTax * Convert.ToDouble(subTotal.PartsSubTotal)).ToString("N"));
                        subTotal.SubTotal = totalAmount.ToString();
                        subTotal.Total = (Convert.ToDouble(subTotal.PartsTax) + Convert.ToDouble(totalAmount)).ToString();
                    }
                }
                else
                {
                    subTotal.PartsTotal = subTotal.PartsSubTotal;
                    totalAmount = Math.Round(
                        (Convert.ToDecimal(subTotal.PartsTotal) + Convert.ToDecimal(subTotal.OtherCharges) +
                         Convert.ToDecimal(subTotal.LaborTotal) + Convert.ToDecimal(subTotal.ServiceCharge)), 3);

                    subTotal.PartsTax = job.Customer.TaxExempt || job.TaxExempt
                        ? "0.00"
                        : Math.Round((totalTax * Convert.ToDouble(totalAmount)), 2).ToString("N");
                    subTotal.SubTotal = totalAmount.ToString();
                    subTotal.Total = (Convert.ToDouble(subTotal.PartsTax) + Convert.ToDouble(totalAmount)).ToString();
                }
            }
            PartJsonModel jsonModel = new PartJsonModel();
            jsonModel.StateExempt = StateExempt;
            jsonModel.subtotal = subTotal;
            jsonModel.jobPart = model;
            return jsonModel;
        }

        public void prepareJobPartModel(string title, JobPartModel item, JobPart jobPart, Job job)
        {
            try
            {
                if (title != null && item.Type == "Parts")
                {
                    var partOfJob = _unitOfWork.GenericRepository<Part>().GetAsQuerable(t => t.Name == title).FirstOrDefault();
                    if (partOfJob != null)
                    {
                        var purchasePrice = partOfJob.PurchasePrice;
                        var totalPrice = purchasePrice * jobPart.Quantity;
                        item.TotalPartCost = totalPrice;
                        item.PurchasePrice = purchasePrice;
                        item.APTA = partOfJob.Apta;
                        decimal margin = 0;
                        decimal discount = 0;
                        if (jobPart.Markup != null)
                        {
                            margin = Convert.ToDecimal(jobPart.Markup);
                        }
                        else
                        {
                            margin = Convert.ToDecimal(job.Customer.MarkupOnParts);
                        }
                        item.MarkupPercentage = margin;
                        var Markup = jobPart.Markup != null ? (jobPart.Markup / 100) * purchasePrice : 0;
                        if (jobPart.Discount != null)
                        {
                            discount = Convert.ToDecimal(jobPart.Discount);
                        }
                        else
                        {
                            discount = Convert.ToDecimal(job.Customer.DiscountOnParts);
                        }
                        item.DiscountPercentage = discount;
                        var aptaPrice = partOfJob.Apta != null ? partOfJob.Apta : 0;
                        //var totalApta =  aptaPrice * jobPart.Quantity;
                        var sellingPrice = aptaPrice / (1 - (margin / 100));

                        var marginAmount = ((margin / 100) * purchasePrice);
                        var totalMargin = Markup + purchasePrice;
                        var discountAmount = ((discount / 100) * totalMargin);

                        sellingPrice = sellingPrice - discountAmount;
                        var profit = sellingPrice - (aptaPrice);
                        var totalProfit = Convert.ToDecimal(profit) * jobPart.Quantity;
                        item.Profit = Math.Round(totalProfit, 3);

                    }
                    else
                    {
                        decimal markup = 0;
                        decimal discount = 0;
                        if (jobPart.Markup != null)
                        {
                            markup = Convert.ToDecimal(jobPart.Markup);
                        }
                        else
                        {
                            markup = Convert.ToDecimal(job.Customer.MarkupOnParts);
                        }
                        item.MarkupPercentage = markup;

                        if (jobPart.Discount != null)
                        {
                            discount = Convert.ToDecimal(jobPart.Discount);
                        }
                        else
                        {
                            discount = Convert.ToDecimal(job.Customer.DiscountOnParts);
                        }
                        item.DiscountPercentage = discount;
                        var laborCost = jobPart.LaborCost != null ? jobPart.LaborCost : 0;
                        item.PurchasePrice = Math.Round(Convert.ToDecimal(laborCost), 2);

                        var totalLabor = laborCost * jobPart.Quantity;
                        item.TotalPartCost = Math.Round(Convert.ToDecimal(totalLabor), 2);
                        var unitPrice = jobPart.UnitPrice;
                        var totalPrice = unitPrice * jobPart.Quantity;
                        var profit = totalPrice - totalLabor;
                        item.Profit = Math.Round(Convert.ToDecimal(profit), 3);
                    }
                }
                else
                    if (item.Type == "Labor")
                {
                    decimal markup = 0;
                    decimal discount = 0;
                    if (jobPart.Markup != null)
                    {
                        markup = Convert.ToDecimal(jobPart.Markup);
                    }
                    else
                    {
                        markup = Convert.ToDecimal(job.Customer.MarkupOnParts);
                    }
                    item.MarkupPercentage = markup;

                    if (jobPart.Discount != null)
                    {
                        discount = Convert.ToDecimal(jobPart.Discount);
                    }
                    else
                    {
                        discount = Convert.ToDecimal(job.Customer.DiscountOnParts);
                    }
                    item.DiscountPercentage = discount;
                    //var comission = markup - discount;
                    var laborCost = jobPart.LaborCost != null ? jobPart.LaborCost : 0;
                    item.PurchasePrice = Math.Round(Convert.ToDecimal(laborCost), 2);

                    //var totalLabor = laborCost * jobPart.Quantity;

                    item.TotalPartCost = Math.Round(Convert.ToDecimal(laborCost), 2);
                    var unitPrice = jobPart.UnitPrice;
                    var totalPrice = unitPrice * jobPart.Quantity;
                    var profit = totalPrice - laborCost;
                    item.Profit = Math.Round(Convert.ToDecimal(profit), 3);
                    //var price = 
                    //var purchasePrice = unitPrice * (100 / (100 + comission));
                    //item.PurchasePrice = Math.Round(purchasePrice, 2);
                    //var totalPrice = purchasePrice * jobPart.Quantity;
                    //item.TotalPartCost = Math.Round(totalPrice, 2);
                    //var profit = (unitPrice * jobPart.Quantity) - totalPrice;
                    //item.Profit = Math.Round(profit, 2);
                }

                else
                    if (item.Type == "ServiceCharge")
                {
                    decimal markup = 0;
                    decimal discount = 0;
                    if (jobPart.Markup != null)
                    {
                        markup = Convert.ToDecimal(jobPart.Markup);
                    }
                    else
                    {
                        markup = Convert.ToDecimal(job.Customer.MarkupOnParts);
                    }
                    item.MarkupPercentage = markup;

                    if (jobPart.Discount != null)
                    {
                        discount = Convert.ToDecimal(jobPart.Discount);
                    }
                    else
                    {
                        discount = Convert.ToDecimal(job.Customer.DiscountOnParts);
                    }
                    item.DiscountPercentage = discount;
                    //var comission = markup - discount;
                    var laborCost = jobPart.TripCost != null ? jobPart.TripCost : 0;
                    item.PurchasePrice = Math.Round(Convert.ToDecimal(laborCost), 2);

                    //var totalLabor = laborCost * jobPart.Quantity;

                    item.TotalPartCost = Math.Round(Convert.ToDecimal(laborCost), 2);
                    var unitPrice = jobPart.UnitPrice;
                    var totalPrice = unitPrice * jobPart.Quantity;
                    var profit = totalPrice - jobPart.TripCost;
                    item.Profit = Math.Round(Convert.ToDecimal(profit), 3);

                }

                else
                    if (item.Type == "Other")
                {
                    decimal markup = 0;
                    decimal discount = 0;
                    if (jobPart.Markup != null)
                    {
                        markup = Convert.ToDecimal(jobPart.Markup);
                    }
                    else
                    {
                        markup = Convert.ToDecimal(job.Customer.MarkupOnParts);
                    }
                    item.MarkupPercentage = markup;

                    if (jobPart.Discount != null)
                    {
                        discount = Convert.ToDecimal(jobPart.Discount);
                    }
                    else
                    {
                        discount = Convert.ToDecimal(job.Customer.DiscountOnParts);
                    }
                    item.DiscountPercentage = discount;

                    var laborCost = jobPart.OtherCost != null ? jobPart.OtherCost : 0;
                    item.PurchasePrice = Math.Round(Convert.ToDecimal(laborCost), 2);



                    item.TotalPartCost = Math.Round(Convert.ToDecimal(laborCost), 2);
                    var unitPrice = jobPart.UnitPrice;
                    var totalPrice = unitPrice * jobPart.Quantity;
                    var profit = totalPrice - jobPart.OtherCost;
                    item.Profit = Math.Round(Convert.ToDecimal(profit), 2);

                }
            }
            catch (Exception exception)
            {
                //Logger.LogException(exception.Message, exception);
            }
        }

        public MultiEstimatesPartsDetailsModel GetPartsDetails(string CallslipId)
        {
            int callSlipId = Convert.ToInt32(CallslipId);
            Job job = _unitOfWork.GenericRepository<Job>().GetSingle(x => x.Id == callSlipId);
            var model = new MultiEstimatesPartsDetailsModel();
            //Task 1528
            var customerTaxState = _unitOfWork.GenericRepository<CustomerStateMapping>().GetAsQuerable(x => x.CustomerId == job.CustomerId);
            var StateExempt = "";
            if (customerTaxState.Select(x => x.State.Name).Contains(job.State.Name))
            {
                StateExempt = job.State.Name;
            }
            var m = new List<MultiEstimatesModel>();

            List<JobPart> parts = _unitOfWork.GenericRepository<JobPart>().Get(x => x.JobId == job.Id);
            var Numbers = parts.Select(x => x.EstimateNumber).Distinct();
            if (parts.Any())
            {
                foreach (var num in Numbers)
                {
                    var item = new MultiEstimatesModel();
                    var p = parts.Where(x => x.EstimateNumber == num).ToList();
                    item.CreatedOn = p.FirstOrDefault().CreatedOn.ToString("MM/dd/yy hh:mm:ss");
                    item.EstimateLabel = p.FirstOrDefault() != null ? p.FirstOrDefault().EstimateLabel : "";
                    item.EstimateNumber = num.Value;
                    var mapping = _unitOfWork.GenericRepository<EstimateApproveMapping>().GetSingle(x => x.EstimateNumber == num.Value && x.JobId == job.Id);
                    if (mapping != null)
                        item.Approved = mapping.Approved;
                    else
                    {
                        item.Approved = false;
                    }
                    var subtotal = calculateSubtotal(p, callSlipId);
                    item.Total = subtotal.Total;
                    m.Add(item);
                }
                model.multiEstList = m;
            }
            model.StateExempt = StateExempt;
            return model;
        }

        private SubTotalModel calculateSubtotal(List<JobPart> parts, int callSlipId)
        {
            var job = _unitOfWork.GenericRepository<Job>().GetSingle(x => x.Id == callSlipId);
            var subTotal = new SubTotalModel();
            subTotal.PartsSubTotal = parts.Where(c => c.Type == 1).Sum(x => x.UnitPrice * x.Quantity).ToString();
            subTotal.LaborTotal = parts.Where(c => c.Type == 2).Sum(x => x.UnitPrice * x.Quantity).ToString();

            subTotal.ServiceCharge = parts.Where(c => c.Type == 4).Sum(x => x.UnitPrice * x.Quantity).ToString();
            subTotal.OtherCharges = parts.Where(c => c.Type == 3).Sum(x => x.UnitPrice * x.Quantity).ToString();

            //TaxRate taxRate = _unitOfWork.TaxRateRepository.GetSingle(x => x.ZipCode == job.ZipCode);
            TaxRate taxRate = new TaxRate();
            var taxList = _unitOfWork.GenericRepository<TaxRate>().GetAsQuerable(x => x.ZipCode == job.ZipCode).ToList();
            foreach (var tax in taxList)
            {
                if (parts.FirstOrDefault().CreatedOn >= tax.CreatedOn)
                {
                    taxRate = tax;
                }
            }
            double totalTax = taxRate != null
                ? ((taxRate.CityTax ?? 0) + (taxRate.CountyTax ?? 0) + (taxRate.StateTax ?? 0) + (taxRate.SpecialRate ?? 0))
                : 0;
            decimal totalAmount = 0;
            if (job.State.TaxPartsOnly)
            {
                //In acc with task #1104 in tasksheet
                var setting = _unitOfWork.GenericRepository<Setting>().GetAsQuerable(t => t.Name.Equals("ServiceTaxForCADate")).FirstOrDefault();
                if (setting != null && !String.IsNullOrEmpty(setting.Value))
                {
                    var input = setting.Value;
                    DateTime dateTime = DateTime.ParseExact(input, "MM/dd/yyyy", CultureInfo.InvariantCulture);
                    if (!String.IsNullOrEmpty(job.State.Abbreviation) && job.State.Abbreviation.ToLower().Equals("ca") && (!String.IsNullOrEmpty(subTotal.PartsSubTotal) && ((int)Convert.ToDouble(subTotal.PartsSubTotal) != 0))
                        && (!String.IsNullOrEmpty(subTotal.ServiceCharge) && ((int)Convert.ToDouble(subTotal.ServiceCharge) != 0)) && job.JobPart.FirstOrDefault().CreatedOn >= dateTime)
                    {
                        subTotal.PartsTax = subTotal.PartsTax ?? (job.Customer.TaxExempt || job.TaxExempt
                                     ? "0.00"
                                     : (totalTax * Convert.ToDouble(subTotal.PartsSubTotal)).ToString("N"));
                        totalAmount = Math.Round(
                            (Convert.ToDecimal(subTotal.PartsSubTotal) + Convert.ToDecimal(subTotal.OtherCharges) +
                             Convert.ToDecimal(subTotal.LaborTotal) + Convert.ToDecimal(subTotal.ServiceCharge)), 3);
                        var totalLessTrip = totalAmount - Convert.ToDecimal(subTotal.ServiceCharge);
                        var serviceTax = (job.Customer.TaxExempt || job.TaxExempt)
                            ? 0
                            : totalTax * ((double)((Convert.ToDecimal(subTotal.PartsSubTotal) / totalLessTrip) * Convert.ToDecimal(subTotal.ServiceCharge)));
                        var partsTotalTax = Convert.ToDouble(subTotal.PartsTax) + serviceTax;
                        subTotal.PartsTax = partsTotalTax.ToString("N");
                        double partsTotal = Convert.ToDouble(subTotal.PartsSubTotal) + Convert.ToDouble(partsTotalTax);
                        subTotal.PartsTotal = partsTotal.ToString("N");
                        totalAmount = Math.Round(
                        (Convert.ToDecimal(subTotal.PartsTotal) + Convert.ToDecimal(subTotal.OtherCharges) +
                         Convert.ToDecimal(subTotal.LaborTotal) + Convert.ToDecimal(subTotal.ServiceCharge)), 3);
                        subTotal.SubTotal = (Convert.ToDouble(totalAmount) - Convert.ToDouble(partsTotalTax)).ToString("N");
                    }
                    else
                    {
                        subTotal.PartsTax = subTotal.PartsTax ?? (job.Customer.TaxExempt || job.TaxExempt
                                     ? "0.00"
                                     : (totalTax * Convert.ToDouble(subTotal.PartsSubTotal)).ToString("N"));
                        double partsTotal = Convert.ToDouble(subTotal.PartsSubTotal) + Convert.ToDouble(subTotal.PartsTax);
                        subTotal.PartsTotal = partsTotal.ToString("N");
                        totalAmount = Math.Round(
                             (Convert.ToDecimal(subTotal.PartsTotal) + Convert.ToDecimal(subTotal.OtherCharges) +
                              Convert.ToDecimal(subTotal.LaborTotal) + Convert.ToDecimal(subTotal.ServiceCharge)), 3);
                        subTotal.SubTotal = (Convert.ToDouble(totalAmount) - Convert.ToDouble(subTotal.PartsTax)).ToString("N");
                    }
                    subTotal.Total = (Convert.ToDouble(totalAmount)).ToString("N");
                }
                else
                {
                    subTotal.PartsTotal = subTotal.PartsSubTotal;
                    totalAmount = Math.Round(
                        (Convert.ToDecimal(subTotal.PartsTotal) + Convert.ToDecimal(subTotal.OtherCharges) +
                         Convert.ToDecimal(subTotal.LaborTotal) + Convert.ToDecimal(subTotal.ServiceCharge)), 3);

                    subTotal.PartsTax = subTotal.PartsTax ?? (job.Customer.TaxExempt || job.TaxExempt
                                      ? "0.00"
                                      : (totalTax * Convert.ToDouble(subTotal.PartsSubTotal)).ToString("N"));
                    subTotal.SubTotal = totalAmount.ToString("N");
                    subTotal.Total = (Convert.ToDouble(subTotal.PartsTax) + Convert.ToDouble(totalAmount)).ToString();
                }
            }
            else
            {
                subTotal.PartsTotal = subTotal.PartsSubTotal;
                totalAmount = Math.Round(
                    (Convert.ToDecimal(subTotal.PartsTotal) + Convert.ToDecimal(subTotal.OtherCharges) +
                     Convert.ToDecimal(subTotal.LaborTotal) + Convert.ToDecimal(subTotal.ServiceCharge)), 3);

                subTotal.PartsTax = job.Customer.TaxExempt || job.TaxExempt
                    ? "0.00"
                    : Math.Round((totalTax * Convert.ToDouble(totalAmount)), 2).ToString("N");
                subTotal.SubTotal = totalAmount.ToString("N");
                subTotal.Total = (Convert.ToDouble(subTotal.PartsTax) + Convert.ToDouble(totalAmount)).ToString();
            }
            return subTotal;
        }

        public List<PartDropDown> GetAllParts(string query)
        {
            List<PartDropDown> pdd = new List<PartDropDown>();
            var parts =_unitOfWork.GenericRepository<Part>().GetAsQuerable(x=>x.Name.Contains(query)).ToList();
            foreach (var item in parts)
            {
                PartDropDown jpm = new PartDropDown();
                jpm.PartName = item.Name;
                jpm.PartId = item.PartId;
                pdd.Add(jpm);
            }
            return pdd;
        }

        public JobPartModel GetPartDetails(string PartName, string CustomerName, string JobPartId)
        {
            Part part = _unitOfWork.GenericRepository<Part>().GetSingle(x => x.Name.Contains(PartName) && !x.Deleted);
            var model = new JobPartModel();
            if (part != null)
            {
                model.Id = part.PartId;
                model.Title = part.Name;
                model.Description = part.FullDescription;
                model.UnitPrice = part.PurchasePrice;
                model.PurchasePrice = part.PurchasePrice;
                model.Quantity = Convert.ToDecimal(part.Quantity);
                model.partFound = "Yes";
                model.APTA = part.Apta != null ? part.Apta : 0;
                if (!string.IsNullOrEmpty(JobPartId))
                {
                    var jobPartId = Convert.ToInt32(JobPartId);
                    var jobPart = _unitOfWork.GenericRepository<JobPart>().GetAsQuerable(t => t.Id == jobPartId).FirstOrDefault();
                    model.MarkupPercentage = jobPart.Markup != null ? jobPart.Markup : 0;
                    model.DiscountPercentage = jobPart.Discount != null ? jobPart.Discount : 0;
                    if (model.MarkupPercentage == 0 && model.DiscountPercentage == 0)
                    {
                        var customer = _unitOfWork.GenericRepository<Customer>().GetAsQuerable(t => t.FirstName == CustomerName).FirstOrDefault();
                        if (customer != null)
                        {
                            model.MarkupPercentage = customer.MarkupOnParts != null ? customer.MarkupOnParts : 0;
                            model.DiscountPercentage = customer.DiscountOnParts != null ? customer.DiscountOnParts : 0;
                        }
                    }
                    var Markup = jobPart.Markup != null ? (jobPart.Markup / 100) * part.PurchasePrice : 0;
                    var aptaPrice = part.Apta != null ? part.Apta : 0;
                    //var totalApta =  aptaPrice * jobPart.Quantity;
                    var sellingPrice = (1 - (model.MarkupPercentage / 100));
                    sellingPrice = sellingPrice != null && sellingPrice != 0 ? aptaPrice / sellingPrice : 0;
                    var totalMargin = Markup + part.PurchasePrice;
                    var Discount = jobPart.Discount != null ? (jobPart.Discount / 100) * totalMargin : 0;
                    sellingPrice = sellingPrice - Discount;
                    model.MarkupOnParts = Math.Round(Convert.ToDecimal(Markup), 2);
                    model.DiscountOnParts = Math.Round(Convert.ToDecimal(Discount), 2);
                    var profit = sellingPrice - aptaPrice;
                    var totalProfit = profit * jobPart.Quantity;
                    model.Profit = Math.Round(Convert.ToDecimal(totalProfit), 2);
                    model.UnitPrice = Math.Round((Convert.ToDecimal(sellingPrice)), 2);

                }
                else
                {
                    var customer = _unitOfWork.GenericRepository<Customer>().GetAsQuerable(t => t.FirstName == CustomerName).FirstOrDefault();
                    if (customer != null)
                    {
                        model.MarkupPercentage = customer.MarkupOnParts != null ? customer.MarkupOnParts : 0;
                        model.DiscountPercentage = customer.DiscountOnParts != null ? customer.DiscountOnParts : 0;
                        var Markup = customer.MarkupOnParts != null ? (customer.MarkupOnParts / 100) * part.PurchasePrice : 0;
                        var aptaPrice = part.Apta != null ? part.Apta : 0;
                        var sellingPrice = (1 - (model.MarkupPercentage / 100));
                        sellingPrice = sellingPrice != null && sellingPrice != 0 ? aptaPrice / sellingPrice : 0;
                        var totalMargin = Markup + part.PurchasePrice;
                        var Discount = customer.DiscountOnParts != null ? (customer.DiscountOnParts / 100) * totalMargin : 0;
                        sellingPrice = sellingPrice - Discount;
                        model.MarkupOnParts = Math.Round(Convert.ToDecimal(Markup), 2);
                        model.DiscountOnParts = Math.Round(Convert.ToDecimal(Discount), 2);
                        // var unitPrice = totalMargin - model.DiscountOnParts;
                        model.UnitPrice = Math.Round((Convert.ToDecimal(sellingPrice)), 2);

                    }
                }
            }
            else
            {
                //user entered a part which is not present in database then it will populate its markup and discount and other information
                if (!string.IsNullOrEmpty(JobPartId))
                {
                    var jobPartId = Convert.ToInt32(JobPartId);
                    var jobPart = _unitOfWork.GenericRepository<JobPart>().GetAsQuerable(t => t.Id == jobPartId).FirstOrDefault();

                    model.MarkupPercentage = jobPart.Markup != null ? jobPart.Markup : 0;
                    model.DiscountPercentage = jobPart.Discount != null ? jobPart.Discount : 0;
                    if (model.MarkupPercentage == 0 && model.DiscountPercentage == 0)
                    {
                        var customer = _unitOfWork.GenericRepository<Customer>().GetAsQuerable(t => t.FirstName == CustomerName).FirstOrDefault();
                        if (customer != null)
                        {
                            model.MarkupPercentage = customer.MarkupOnParts != null ? customer.MarkupOnParts : 0;
                            model.DiscountPercentage = customer.DiscountOnParts != null ? customer.DiscountOnParts : 0;
                        }
                    }
                    var Markup = jobPart.Markup != null ? (jobPart.Markup / 100) * jobPart.LaborCost : 0;
                    var aptaPrice = jobPart.LaborCost != null ? jobPart.LaborCost : 0;
                    model.LaborCost = aptaPrice;
                    model.TripCost = jobPart.TripCost.HasValue ? jobPart.TripCost.Value : 0;
                    model.OtherCost = jobPart.OtherCost.HasValue ? jobPart.OtherCost.Value : 0;
                    var sellingPrice = (1 - (model.MarkupPercentage / 100));
                    sellingPrice = sellingPrice != null && sellingPrice != 0 ? aptaPrice / sellingPrice : 0;
                    var totalMargin = Markup + jobPart.LaborCost;
                    var Discount = jobPart.Discount != null ? (jobPart.Discount / 100) * totalMargin : 0;
                    sellingPrice = sellingPrice - Discount;
                    model.MarkupOnParts = Math.Round(Convert.ToDecimal(Markup), 2);
                    model.DiscountOnParts = Math.Round(Convert.ToDecimal(Discount), 2);
                    model.UnitPrice = Math.Round((Convert.ToDecimal(sellingPrice)), 2);
                    var profit = sellingPrice - aptaPrice;
                    var totalProfit = profit * jobPart.Quantity;
                    model.Profit = Math.Round(Convert.ToDecimal(totalProfit), 2);
                }
                else
                {
                    var customer = _unitOfWork.GenericRepository<Customer>().GetAsQuerable(t => t.FirstName == CustomerName).FirstOrDefault();
                    if (customer != null)
                    {
                        model.MarkupPercentage = customer.MarkupOnParts != null ? customer.MarkupOnParts : 0;
                        model.DiscountPercentage = customer.DiscountOnParts != null ? customer.DiscountOnParts : 0;
                    }
                }
                model.partFound = "No";
            }
            return model;
        }

        public List<PaymentModel> GetPaymentsByJobId(string CallSlipId)
        {
            int jobId = Convert.ToInt32(CallSlipId);
            var listPayments = new List<PaymentModel>();
            IQueryable<JobPayment> jobPayments = _unitOfWork.GenericRepository<JobPayment>().GetAsQuerable(x => x.JobId == jobId);

            if (jobPayments.Count() > 0)
            {
                foreach (JobPayment payment in jobPayments)
                {
                    var pModel = new PaymentModel();
                    pModel.Amount = (double)payment.AmountPaid;
                    pModel.DatePaid = payment.PaidDate != null ? payment.PaidDate.Value.ToString("d") : "";
                    pModel.PaymentMethod = payment.PaymentMethod != null ? payment.PaymentMethod.Name : "";
                    pModel.Approval = payment.AuthorizationTransactionCode ?? "";
                    pModel.Notes = payment.Recommendation ?? "";
                    pModel.ReceiptNumber = payment.ReceiptNumber;
                    var userName = _unitOfWork.GenericRepository<User>().GetAsQuerable(x => x.Id == payment.CreatedByUserId).Select(y => y.Username).FirstOrDefault();
                    pModel.UserName = userName != null ? userName : "";
                    listPayments.Add(pModel);
                }
            }
            return listPayments;
        }

        public List<CustomerCreditCardModel> GetPaymentMethodsByJobId(string CallSlipId)
        {
            int jobId = Convert.ToInt32(CallSlipId);
            var listCreditCards = new List<CustomerCreditCardModel>();
            IQueryable<CreditCard> paymentMethods = _unitOfWork.GenericRepository<Job>().GetAsQuerable(x => x.Id == jobId).FirstOrDefault().Customer.CreditCard.AsQueryable();
            if (paymentMethods.Count() > 0)
            {
                foreach (CreditCard pMethod in paymentMethods)
                {
                    var pMModel = new CustomerCreditCardModel();
                    pMModel.PaymentMethodId = pMethod.Id;
                    pMModel.NameOnCard = pMethod.NameOnCard;
                    var cardNumber = pMethod.CardNumber;
                    pMModel.CustomerCreditCardNumber = SecurityHelper.IsEncrypted(cardNumber) ? SecurityHelper.Decrypt(cardNumber) : cardNumber;
                    pMModel.CreditCardExpireMonth = pMethod.CreditCardExpireMonth;
                    pMModel.CreditCardExpireYear = pMethod.CreditCardExpireYear;
                    listCreditCards.Add(pMModel);
                }
            }
            return listCreditCards;
        }
    }
}
