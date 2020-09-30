using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Service
    {
        public Service()
        {
            CompanyPackages = new HashSet<CompanyPackages>();
            ServicePicture = new HashSet<ServicePicture>();
        }

        public int ServiceId { get; set; }
        public string Name { get; set; }
        public string ShortDescription { get; set; }
        public string FullDescription { get; set; }
        public string AdminComment { get; set; }
        public int TaxCategoryId { get; set; }
        public bool Deleted { get; set; }
        public DateTime CreatedOn { get; set; }
        public DateTime UpdatedOn { get; set; }
        public decimal Price { get; set; }
        public decimal SpecialPrice { get; set; }
        public decimal DiscountPrice { get; set; }
        public int? ServiceCategoryId { get; set; }
        public bool? IsCustomService { get; set; }
        public string Warranty { get; set; }
        public string TaskNo { get; set; }
        public int? CreatedByUserId { get; set; }
        public int? UpdatedByUserId { get; set; }
        public int OfficeId { get; set; }
        public bool IsQbsynced { get; set; }
        public int? Qbid { get; set; }
        public bool IsSaservice { get; set; }
        public double? RequiredTime { get; set; }
        public decimal? HourlyRate { get; set; }
        public bool? Brochure { get; set; }
        public decimal? Material { get; set; }
        public int? StarRatingValue { get; set; }
        public bool DisplayPayment { get; set; }
        public decimal? DisplayAmount { get; set; }

        public virtual ICollection<CompanyPackages> CompanyPackages { get; set; }
        public virtual ICollection<ServicePicture> ServicePicture { get; set; }
    }
}
