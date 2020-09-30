using Skynet.Data.Helpers;
using Skynet.Data.Models;
using Skynet.Repository.Interfaces;
using Skynet.Service.ViewModels;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

namespace Skynet.Service.ModelBuilders
{
    public static class CallSlipModelBuilder
    {

        public static List<MainCallSlipGridModel> PrepareJobsForModel(IPagedList<vwJobs> jobs, string searchType, IQueryable<UserJobsRecord> UsrJobsRecord)
        {
            bool isRecentlyViewed = !String.IsNullOrEmpty(searchType) && searchType.Equals("2") ? true : false;
            IQueryable<UserJobsRecord> usrJobsRecord = Enumerable.Empty<UserJobsRecord>().AsQueryable();
            if (isRecentlyViewed)
            {
                usrJobsRecord = UsrJobsRecord;// _unitOfWork.GenericRepository<UserJobsRecord>().GetAsQuerable(x => x.UserId == 10332).OrderByDescending(e => e.Id).DistinctBy(p => p.JobId).Take(15)
                      // .OrderByDescending(q => q.ViewedOn).AsQueryable();
                //.OrderByDescending(e => e.Id).Take(15)
                //    .OrderBy(q => q.ViewedOn).Select(w => w.JobId);
            }


            var callSlips = new List<MainCallSlipGridModel>();
            foreach (vwJobs job in jobs)
            {
                var item = new MainCallSlipGridModel();
                item.CustomerName = job.CustomerName;
                item.Id = job.Id;

                item.IsIdle = job.IsIdle > 0;

                //item.IsMobileNotification = job.MobileNotifications > 0;

                item.JobStatus = job.JobStatus.Substring(job.JobStatus.LastIndexOf('-') + 1) ?? "";
                item.JobStatusCode = job.JobStatusCode;
                item.BackgroundColor = job.JobStatusBackgroundColor ?? "";
                item.FontColor = job.JobStatusFontColor ?? "";
                //item.JobStatusId = job.JobStatusId;

                //New: In acc with the task# 903 on tasksheet
                if (job.JobContractorMapping.Any())//Get  ETA if Contractor is assigned to the job
                {
                    //var eta = job.JobContractorMappings.AsQueryable().OrderByDescending(x => x.JobContractorETA).Select(y => y.JobContractorETA).FirstOrDefault();
                    //item.ExpectedDateTime = !String.IsNullOrEmpty(eta) ? eta : "ETA N/A";
                    string eta = "";
                    try
                    {
                        if (!String.IsNullOrEmpty(job.JobContractorMapping.AsQueryable().OrderByDescending(x => x.Id).Select(y => y.Eta).FirstOrDefault()))
                        {
                            eta = job.JobContractorMapping.AsQueryable().OrderByDescending(x => x.Id).Select(y => y.Eta).FirstOrDefault();
                        }
                        else if (!String.IsNullOrEmpty(job.JobContractorMapping.AsQueryable().OrderByDescending(x => x.Id).Select(y => y.JobContractorEta).FirstOrDefault()))
                        {
                            eta = job.JobContractorMapping.AsQueryable().OrderByDescending(x => x.Id).Select(y => y.JobContractorEta).FirstOrDefault();
                        }
                        else
                        {
                            //Notes can be fetched through JCM to check for ETA Info
                            var jobData = job.JobContractorMapping.Select(x => x.Job).FirstOrDefault();
                            if (jobData.JobNotes.Any(e => e.Notes.ToLower().Contains("eta is")))
                            {
                                string note = jobData.JobNotes.OrderByDescending(p => p.CreatedOn).Where(e => e.Notes.ToLower().Contains("eta is")).Select(r => r.Notes).FirstOrDefault();
                                if (!String.IsNullOrEmpty(note))
                                {
                                    var etaInfo = note.Split(new string[] { "Eta is " }, StringSplitOptions.None);
                                    eta = etaInfo[etaInfo.Length - 1];
                                }
                            }
                        }
                    }
                    catch (Exception ex)
                    {
                        //Logger.LogException(ex.Message, ex);
                        eta = "";
                    }

                    item.ETA = !String.IsNullOrEmpty(eta) ? eta : "ETA N/A";
                }
                else
                {
                    item.ETA = "ETA N/A";
                }

                if (job.DateIntervalType == 1)
                {
                    item.FromTime = job.ExpectedDateTime != null ? job.ExpectedDateTime.Value.ToString() : "";
                    if (String.IsNullOrEmpty(item.FromTime))
                    {
                        item.FromTime = "00:00";
                    }
                    item.ExpectedDateTime = "At " + GetTimeAMPM(item.FromTime);

                }
                else if (job.DateIntervalType == 2)
                {
                    if (String.IsNullOrEmpty(item.FromTime))
                    {
                        item.FromTime = "00:00";
                    }
                    item.FromTime = job.ExpectedDateTime != null ? job.ExpectedDateTime.Value.ToString() : "";
                    item.ExpectedDateTime = "By " + GetTimeAMPM(item.FromTime);
                }
                else if (job.DateIntervalType == 3)
                {
                    if (String.IsNullOrEmpty(item.FromTime))
                    {
                        item.FromTime = "00:00";
                        item.ToTime = "00:00";
                    }
                    item.FromTime = job.ExpectedDateTime != null ? job.ExpectedDateTime.Value.ToString() : "";
                    item.ToTime = job.ToTime != null ? job.ToTime.Value.ToString() : "";
                    item.ExpectedDateTime = " Between " + GetTimeAMPM(item.FromTime) + " and " + GetTimeAMPM(item.ToTime);
                }

                if (job.ExpectedDate == DateTime.Today.Date)
                {
                    item.ExpectedDate = "Today";
                }
                else
                {
                    item.ExpectedDate = job.ExpectedDate != null ? job.ExpectedDate.Value.ToString("MM/dd/yyyy") : "";
                }


                //TASK # 1678
                if (job.JobStatusId.Value == 4 || job.JobStatusId.Value == 31)
                {
                    if (job.JobContractorMapping.Any())
                    {
                        if (job.JobContractorMapping.FirstOrDefault().Job.JobPart.Any())
                            item.estimateCreated = "E";
                        else
                            item.estimateCreated = "";
                    }
                }
                else
                {
                    item.estimateCreated = "";
                }
                if (job.JobContractorMapping.Any())
                {
                    if (job.JobContractorMapping.FirstOrDefault().Job.Document.Where(x => x.Name.Contains("invoice") || x.Name.Contains("Invoice")).Any())
                        item.estimateCreated += " I";
                    else
                        item.estimateCreated = "";
                }
                else
                {
                    item.estimateCreated = "";
                }
                //if (job.CreatedOn.Date == DateTime.Today.Date)
                //{
                //    item.CreatedOn = "Today";
                //}
                //else
                //{
                item.CreatedOn = job.CreatedOn != null ? job.CreatedOn.ToString("MM/dd/yyyy") : "";
                //}

                item.IsEmergency = Convert.ToBoolean(job.IsEmergency);
                item.City = job.City;
                item.StateAbbreviation = job.StateAbbreviation ?? "";
                item.StoreLocationName = job.StoreNumber ?? "";
                item.JobDescription = job.JobDescription;
                item.EquipmentName = job.EquipmentName;
                var PriContractor = job.PrimaryContractor != null ? job.PrimaryContractor : job.ContractorFirstName + " " + job.ContractorLastName;
                if (PriContractor != null && PriContractor != " ")
                {
                    item.PrimaryContractor = PriContractor;
                }
                else
                {
                    item.PrimaryContractor = job.ContractorBusinessName;
                }
                if (!String.IsNullOrEmpty(job.ContractorBusinessName) && job.ContractorBusinessName.Contains("-"))
                {
                    var arr = job.ContractorBusinessName.Split('-');
                    if (arr.Length == 3)
                    {
                        item.ContractorBusinessName = arr[0] + "-" + arr[1];
                    }
                    else
                    {
                        item.ContractorBusinessName = job.ContractorBusinessName ?? "";
                    }
                }
                else
                {
                    item.ContractorBusinessName = job.ContractorBusinessName ?? "";
                }
                item.TimeZoneCode = job.TimeZoneCode;
                item.TimeZoneName = job.TimeZoneName;
                if (!isRecentlyViewed)
                {
                    if (job.ExpectedDate.HasValue && job.ExpectedDateTime.HasValue && job.TimeZoneName != null)
                    {
                        DateTime expectedTime = job.ExpectedDate.Value.Add(job.ExpectedDateTime.Value);
                        TimeZoneInfo jobTimeZone = TimeZoneInfo.FindSystemTimeZoneById(job.TimeZoneName);
                        DateTime jobTimeZoneTime = TimeZoneInfo.ConvertTime(expectedTime, jobTimeZone, TimeZoneInfo.Local);
                        var remainingHours = (int)jobTimeZoneTime.Subtract(DateTime.Now).TotalHours;

                        item.RemainingMinutes = remainingHours.ToString();
                        item.RemainingMinutesInt = remainingHours;
                        if (remainingHours > 24)
                        {
                            item.RemainingMinutes = "24+";
                            item.RemainingMinutesInt = 25;
                        }
                        if (remainingHours < -24)
                        {
                            item.RemainingMinutes = "";
                            item.RemainingMinutesInt = 26;
                        }
                    }
                    else
                    {
                        item.RemainingMinutes = "24+";
                        item.RemainingMinutesInt = 25;
                    }
                }
                else
                {
                    var timeViewed = usrJobsRecord.Where(e => e.JobId == job.Id).Select(w => w.ViewedOn).FirstOrDefault();
                    var timelapsed = "";
                    var remainingTime = DateTime.Now.Subtract(timeViewed);
                    if ((int)remainingTime.TotalHours < 1)
                    {
                        //show in mins
                        if ((int)remainingTime.TotalMinutes < 1)
                        {
                            timelapsed = "Just now";
                        }
                        else
                        {
                            timelapsed = (int)remainingTime.TotalMinutes + " m";
                        }
                    }
                    else if ((int)remainingTime.TotalHours > 1 && (int)remainingTime.TotalHours < 24)
                    {
                        //show in hours
                        timelapsed = (int)remainingTime.TotalHours + " h ago";
                    }
                    else
                    {
                        //show in days
                        timelapsed = (int)remainingTime.TotalDays + " d";
                    }

                    item.RemainingMinutes = timelapsed;
                }
                item.TimeInCurrentStatus = job.TimeInCurrentStatus.Value.RelativeFormat();

                callSlips.Add(item);
            }

            return callSlips;
        }

        public static string GetTimeAMPM(string time)
        {
            TimeSpan ft = TimeSpan.Parse(time);
            DateTime ftTemp = DateTime.ParseExact(ft.ToString(), "HH:mm:ss", CultureInfo.InvariantCulture);
            string ftString = ftTemp.ToString("hh:mmtt");
            return ftString;
        }
    }
}
