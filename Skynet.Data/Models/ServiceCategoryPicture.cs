using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class ServiceCategoryPicture
    {
        public int ServiceCategoryPictureId { get; set; }
        public int? ServiceCategoryId { get; set; }
        public string PicturePath { get; set; }
        public bool? IsDefault { get; set; }
        public DateTime? CreatedOn { get; set; }
        public DateTime? UpdatedOn { get; set; }
        public int? CreatedByUserId { get; set; }
        public int? UpdatedByUserId { get; set; }
        public bool Deleted { get; set; }
        public string TagName { get; set; }
    }
}
