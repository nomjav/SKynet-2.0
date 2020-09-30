using System;
using System.Collections.Generic;

namespace Skynet.Data.Models
{
    public partial class Part
    {
        public Part()
        {
            JobPart = new HashSet<JobPart>();
            TruckParts = new HashSet<TruckParts>();
        }

        public long PartId { get; set; }
        public string Name { get; set; }
        public string FullDescription { get; set; }
        public string Manufacturer { get; set; }
        public Nullable<decimal> Baseline { get; set; }
        public string ShelfLocation { get; set; }
        public bool Deleted { get; set; }
        public decimal Price { get; set; }
        public decimal PurchasePrice { get; set; }
        public Nullable<decimal> Apta { get; set; }
        public Nullable<int> Quantity { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public long CreatedByUserId { get; set; }
        public System.DateTime LastUpdatedOn { get; set; }
        public long LastUpdateByUserId { get; set; }
        public Nullable<int> InHouseInventory { get; set; }
        public Nullable<int> Rack { get; set; }
        public Nullable<int> Bin { get; set; }
        public string OrderedFrom { get; set; }
        public string HotNo { get; set; }
        public string PicturePath { get; set; }
        public Nullable<decimal> EcommercePricing { get; set; }
        public int OfficeId { get; set; }

        public virtual ICollection<JobPart> JobPart { get; set; }
        public virtual ICollection<TruckParts> TruckParts { get; set; }
    }
}
