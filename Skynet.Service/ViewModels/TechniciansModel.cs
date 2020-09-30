using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Skynet.Service.ViewModels
{
    public class TechniciansModel
    {
        public string Name { get; set; }
        public string BusinessName { get; set; }
        public string City { get; set; }
        public string State { get; set; }
        public string CreatedByUser { get; set; }
    }

    public class TechContractorList
    {
        public List<TechniciansModelSP> TechList { get; set; }
        public List<JobContractorMappingModel> ContractorList { get; set; }
    }

    public class TechniciansModelSP
    {
        public long Id { get; set; }
        public string ContactPerson { get; set; }
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string BussinessName { get; set; }
        public string MainEmailAddress { get; set; }
        public string LoginPassword { get; set; }
        public bool IsDeleted { get; set; }
        public long ContractorId { get; set; }
        public string AssignContractor { get; set; }
        public string MainTechnicianPhone { get; set; }
        public string LicenseNumber { get; set; }
        public DateTime? LicenseExpirationDate { get; set; }
        public string Notes { get; set; }
        public string NotesCreatedBy { get; set; }
        public string NotesCreatedOn { get; set; }
        //public HttpPostedFileBase TechPicture { get; set; }
        public string TechPictureUrl { get; set; }
        public string PicturePath { get; set; }
        public long Value { get; set; }
        public string Text { get; set; }
        public string TechnicianFax { get; set; }
        public string TechETA { get; set; }
        public long CallSlipId { get; set; }


    }
}