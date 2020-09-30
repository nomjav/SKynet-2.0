using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Document
    {
        public long Id { get; set; }
        public string Name { get; set; }
        public int? Type { get; set; }
        public string Descritption { get; set; }
        public string Path { get; set; }
        public long? JobId { get; set; }
        public DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public DateTime LastUpdateOn { get; set; }
        public long LastUpdateByUserId { get; set; }
        public long? ContractorId { get; set; }
        public long? CustomerId { get; set; }
        public int? ContractorDocumentType { get; set; }
        public DateTime? ExpiryDate { get; set; }
        public bool DocumentVerified { get; set; }
        public bool? AzureUploaded { get; set; }
        public bool? IfExists { get; set; }
        public int? CustomerDocumentType { get; set; }
        public string LicenseNumber { get; set; }
        public long? VerifiedByUserId { get; set; }
        public string InsuranceType { get; set; }
        public string MeetingMinimumRequiremenmt { get; set; }
        public bool? RelatedToIphone { get; set; }

        public virtual Contractor Contractor { get; set; }
        public virtual Customer Customer { get; set; }
        public virtual Job Job { get; set; }
    }
}
