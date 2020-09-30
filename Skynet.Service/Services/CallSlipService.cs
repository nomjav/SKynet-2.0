
using Skynet.Data.Models;
using Skynet.Repository.Interfaces;
using Skynet.Service.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;
using Skynet.Service.ViewModels;
using System.Linq;
using Kendo.Mvc.UI;
using Kendo.Mvc.Extensions;

namespace Skynet.Service.Services
{
    public class CallSlipService : ICallSlipService
    {
        private IUnitOfWork _unitOfWork;
        public CallSlipService(IUnitOfWork unitOfWork)
        {
            _unitOfWork = unitOfWork;
        }
        public DataSourceResult CallUsBackJobs([DataSourceRequest] DataSourceRequest request)
        {
            var services = _unitOfWork.GenericRepository<Job>().Get(x => x.JobStatusId == 10 && x.BookedByUserId == 10332);
            var cublist = new List<CubModel>(services.Select(x => new CubModel
            {
                Id = x.Id,
                CustomerName = ((!String.IsNullOrEmpty(x.Customer.FirstName) ? x.Customer.FirstName : "") + " " + (!String.IsNullOrEmpty(x.Customer.LastName) ? x.Customer.LastName : "")).Trim(),
                City = x.City,
                Phone = x.Phone,
                JobType = x.JobType.Type,
                Notes = x.Notes
            })).ToDataSourceResult(request);

            return cublist;
        }


    }
}
