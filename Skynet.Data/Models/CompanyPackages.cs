using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class CompanyPackages
    {
        public CompanyPackages()
        {
            PackagePriority = new HashSet<PackagePriority>();
        }

        public int PackageId { get; set; }
        public string PackageName { get; set; }
        public decimal PackageSavings { get; set; }
        public string PackageNextService { get; set; }
        public string PackageFeeFrequency { get; set; }
        public int? PackageFeeNumbes { get; set; }
        public string PackageFeeRepeat { get; set; }
        public int? PackageFeeRepeatEvery { get; set; }
        public decimal? NextAmount { get; set; }
        public string BuildPackageMessage { get; set; }
        public decimal? PackageSpiffPayD { get; set; }
        public decimal? PackageSpiffPayP { get; set; }
        public int NoofVisits { get; set; }
        public string VisitsRepeat { get; set; }
        public int VisitsRepeatEvery { get; set; }
        public bool IsDeleted { get; set; }
        public bool? IsActive { get; set; }
        public decimal PackageAmount { get; set; }
        public string TypeOfService { get; set; }
        public int TagId { get; set; }
        public int ServiceId { get; set; }
        public long? UpdatedBy { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public long CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }

        public virtual Service Service { get; set; }
        public virtual ICollection<PackagePriority> PackagePriority { get; set; }
    }
}
