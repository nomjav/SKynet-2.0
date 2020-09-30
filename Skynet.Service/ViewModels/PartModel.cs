using System;
using System.Collections.Generic;
using System.Text;

namespace Skynet.Service.ViewModels
{
    public class PartModel
    {
        public long PartID { get; set; }
        public string Name { get; set; }
        public string FullDescription { get; set; }
        public bool Deleted { get; set; }
        public System.DateTime CreatedOn { get; set; }
        public decimal Price { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal APTA { get; set; }
        public int Quantity { get; set; }
        public string Manufacturer { get; set; }
        public decimal? BaseLine { get; set; }
        public string ShelfLocation { get; set; }
        public int? InHouseInventory { get; set; }
        public string PicturePath { get; set; }
        public int Rack { get; set; }
        public int Bin { get; set; }
        public string OrderedFrom { get; set; }
        public string HotNo { get; set; }
        public Nullable<decimal> EcommercePricing { get; set; }
    }

    public class PartDropDown
    {
        public long PartId { get; set; }
        public string PartName { get; set; }
    }
    public enum PartType
    {
        Parts = 1,
        Labor = 2,
        Other = 3,
        ServiceCharge = 4
    }

    public class JobPartModel
    {
        public long Id { get; set; }
        public long JobId { get; set; }
        public long? PartId { get; set; }
        public string Type { get; set; }
        public string Title { get; set; }
        public string CreatedByUser { get; set; }
        public string CreatedOn { get; set; }
        public string Description { get; set; }
        public decimal UnitPrice { get; set; }
        public decimal PurchasePrice { get; set; }
        public decimal Profit { get; set; }
        public decimal Quantity { get; set; }
        public decimal? MarkupOnParts { get; set; }
        public decimal? MarkupPercentage { get; set; }
        public decimal? DiscountOnParts { get; set; }
        public decimal? DiscountPercentage { get; set; }
        public decimal TotalPartCost { get; set; }
        public decimal LabourDisplayPrice { get; set; }
        public decimal? LaborCost { get; set; }
        public string partFound { get; set; }
        public decimal? APTA { get; set; }
        public decimal TripCost { get; set; }
        public decimal OtherCost { get; set; }
        public long EstimateNumber { get; set; }
        public string EstimateLabel { get; set; }
    }

    public class MultiEstimatesPartsDetailsModel
    {
        public MultiEstimatesPartsDetailsModel()
        {
            multiEstList = new List<MultiEstimatesModel>();
        }
        public List<MultiEstimatesModel> multiEstList { get; set; }
        public string StateExempt { get; set; }
    }
    public class MultiEstimatesModel
    {
        public string EstimateLabel { get; set; }
        public long EstimateNumber { get; set; }
        public string CreatedOn { get; set; }
        public string Total { get; set; }
        public bool Approved { get; set; }
    }
    public class SubTotalModel
    {
        public string SalesTax { get; set; }
        public string PartsSubTotal { get; set; }
        public string LaborTotal { get; set; }
        public string PartsTax { get; set; }
        public string PartsTotal { get; set; }
        public string ServiceCharge { get; set; }
        public string NonTaxable { get; set; }
        public string OtherCharges { get; set; }
        public string SubTotal { get; set; }
        public string Total { get; set; }
        public string ShippingCharges { get; set; }
        public string TaxOnTotalAmount { get; set; }
        public decimal ChangeTax { get; set; }
        public decimal CalculatedTax { get; set; }
        public int FormOfPayment { get; set; }
        public bool isExemptState { get; set; }

    }

    public class PartJsonModel
    {
        public SubTotalModel subtotal { get; set; }
        public List<JobPartModel> jobPart { get; set; }
        public string StateExempt { get; set; }
    }
}
