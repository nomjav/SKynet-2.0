using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata;

namespace Skynet.Data.Models
{
    public partial class AcademyLockSmith_LiveContext : DbContext
    {
        public AcademyLockSmith_LiveContext()
        {
        }

        public AcademyLockSmith_LiveContext(DbContextOptions<AcademyLockSmith_LiveContext> options)
            : base(options)
        {
        }

        public virtual DbSet<Address> Address { get; set; }
        public virtual DbSet<Adjustment> Adjustment { get; set; }
        public virtual DbSet<AdType> AdType { get; set; }
        public virtual DbSet<AlskeywordList> AlskeywordList { get; set; }
        public virtual DbSet<AptakillsOrAccounts> AptakillsOrAccounts { get; set; }
        public virtual DbSet<BlockedSlots> BlockedSlots { get; set; }
        public virtual DbSet<CallRecord> CallRecord { get; set; }
        public virtual DbSet<CompanyPackages> CompanyPackages { get; set; }
        public virtual DbSet<ComplianceDetails> ComplianceDetails { get; set; }
        public virtual DbSet<Contractor> Contractor { get; set; }
        public virtual DbSet<ContractorAssignedZipCode> ContractorAssignedZipCode { get; set; }
        public virtual DbSet<ContractorCreditHistory> ContractorCreditHistory { get; set; }
        public virtual DbSet<ContractorDetail> ContractorDetail { get; set; }
        public virtual DbSet<ContractorNote> ContractorNote { get; set; }
        public virtual DbSet<ContractorRatings> ContractorRatings { get; set; }
        public virtual DbSet<Country> Country { get; set; }
        public virtual DbSet<County> County { get; set; }
        public virtual DbSet<CreditCard> CreditCard { get; set; }
        public virtual DbSet<Customer> Customer { get; set; }
        public virtual DbSet<CustomerSelectedPackages> CustomerSelectedPackages { get; set; }
        public virtual DbSet<CustomerStateMapping> CustomerStateMapping { get; set; }
        public virtual DbSet<DailyBoardStats> DailyBoardStats { get; set; }
        public virtual DbSet<Device> Device { get; set; }
        public virtual DbSet<Discrepancies> Discrepancies { get; set; }
        public virtual DbSet<DiscrepanciesList> DiscrepanciesList { get; set; }
        public virtual DbSet<Document> Document { get; set; }
        public virtual DbSet<EmailLog> EmailLog { get; set; }
        public virtual DbSet<Equipment> Equipment { get; set; }
        public virtual DbSet<EquipmentCategory> EquipmentCategory { get; set; }
        public virtual DbSet<ErrorLog> ErrorLog { get; set; }
        public virtual DbSet<HeadSheet> HeadSheet { get; set; }
        public virtual DbSet<Invoice> Invoice { get; set; }
        public virtual DbSet<InvoiceDetails> InvoiceDetails { get; set; }
        public virtual DbSet<InvoiceServices> InvoiceServices { get; set; }
        public virtual DbSet<Job> Job { get; set; }
        public virtual DbSet<JobAlarms> JobAlarms { get; set; }
        public virtual DbSet<JobContractorMapping> JobContractorMapping { get; set; }
        public virtual DbSet<JobLog> JobLog { get; set; }
        public virtual DbSet<JobNotes> JobNotes { get; set; }
        public virtual DbSet<JobPart> JobPart { get; set; }
        public virtual DbSet<EstimateApproveMapping> EstimateApproveMapping { get; set; }
        public virtual DbSet<JobPayment> JobPayment { get; set; }
        public virtual DbSet<JobStatus> JobStatus { get; set; }
        public virtual DbSet<JobType> JobType { get; set; }
        public virtual DbSet<ManagerSheet> ManagerSheet { get; set; }
        public virtual DbSet<MobileNotification> MobileNotification { get; set; }
        public virtual DbSet<OauthTokens> OauthTokens { get; set; }
        public virtual DbSet<PackagePriority> PackagePriority { get; set; }
        public virtual DbSet<Part> Part { get; set; }
        public virtual DbSet<PartsUserFavourites> PartsUserFavourites { get; set; }
        public virtual DbSet<PaymentLog> PaymentLog { get; set; }
        public virtual DbSet<PaymentMethod> PaymentMethod { get; set; }
        public virtual DbSet<PermissionRecord> PermissionRecord { get; set; }
        public virtual DbSet<PermissionRecordRoleMapping> PermissionRecordRoleMapping { get; set; }
        public virtual DbSet<PermissionRecordUserMapping> PermissionRecordUserMapping { get; set; }
        public virtual DbSet<PhoneNumber> PhoneNumber { get; set; }
        public virtual DbSet<PoinventoryHistory> PoinventoryHistory { get; set; }
        public virtual DbSet<Projects> Projects { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrder { get; set; }
        public virtual DbSet<PurchaseOrderDetails> PurchaseOrderDetails { get; set; }
        public virtual DbSet<QueuedEmails> QueuedEmails { get; set; }
        public virtual DbSet<QuickCallSlip> QuickCallSlip { get; set; }
        public virtual DbSet<Receipt> Receipt { get; set; }
        public virtual DbSet<Role> Role { get; set; }
        public virtual DbSet<Service> Service { get; set; }
        public virtual DbSet<ServiceCategoryPicture> ServiceCategoryPicture { get; set; }
        public virtual DbSet<ServicePicture> ServicePicture { get; set; }
        public virtual DbSet<Services> Services { get; set; }
        public virtual DbSet<ServicesCategory> ServicesCategory { get; set; }
        public virtual DbSet<Setting> Setting { get; set; }
        public virtual DbSet<ShippingRates> ShippingRates { get; set; }
        public virtual DbSet<Smslog> Smslog { get; set; }
        public virtual DbSet<State> State { get; set; }
        public virtual DbSet<Store> Store { get; set; }
        public virtual DbSet<StorePartHistory> StorePartHistory { get; set; }
        public virtual DbSet<TaxRate> TaxRate { get; set; }
        public virtual DbSet<TechnicianNotes> TechnicianNotes { get; set; }
        public virtual DbSet<Technicians> Technicians { get; set; }
        public virtual DbSet<TechReceiptLineItem> TechReceiptLineItem { get; set; }
        public virtual DbSet<TechSumary> TechSumary { get; set; }
        public virtual DbSet<TopCitiesTable> TopCitiesTable { get; set; }
        public virtual DbSet<Truck> Truck { get; set; }
        public virtual DbSet<TruckParts> TruckParts { get; set; }
        public virtual DbSet<TruckTechnicianHistory> TruckTechnicianHistory { get; set; }
        public virtual DbSet<User> User { get; set; }
        public virtual DbSet<UserJobsRecord> UserJobsRecord { get; set; }
        public virtual DbSet<UserLogin> UserLogin { get; set; }
        public virtual DbSet<WebAddressManager> WebAddressManager { get; set; }
        public virtual DbSet<ZipCodeData> ZipCodeData { get; set; }
        public virtual DbSet<SP_GetJobCount> SP_GetJobCounts { get; set; }
        public virtual DbSet<SP_GetContractorByJobID> SP_GetContractorsByJobID { get; set; }
        public virtual DbSet<vwJobs> vwJobs { get; set; }

        // Unable to generate entity type for table 'dbo.testing'. Please see the warning messages.

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            if (!optionsBuilder.IsConfigured)
            {

            }
            optionsBuilder.UseLazyLoadingProxies();
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Address>(entity =>
            {
                entity.Property(e => e.CountryId).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IsDefault)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.LastUpdateOn).HasColumnType("datetime");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Address_Country");

                entity.HasOne(d => d.County)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CountyId)
                    .HasConstraintName("FK_Address_County");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Address_Customer");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Address)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Address_State");
            });

            modelBuilder.Entity<Adjustment>(entity =>
            {
                entity.Property(e => e.Amount).HasColumnType("money");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DateTimeStamp).HasColumnType("datetime");

                entity.Property(e => e.IsReceiptAdjustment).HasColumnName("isReceiptAdjustment");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasMaxLength(200);

                entity.Property(e => e.ReceiptNumber)
                    .HasColumnName("receiptNumber")
                    .HasMaxLength(200);

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.Adjustment)
                    .HasForeignKey(d => d.ContractorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adjustment_Contractor");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.AdjustmentCreatedByUser)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adjustment_User");

                entity.HasOne(d => d.LastUpdatedByUser)
                    .WithMany(p => p.AdjustmentLastUpdatedByUser)
                    .HasForeignKey(d => d.LastUpdatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Adjustment_User1");
            });

            modelBuilder.Entity<AdType>(entity =>
            {
                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<AlskeywordList>(entity =>
            {
                entity.ToTable("ALSKeywordList");

                entity.Property(e => e.Word).HasMaxLength(500);
            });

            modelBuilder.Entity<AptakillsOrAccounts>(entity =>
            {
                entity.ToTable("APTAKillsOrAccounts");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CustomerName).HasMaxLength(100);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.StoreName).HasMaxLength(100);

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<BlockedSlots>(entity =>
            {
                entity.HasKey(e => e.BlockedId);

                entity.Property(e => e.BlockedHeight)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.BlockedReason).IsUnicode(false);

                entity.Property(e => e.BlockedSlot)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.DataValue)
                    .HasColumnName("dataValue")
                    .HasMaxLength(50);

                entity.Property(e => e.Date).HasColumnType("datetime");
            });

            modelBuilder.Entity<CallRecord>(entity =>
            {
                entity.Property(e => e.DateTimeCreated).HasColumnType("datetime");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.CallRecord)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_CallRecord_Job");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.CallRecord)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CallRecord_User");
            });

            modelBuilder.Entity<CompanyPackages>(entity =>
            {
                entity.HasKey(e => e.PackageId);

                entity.Property(e => e.PackageId).HasColumnName("PackageID");

                entity.Property(e => e.BuildPackageMessage).IsUnicode(false);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IsActive)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.PackageFeeFrequency)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PackageFeeRepeat)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PackageName)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PackageNextService)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.TagId).HasColumnName("TagID");

                entity.Property(e => e.TypeOfService)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.VisitsRepeat)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.CompanyPackages)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CompanyPackages_Service");
            });

            modelBuilder.Entity<ComplianceDetails>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.ReminderDate).HasColumnType("datetime");

                entity.Property(e => e.Sent).HasColumnName("sent");
            });

            modelBuilder.Entity<Contractor>(entity =>
            {
                entity.HasIndex(e => new { e.FirstName, e.LastName, e.BusinessName, e.Id })
                    .HasName("_dta_index_Contractor_8_597577167__K1_4_5_7");

                entity.Property(e => e.AccountingContact).HasMaxLength(250);

                entity.Property(e => e.Active).HasDefaultValueSql("((0))");

                entity.Property(e => e.AfterHoursAlternatePhone).HasMaxLength(250);

                entity.Property(e => e.AssignedZipCode).HasMaxLength(50);

                entity.Property(e => e.BusinessName).HasMaxLength(250);

                entity.Property(e => e.CommissionRate).HasMaxLength(50);

                entity.Property(e => e.Commissioned).HasDefaultValueSql("((1))");

                entity.Property(e => e.ContractorPicture).HasMaxLength(500);

                entity.Property(e => e.CreatedByUserId).HasDefaultValueSql("((7))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.DefaultNteamount)
                    .HasColumnName("DefaultNTEAmount")
                    .HasColumnType("money");

                entity.Property(e => e.FirstName).HasMaxLength(250);

                entity.Property(e => e.GeneralContactPerson).HasMaxLength(250);

                entity.Property(e => e.HiringDate).HasColumnType("date");

                entity.Property(e => e.LastName).HasMaxLength(250);

                entity.Property(e => e.LastUpdatedByUserId).HasDefaultValueSql("((7))");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Longtitude).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.MainAccountingEmailAddress).HasMaxLength(250);

                entity.Property(e => e.MainAccountingFax).HasMaxLength(250);

                entity.Property(e => e.MainAccountingPhone).HasMaxLength(250);

                entity.Property(e => e.MainCompanyFax).HasMaxLength(250);

                entity.Property(e => e.MainCompanyPhone).HasMaxLength(250);

                entity.Property(e => e.MainEmailAddress).HasMaxLength(250);

                entity.Property(e => e.PreferedCommunicationMethod).HasDefaultValueSql("((1))");

                entity.Property(e => e.ProfitabilityRating).HasMaxLength(10);

                entity.Property(e => e.ProfitabilityRatingBasedOnJobs).HasMaxLength(10);

                entity.Property(e => e.Radius).HasDefaultValueSql("((20))");

                entity.Property(e => e.Ssn)
                    .HasColumnName("SSN")
                    .HasMaxLength(50);

                entity.Property(e => e.TaxId)
                    .HasColumnName("TaxID")
                    .HasMaxLength(50);

                entity.Property(e => e.Tinfin)
                    .HasColumnName("TINFIN")
                    .HasMaxLength(250);

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.ContractorAddress)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Contractor_Address");

                entity.HasOne(d => d.ShippingAddress)
                    .WithMany(p => p.ContractorShippingAddress)
                    .HasForeignKey(d => d.ShippingAddressId)
                    .HasConstraintName("FK_Contractor_Address1");
            });

            modelBuilder.Entity<ContractorAssignedZipCode>(entity =>
            {
                entity.Property(e => e.CreatedByUserId).HasDefaultValueSql("((7))");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdatedByUserId).HasDefaultValueSql("((7))");

                entity.Property(e => e.LastUpdatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Longtitude).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Priority).HasColumnName("priority");

                entity.Property(e => e.Radius).HasColumnName("radius");

                entity.Property(e => e.ZipCode)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.ContractorAssignedZipCode)
                    .HasForeignKey(d => d.ContractorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContractorAssignedZipCode_Contractor");
            });

            modelBuilder.Entity<ContractorCreditHistory>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(200);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Credits)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Terms)
                    .IsRequired()
                    .HasMaxLength(300);

                entity.Property(e => e.UpdatedBy).HasMaxLength(200);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ContractorDetail>(entity =>
            {
                entity.Property(e => e.AfterHoursCharges).HasColumnType("money");

                entity.Property(e => e.AfterHoursLaborRate).HasColumnType("money");

                entity.Property(e => e.AutomobileInsuranceExpiryDate).HasColumnType("date");

                entity.Property(e => e.AutomobileInsuranceLimits).HasMaxLength(500);

                entity.Property(e => e.AutomobileInsurancePolicyNumber).HasMaxLength(250);

                entity.Property(e => e.DateOfBirth).HasColumnType("date");

                entity.Property(e => e.DoorAfterHoursCharges).HasColumnType("money");

                entity.Property(e => e.DoorAfterHoursLaborRate).HasColumnType("money");

                entity.Property(e => e.DoorHourlyLaborRate).HasColumnType("money");

                entity.Property(e => e.DoorServiceCallCharges).HasColumnType("money");

                entity.Property(e => e.DuplicatesCharges).HasColumnType("money");

                entity.Property(e => e.ExcessLiabilityExpiryDate).HasColumnType("date");

                entity.Property(e => e.ExcessLiabilityLimits).HasMaxLength(500);

                entity.Property(e => e.ExcessLiabilityPolicyNumber).HasMaxLength(250);

                entity.Property(e => e.GeneralLiabilityExpiryDate).HasColumnType("date");

                entity.Property(e => e.GeneralLiabilityLimits).HasMaxLength(500);

                entity.Property(e => e.GeneralLiabilityPolicyNumber).HasMaxLength(250);

                entity.Property(e => e.HourlyLaborRate).HasColumnType("money");

                entity.Property(e => e.InsuranceExpirationDate).HasColumnType("date");

                entity.Property(e => e.InsuranceNumber).HasMaxLength(250);

                entity.Property(e => e.LaborCharges).HasColumnType("money");

                entity.Property(e => e.LicenseExpirationDate).HasColumnType("date");

                entity.Property(e => e.LicenseNumber).HasMaxLength(250);

                entity.Property(e => e.OtherLiabilityCarrierName).HasMaxLength(500);

                entity.Property(e => e.OtherLiabilityExpiryDate).HasColumnType("date");

                entity.Property(e => e.OtherLiabilityLimits).HasMaxLength(500);

                entity.Property(e => e.OtherLiabilityPolicyNumber).HasMaxLength(250);

                entity.Property(e => e.RekeyCharges).HasColumnType("money");

                entity.Property(e => e.RemoveInstallHerculiteDoorCharges).HasColumnType("money");

                entity.Property(e => e.SafesAfterHoursCharges).HasColumnType("money");

                entity.Property(e => e.SafesAfterHoursLaborRate).HasColumnType("money");

                entity.Property(e => e.SafesComboChangeCharges).HasColumnType("money");

                entity.Property(e => e.SafesHourlyLaborRate).HasColumnType("money");

                entity.Property(e => e.SafesOpeningCharges).HasColumnType("money");

                entity.Property(e => e.SafesServiceCallCharges).HasColumnType("money");

                entity.Property(e => e.ServiceCallCharges).HasColumnType("money");

                entity.Property(e => e.TripCharges).HasColumnType("money");

                entity.Property(e => e.WorkmanCompInsuranceExpiryDate).HasColumnType("date");

                entity.Property(e => e.WorkmanCompInsuranceLimits).HasMaxLength(500);

                entity.Property(e => e.WorkmanCompInsurancePolicyNumber).HasMaxLength(250);

                entity.HasOne(d => d.Contactor)
                    .WithMany(p => p.ContractorDetail)
                    .HasForeignKey(d => d.ContactorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContractorDetail_Contractor");
            });

            modelBuilder.Entity<ContractorNote>(entity =>
            {
                entity.HasIndex(e => new { e.Notes, e.CreatedOn, e.ContractorId, e.UserId })
                    .HasName("_dta_index_ContractorNote_6_1286295642__K3_K2_4_5");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Notes).HasColumnType("nvarchar(max)");

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.ContractorNote)
                    .HasForeignKey(d => d.ContractorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContractorNote_Contractor");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ContractorNote)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContractorNote_User");
            });

            modelBuilder.Entity<ContractorRatings>(entity =>
            {
                entity.Property(e => e.Date).HasColumnType("datetime");

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.ContractorRatings)
                    .HasForeignKey(d => d.ContractorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContractorRatings_Contractor");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.ContractorRatings)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ContractorRatings_User");
            });

            modelBuilder.Entity<Country>(entity =>
            {
                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.ThreeLetterIsoCode).HasMaxLength(3);

                entity.Property(e => e.TwoLetterIsoCode).HasMaxLength(2);
            });

            modelBuilder.Entity<County>(entity =>
            {
                entity.Property(e => e.CountryId).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.County)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_County_Country");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.County)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_County_State");
            });

            modelBuilder.Entity<CreditCard>(entity =>
            {
                entity.Property(e => e.AddressOnCard).HasMaxLength(50);

                entity.Property(e => e.CardCity).HasMaxLength(150);

                entity.Property(e => e.CardNotes).HasMaxLength(100);

                entity.Property(e => e.CardNumber).HasMaxLength(1000);

                entity.Property(e => e.CardZip).HasMaxLength(50);

                entity.Property(e => e.CreditCardExpireMonth).HasMaxLength(50);

                entity.Property(e => e.CreditCardExpireYear).HasMaxLength(50);

                entity.Property(e => e.CreditCardType).HasMaxLength(250);

                entity.Property(e => e.Crvnumber)
                    .HasColumnName("CRVNumber")
                    .HasMaxLength(1000);

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.NameOnCard).HasMaxLength(50);

                entity.Property(e => e.Password).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CreditCard)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_CreditCard_Customer");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.CreditCard)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_CreditCard_State");
            });

            modelBuilder.Entity<Customer>(entity =>
            {
                entity.HasIndex(e => new { e.FirstName, e.LastName, e.Id })
                    .HasName("_dta_index_Customer_8_389576426__K1_5_6");

                entity.HasIndex(e => new { e.FirstName, e.LastName, e.MiddleName, e.Id, e.CustomerType })
                    .HasName("_dta_index_Customer_8_389576426__K1_K8_5_6_7");
                entity.Property(e => e.Amemail).HasColumnName("AMEmail");

                entity.Property(e => e.AmfirstName).HasColumnName("AMFirstName");

                entity.Property(e => e.AmlastName).HasColumnName("AMLastName");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreditWorthy)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.CustomerGuid).HasDefaultValueSql("(newid())");

                entity.Property(e => e.CustomerRepresentative).HasMaxLength(50);

                entity.Property(e => e.DiscountOnParts).HasColumnType("money");

                entity.Property(e => e.Email).HasMaxLength(250);

                entity.Property(e => e.FirstName).HasColumnType("nvarchar(max)");

                entity.Property(e => e.HourlyLabour).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.Ivrnumber)
                    .HasColumnName("IVRNumber")
                    .HasMaxLength(250);

                entity.Property(e => e.Ivrpin)
                    .HasColumnName("IVRPin")
                    .HasMaxLength(250);

                entity.Property(e => e.LastName).HasColumnType("nvarchar(max)");

                entity.Property(e => e.LastUpdateOn).HasColumnType("datetime");

                entity.Property(e => e.MarkupOnParts).HasColumnType("money");

                entity.Property(e => e.MiddleName).HasColumnType("nvarchar(max)");

                entity.Property(e => e.NotificationEmail).HasMaxLength(50);

                entity.Property(e => e.NotificationFirstName).HasMaxLength(50);

                entity.Property(e => e.NotificationLastName).HasMaxLength(50);

                entity.Property(e => e.NotificationTitle).HasMaxLength(50);

                entity.Property(e => e.NteAmount).HasColumnType("money");

                entity.Property(e => e.OtherEmail).HasMaxLength(200);

                entity.Property(e => e.Salutation).HasMaxLength(50);

                entity.Property(e => e.TaxExemptNumber).HasMaxLength(250);

                entity.Property(e => e.TripCharges).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.WebSite).HasMaxLength(250);
            });

            modelBuilder.Entity<CustomerSelectedPackages>(entity =>
            {
                entity.HasKey(e => e.SelectedPackageId);

                entity.Property(e => e.SelectedPackageId).HasColumnName("SelectedPackageID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.DateOfSale).HasColumnType("datetime");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.Message)
                    .IsRequired()
                    .IsUnicode(false);

                entity.Property(e => e.PackageFeeRepeat)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.PackageId).HasColumnName("PackageID");

                entity.Property(e => e.PaymentsDate).IsUnicode(false);

                entity.Property(e => e.TypeOfService)
                    .IsRequired()
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.VisitsDate).IsUnicode(false);
            });

            modelBuilder.Entity<CustomerStateMapping>(entity =>
            {
                entity.HasKey(e => new { e.CustomerId, e.StateId });

                entity.ToTable("Customer_State_Mapping");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.CustomerStateMapping)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_State_Mapping_Customer");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.CustomerStateMapping)
                    .HasForeignKey(d => d.StateId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Customer_State_Mapping_State");
            });

            modelBuilder.Entity<DailyBoardStats>(entity =>
            {
                entity.HasIndex(e => new { e.JobsInLateAfternoon, e.JobsInMorning, e.JobsInNoon, e.Threshold, e.JobType, e.StatusId, e.CreatedOn })
                    .HasName("nci_wi_DailyBoardStats_2BF9D885ABDBCB358C98D5EF21F76E69");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.JobType).HasMaxLength(50);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Status)
                    .WithMany(p => p.DailyBoardStats)
                    .HasForeignKey(d => d.StatusId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_DailyBoardStats_JobStatus");
            });

            modelBuilder.Entity<Device>(entity =>
            {
                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.IsTestFlight).HasColumnName("isTestFlight");

                entity.Property(e => e.LastUpdatedOn).HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Token).IsRequired();

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.ContractorId)
                    .HasConstraintName("FK_Device_Contractor");

                entity.HasOne(d => d.Technician)
                    .WithMany(p => p.Device)
                    .HasForeignKey(d => d.TechnicianId)
                    .HasConstraintName("FK_Device_Technicians");
            });

            modelBuilder.Entity<Discrepancies>(entity =>
            {
                entity.Property(e => e.CreatedBy).HasMaxLength(250);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Type).HasMaxLength(250);

                entity.Property(e => e.TypeName).HasMaxLength(50);

                entity.Property(e => e.UpdatedBy).HasMaxLength(250);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<DiscrepanciesList>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(50);
            });

            modelBuilder.Entity<Document>(entity =>
            {
                entity.HasIndex(e => e.JobId)
                    .HasName("nci_wi_Document_E7FA8F6957723E1BBFB8F44279441C92");

                entity.HasIndex(e => new { e.Type, e.JobId })
                    .HasName("nci_wi_Document_89EDF7F53E0C9B5A92DA9A9924E68B11");

                entity.HasIndex(e => new { e.ContractorDocumentType, e.CreatedByUserId, e.CreatedOn, e.CustomerId, e.Descritption, e.JobId, e.LastUpdateByUserId, e.LastUpdateOn, e.Name, e.Path, e.Type, e.ContractorId })
                    .HasName("nci_wi_Document_FE4680F5C98351D98DBE1827843D0991");

                entity.HasIndex(e => new { e.AzureUploaded, e.ContractorDocumentType, e.CreatedByUserId, e.CreatedOn, e.CustomerId, e.Descritption, e.DocumentVerified, e.ExpiryDate, e.IfExists, e.JobId, e.LastUpdateByUserId, e.LastUpdateOn, e.Name, e.Path, e.Type, e.ContractorId })
                    .HasName("nci_wi_Document_0A3AF290DCFE6C4140839524E47C28F9");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Descritption).HasColumnType("nvarchar(max)");

                entity.Property(e => e.ExpiryDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateOn).HasColumnType("datetime");

                entity.Property(e => e.LicenseNumber).HasMaxLength(250);

                entity.Property(e => e.MeetingMinimumRequiremenmt)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Path).HasColumnType("nvarchar(max)");

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.ContractorId)
                    .HasConstraintName("FK_Document_Contractor");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Document_Customer");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Document)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_FileBox_Job");
            });

            modelBuilder.Entity<EmailLog>(entity =>
            {
                entity.HasKey(e => e.LogId);

                entity.Property(e => e.LogId).HasColumnName("LogID");

                entity.Property(e => e.Bcc).HasColumnName("BCC");

                entity.Property(e => e.Body).IsUnicode(false);

                entity.Property(e => e.Cc)
                    .HasColumnName("CC")
                    .IsUnicode(false);

                entity.Property(e => e.ContractorId).HasColumnName("ContractorID");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.MailedOn).HasColumnType("datetime");

                entity.Property(e => e.MailedTo).IsUnicode(false);

                entity.Property(e => e.Subject)
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.EmailLog)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_EmailLog_Customer");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.EmailLog)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_EmailLog_Job");

                entity.HasOne(d => d.MailedFromNavigation)
                    .WithMany(p => p.EmailLog)
                    .HasForeignKey(d => d.MailedFrom)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EmailLog_User");
            });

            modelBuilder.Entity<Equipment>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.HasOne(d => d.Category)
                    .WithMany(p => p.Equipment)
                    .HasForeignKey(d => d.CategoryId)
                    .HasConstraintName("FK_Equipment_EquipmentCategory");
            });

            modelBuilder.Entity<EquipmentCategory>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(250);

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.EquipmentCategoryCreatedByUser)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentCategory_User");

                entity.HasOne(d => d.LastUpdatedByUser)
                    .WithMany(p => p.EquipmentCategoryLastUpdatedByUser)
                    .HasForeignKey(d => d.LastUpdatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_EquipmentCategory_User1");
            });

            modelBuilder.Entity<ErrorLog>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.IpAddress).HasMaxLength(200);
            });

            modelBuilder.Entity<HeadSheet>(entity =>
            {
                entity.Property(e => e.Amexamount)
                    .HasColumnName("AMEXAmount")
                    .HasColumnType("money");

                entity.Property(e => e.AverageAmount).HasColumnType("money");

                entity.Property(e => e.BillingAmount).HasColumnType("money");

                entity.Property(e => e.CashIn).HasColumnType("money");

                entity.Property(e => e.CashOut).HasColumnType("money");

                entity.Property(e => e.ChecksAmount).HasColumnType("money");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreditAmount).HasColumnType("money");

                entity.Property(e => e.DiscoverAmount).HasColumnType("money");

                entity.Property(e => e.ExcessCash).HasColumnType("money");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.McvisaAmount)
                    .HasColumnName("MCVisaAmount")
                    .HasColumnType("money");

                entity.Property(e => e.PartsUsed).HasColumnType("money");

                entity.Property(e => e.Taxes).HasColumnType("money");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.Property(e => e.TotalCash).HasColumnType("money");

                entity.HasOne(d => d.Contracor)
                    .WithMany(p => p.HeadSheet)
                    .HasForeignKey(d => d.ContracorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_HeadSheet_Contractor");
            });

            modelBuilder.Entity<Invoice>(entity =>
            {
                entity.HasIndex(e => e.JobId)
                    .HasName("nci_wi_Invoice_E7FA8F6957723E1BBFB8F44279441C92");

                entity.Property(e => e.CalculatedTotal).HasColumnType("money");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DueDate).HasColumnType("datetime");

                entity.Property(e => e.InvoiceInstruction).IsRequired();

                entity.Property(e => e.JobInvoiceNumber).HasMaxLength(150);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.PartsToBeReimbursed).HasColumnType("money");

                entity.Property(e => e.ReviewedOn).HasColumnType("datetime");

                entity.Property(e => e.Tax).HasColumnType("money");

                entity.HasOne(d => d.Address)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.AddressId)
                    .HasConstraintName("FK_Invoice_Address");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.InvoiceCreatedByUser)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_User");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Invoice)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_Job");

                entity.HasOne(d => d.LastUpdateByUser)
                    .WithMany(p => p.InvoiceLastUpdateByUser)
                    .HasForeignKey(d => d.LastUpdateByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Invoice_User1");
            });

            modelBuilder.Entity<InvoiceDetails>(entity =>
            {
                entity.HasIndex(e => new { e.Type, e.InvoiceId })
                    .HasName("_dta_index_InvoiceDetails_8_1653580929__K7_K2");

                entity.HasIndex(e => new { e.Price, e.Quantity, e.InvoiceId })
                    .HasName("_dta_index_InvoiceDetails_8_1653580929__K2_4_5");

                entity.HasIndex(e => new { e.Price, e.Quantity, e.InvoiceId, e.Type })
                    .HasName("_dta_index_InvoiceDetails_8_1653580929__K2_K7_4_5");

                entity.HasIndex(e => new { e.Price, e.Quantity, e.Type, e.InvoiceId })
                    .HasName("_dta_index_InvoiceDetails_8_1653580929__K7_K2_4_5");

                entity.HasIndex(e => new { e.Description, e.Price, e.Quantity, e.InvoiceId, e.Type })
                    .HasName("nci_wi_InvoiceDetails_11DDC1851A972EC01E2842690C77F7BD");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("nvarchar(max)");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Quantity).HasColumnType("money");

                entity.Property(e => e.ShippingCharges).HasColumnType("money");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.InvoiceDetailsCreatedByUser)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceDetails_User1");

                entity.HasOne(d => d.Invoice)
                    .WithMany(p => p.InvoiceDetails)
                    .HasForeignKey(d => d.InvoiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceDetails_Invoice");

                entity.HasOne(d => d.LastUpdatedByUserd)
                    .WithMany(p => p.InvoiceDetailsLastUpdatedByUserd)
                    .HasForeignKey(d => d.LastUpdatedByUserdId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_InvoiceDetails_User");
            });

            modelBuilder.Entity<InvoiceServices>(entity =>
            {
                entity.Property(e => e.AddedFromTruck).HasColumnName("addedFromTruck");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Discount).HasColumnType("decimal(18, 0)");

                entity.Property(e => e.IsDeleted).HasColumnName("isDeleted");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });
            modelBuilder.Entity<Job>(entity =>
            {
                entity.HasIndex(e => e.CustomerId)
                    .HasName("nci_wi_Job_4E23AA7C65E80F08C82B3BB9EE1BEB65");

                entity.HasIndex(e => new { e.StoreId, e.CreatedOn })
                    .HasName("nci_wi_Job_EA148D007FFE214111E219C19EB5FE02");

                entity.HasIndex(e => new { e.CreatedOn, e.CreatedByUserId, e.JobTypeId, e.Id, e.CustomerId })
                    .HasName("_dta_index_Job_6_668581470__K3_K1_K2_51_52");

                entity.HasIndex(e => new { e.City, e.CreatedOn, e.CustomerId, e.JobStatusId, e.StateId, e.StoreId, e.OnDate })
                    .HasName("nci_wi_Job_94E05C2A01816D7746ECE4DB8F1E7562");

                entity.HasIndex(e => new { e.City, e.IsEmergency, e.CreatedOn, e.StateId, e.Id, e.CustomerId, e.EquipmentId })
                    .HasName("_dta_index_Job_8_1221579390__K10_K1_K2_K8_21_43_51");

                entity.HasIndex(e => new { e.IsAuto, e.Ponumber, e.Phone, e.FromTime, e.ToTime, e.DispatchedTime, e.Description, e.IsEmergency, e.CreatedOn, e.Address, e.City, e.DateIntervalType, e.JobStatusId, e.Id, e.CustomerId, e.EquipmentId, e.StateId, e.Locked, e.OnDate, e.JobTypeId, e.StoreId })
                    .HasName("_dta_index_Job_6_668581470__K9_K1_K2_K8_K10_K55_K34_K3_K6_15_16_18_20_21_33_35_36_37_42_43_51");

                entity.HasIndex(e => new { e.Ponumber, e.Phone, e.Address, e.DateIntervalType, e.OnDate, e.FromTime, e.ToTime, e.DispatchedTime, e.IsAuto, e.Description, e.IsEmergency, e.CreatedOn, e.City, e.JobStatusId, e.JobTypeId, e.Locked, e.StateId, e.CustomerId, e.EquipmentId, e.Id, e.StoreId })
                    .HasName("_dta_index_Job_6_668581470__K9_K3_K55_K10_K2_K8_K1_K6_15_16_18_20_21_33_34_35_36_37_42_43_51");

                entity.HasIndex(e => new { e.Description, e.IsEmergency, e.CreatedOn, e.Locked, e.City, e.DateIntervalType, e.OnDate, e.FromTime, e.ToTime, e.DispatchedTime, e.JobTypeId, e.IsAuto, e.Ponumber, e.WorkOrder2, e.Phone, e.Address, e.CustomerId, e.EquipmentId, e.StateId, e.JobStatusId, e.Id, e.StoreId })
                    .HasName("_dta_index_Job_8_1221579390__K2_K8_K10_K9_K1_K6_3_15_16_17_18_20_21_33_34_35_36_37_42_43_51_55");

                entity.HasIndex(e => new { e.FromTime, e.DispatchedTime, e.TaxExempt, e.AdTypeOtherOption, e.AdTypeWebSource, e.Fax, e.EmailAddress, e.CalledInBy, e.Nteamount, e.DateIntervalType, e.OnDate, e.IsAuto, e.Ponumber, e.WorkOrder2, e.Phone, e.Address, e.City, e.JobTypeId, e.CreatedOn, e.CreatedByUserId, e.CountryId, e.StateId, e.EquipmentId, e.JobStatusId, e.AdTypeId, e.Id, e.CustomerId, e.StoreId, e.ZipCode })
                    .HasName("_dta_index_Job_8_1221579390__K3_K51_K52_K11_K10_K8_K9_K7_K1_K2_K6_K14_15_16_17_18_20_21_26_27_28_32_33_34_35_37_49_56_57");

                entity.HasIndex(e => new { e.FromTime, e.DispatchedTime, e.Description, e.TaxExempt, e.AdTypeOtherOption, e.AdTypeWebSource, e.Fax, e.EmailAddress, e.CalledInBy, e.Nteamount, e.DateIntervalType, e.OnDate, e.IsAuto, e.Ponumber, e.WorkOrder2, e.Phone, e.Address, e.City, e.JobTypeId, e.CreatedOn, e.Id, e.ZipCode, e.StoreId, e.CustomerId, e.CreatedByUserId, e.CountryId, e.StateId, e.EquipmentId, e.JobStatusId, e.AdTypeId })
                    .HasName("_dta_index_Job_8_1221579390__K3_K51_K1_K14_K6_K2_K52_K11_K10_K8_K9_K7_15_16_17_18_20_21_26_27_28_32_33_34_35_37_42_49_56_57");

                entity.HasIndex(e => new { e.CustomerId, e.JobTypeId, e.BillingAddressId, e.StateId, e.CountryId, e.Ponumber, e.WorkOrder2, e.PaymentMethodId, e.StoreId, e.AdTypeId, e.EquipmentId, e.Street, e.ApartmentSuite, e.CountyId, e.AddressTypeId, e.ZipCode, e.IsAuto, e.CalledInBy, e.ContactPerson, e.Phone, e.AlternatePhone, e.Address, e.City, e.OnDate, e.FromTime, e.BookedByUserId, e.BuzzerCode, e.Fax, e.EmailAddress, e.Model, e.Color, e.ContactPersonPhone, e.ContactPersonEmail, e.Nteamount, e.DateIntervalType, e.EstimatePrinted, e.EstimateEmailed, e.ToTime, e.DispatchedTime, e.Year, e.Make, e.LastUpdateOn, e.LastUpdatedByUserId, e.Description, e.IsEmergency, e.Ask, e.Notes, e.Latitude, e.Longtitude, e.IsCow, e.TaxExempt, e.IsBillingSameAsServiceAddress, e.CreatedByUserId, e.NotificationEmail, e.UpdateOnCreated, e.Locked, e.AdTypeOtherOption, e.AdTypeWebSource, e.AlertedOniPhone, e.UpdateOnCompleted, e.OtherEmail, e.FormOfPayment, e.TimeZone, e.PreferredCommunicationMethodEmail, e.NotificationFirstName, e.JobStatusId, e.Id, e.CreatedOn })
                    .HasName("_dta_index_Job_6_668581470__K9_K1_K51_2_3_4_5_6_7_8_10_11_12_13_14_15_16_17_18_19_20_21_22_23_24_25_26_27_28_29_30_31_32_33_34_");

                entity.Property(e => e.Id).ValueGeneratedNever();

                entity.Property(e => e.AdTypeOtherOption).HasColumnType("nvarchar(max)");

                entity.Property(e => e.AdTypeWebSource).HasColumnType("nvarchar(max)");

                entity.Property(e => e.Address).HasColumnType("nvarchar(max)");

                entity.Property(e => e.AlternatePhone).HasMaxLength(50);

                entity.Property(e => e.ApartmentSuite).HasMaxLength(250);

                entity.Property(e => e.Ask).HasMaxLength(50);

                entity.Property(e => e.BubbleHeight)
                    .HasColumnName("bubbleHeight")
                    .HasMaxLength(50);

                entity.Property(e => e.BuzzerCode).HasMaxLength(50);

                entity.Property(e => e.CalledInBy).HasMaxLength(250);

                entity.Property(e => e.City).HasMaxLength(250);

                entity.Property(e => e.Color).HasMaxLength(250);

                entity.Property(e => e.ContactPerson).HasMaxLength(250);

                entity.Property(e => e.ContactPersonEmail).HasMaxLength(250);

                entity.Property(e => e.ContactPersonPhone).HasMaxLength(50);

                entity.Property(e => e.CountryId).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasColumnType("nvarchar(max)");

                entity.Property(e => e.DispatchedTime).HasColumnType("datetime");

                entity.Property(e => e.EmailAddress).HasMaxLength(250);

                entity.Property(e => e.Fax).HasMaxLength(50);

                entity.Property(e => e.FormOfPayment).HasDefaultValueSql("((1))");

                entity.Property(e => e.InvoiceRecieved).HasColumnType("datetime");

                entity.Property(e => e.IsCow).HasColumnName("IsCOW");

                entity.Property(e => e.IsEmergency).HasDefaultValueSql("((0))");

                entity.Property(e => e.LastUpdateOn).HasColumnType("datetime");

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.LinkJobId)
                    .HasColumnName("LinkJobID")
                    .HasMaxLength(50);

                entity.Property(e => e.Longtitude).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Make).HasMaxLength(250);

                entity.Property(e => e.Model).HasMaxLength(250);

                entity.Property(e => e.Notes).HasColumnType("nvarchar(max)");

                entity.Property(e => e.NotificationEmail).HasMaxLength(50);

                entity.Property(e => e.NotificationFirstName).HasMaxLength(50);

                entity.Property(e => e.NotificationLastName).HasMaxLength(50);

                entity.Property(e => e.NotificationTitle).HasMaxLength(50);

                entity.Property(e => e.Nteamount)
                    .HasColumnName("NTEAmount")
                    .HasColumnType("money");

                entity.Property(e => e.OnDate).HasColumnType("date");

                entity.Property(e => e.OtherEmail).HasMaxLength(200);

                entity.Property(e => e.OtherFirstName).HasMaxLength(50);

                entity.Property(e => e.OtherLastName).HasMaxLength(50);

                entity.Property(e => e.OtherTitle).HasMaxLength(50);

                entity.Property(e => e.Phone).HasMaxLength(50);

                entity.Property(e => e.Ponumber)
                    .HasColumnName("PONumber")
                    .HasMaxLength(50);

                entity.Property(e => e.ProjectId).HasColumnName("projectId");

                entity.Property(e => e.Street).HasMaxLength(250);

                entity.Property(e => e.TimeZone).HasMaxLength(250);

                entity.Property(e => e.WorkOrder2).HasMaxLength(50);

                entity.Property(e => e.ZipCode).HasMaxLength(50);

                entity.HasOne(d => d.AdType)
                    .WithMany(p => p.JobAdType)
                    .HasForeignKey(d => d.AdTypeId)
                    .HasConstraintName("FK_Job_Abbreviation");

                entity.HasOne(d => d.BillingAddress)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.BillingAddressId)
                    .HasConstraintName("FK_Job_Address");

                entity.HasOne(d => d.BookedByUser)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.BookedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_User");

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.CountryId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_Country");

                entity.HasOne(d => d.County)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.CountyId)
                    .HasConstraintName("FK_Job_County");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_Customer");

                entity.HasOne(d => d.Equipment)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.EquipmentId)
                    .HasConstraintName("FK_Job_Equipment");

                entity.HasOne(d => d.JobStatus)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.JobStatusId)
                    .HasConstraintName("FK_Job_JobStatus");

                entity.HasOne(d => d.JobType)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.JobTypeId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_JobType");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.JobPaymentMethod)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_PaymentMethod");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Job_State");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.Job)
                    .HasForeignKey(d => d.StoreId)
                    .HasConstraintName("FK_Job_Store");
            });

            modelBuilder.Entity<JobAlarms>(entity =>
            {
                entity.HasKey(e => e.JobAlarmId);

                entity.Property(e => e.AlarmTime).HasColumnType("datetime");

                entity.Property(e => e.CreatedDate).HasColumnType("datetime");

                entity.Property(e => e.Pending)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<JobContractorMapping>(entity =>
            {
                entity.HasIndex(e => new { e.BillingEstimate, e.JobId })
                    .HasName("_dta_index_JobContractorMapping_8_1509580416__K3_35");

                entity.HasIndex(e => new { e.ContractorId, e.JobId })
                    .HasName("_dta_index_JobContractorMapping_6_16055143__K3_2");

                entity.HasIndex(e => new { e.JobMargin, e.JobId })
                    .HasName("_dta_index_JobContractorMapping_8_1509580416__K3_36");

                entity.HasIndex(e => new { e.SubContractorId, e.JobId })
                    .HasName("_dta_index_JobContractorMapping_8_1509580416__K3_4");

                entity.HasIndex(e => new { e.ContractorId, e.SubContractorId, e.JobId })
                    .HasName("_dta_index_JobContractorMapping_8_1509580416__K3_2_4");

                entity.HasIndex(e => new { e.JobId, e.SubContractorId, e.Nteamount })
                    .HasName("_dta_index_JobContractorMapping_8_1509580416__K3_K4_K6");

                entity.HasIndex(e => new { e.SubContractorId, e.JobId, e.Nteamount })
                    .HasName("_dta_index_JobContractorMapping_8_1509580416__K4_K3_K6");

                entity.HasIndex(e => new { e.ContractorId, e.JobId, e.Nteamount, e.SubContractorId })
                    .HasName("nci_wi_JobContractorMapping_B6850916C7495B957DD6795F68F46E4A");

                entity.HasIndex(e => new { e.AcceptanceDate, e.AcceptedBy, e.CauseOfDamage, e.Commission, e.CreatedByUserId, e.CreatedOn, e.CustomerComments, e.CustomerInvoiceNo, e.Eta, e.Id, e.IPhoneReceiptNo, e.IsPrimary, e.JobContractorEta, e.JobId, e.LastUpdatedByUserId, e.LastUpdatedOn, e.NoticeForm, e.Nteamount, e.PaymentPreference, e.PrepaidAmount, e.PrepaidAmountCreatedByUserId, e.PrepaidAmountPaidOn, e.PrintName, e.SignaturePath, e.SubContractorId, e.TaxAmount, e.Title, e.WorkPerformed, e.ContractorId })
                    .HasName("nci_wi_JobContractorMapping_C072EC92F6576E28F1B48BAAEF4EEC7D");

                entity.HasIndex(e => new { e.AcceptanceDate, e.AcceptedBy, e.CauseOfDamage, e.CheckInTime, e.CheckOutTime, e.Commission, e.ContactPerson, e.CreatedByUserId, e.CreatedOn, e.CustomerComments, e.CustomerInvoiceNo, e.Eta, e.InitialInvoice, e.InitialNteamount, e.IPhoneReceiptNo, e.IsPrimary, e.JobContractorEta, e.JobId, e.LastUpdatedByUserId, e.LastUpdatedOn, e.NoticeForm, e.Nteamount, e.PaymentPreference, e.PrepaidAmount, e.PrepaidAmountCreatedByUserId, e.PrepaidAmountPaidOn, e.PrintName, e.SignaturePath, e.SubContractorId, e.TaxAmount, e.Title, e.WorkPerformed, e.ContractorId })
                    .HasName("nci_wi_JobContractorMapping_03FF101F38FA26286615F1AA5E1A7C98");

                entity.Property(e => e.AcceptanceDate).HasColumnType("datetime");

                entity.Property(e => e.AcceptedBy).HasColumnType("nvarchar(max)");

                entity.Property(e => e.BillingEstimate).HasColumnType("money");

                entity.Property(e => e.CauseOfDamage).HasColumnType("nvarchar(max)");

                entity.Property(e => e.CheckInTime).HasColumnType("datetime");

                entity.Property(e => e.CheckOutTime).HasColumnType("datetime");

                entity.Property(e => e.ContactPerson).HasColumnType("nvarchar(max)");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CustomerComments).HasColumnType("nvarchar(max)");

                entity.Property(e => e.CustomerInvoiceNo).HasMaxLength(250);

                entity.Property(e => e.Eta)
                    .HasColumnName("ETA")
                    .HasMaxLength(50);

                entity.Property(e => e.IPhoneReceiptNo)
                    .HasColumnName("iPhoneReceiptNo")
                    .HasMaxLength(250);

                entity.Property(e => e.InitialNteamount)
                    .HasColumnName("InitialNTEAmount")
                    .HasColumnType("money");

                entity.Property(e => e.JobContractorEta)
                    .HasColumnName("JobContractorETA")
                    .HasMaxLength(200);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.NteChangeReason).HasColumnName("nteChangeReason");
                entity.Property(e => e.vwJobsId);

                entity.Property(e => e.Nteamount)
                    .HasColumnName("NTEAmount")
                    .HasColumnType("money");

                entity.Property(e => e.PrepaidAmount).HasColumnType("money");

                entity.Property(e => e.PrepaidAmountCreatedByUserId).HasColumnName("PrepaidAmountCreatedByUserID");

                entity.Property(e => e.PrepaidAmountPaidOn).HasColumnType("datetime");

                entity.Property(e => e.PrintName).HasColumnType("nvarchar(max)");

                entity.Property(e => e.SignaturePath).HasColumnType("nvarchar(max)");

                entity.Property(e => e.TaxAmount).HasColumnType("money");

                entity.Property(e => e.Title).HasColumnType("nvarchar(max)");

                entity.Property(e => e.WorkPerformed).HasColumnType("nvarchar(max)");

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.JobContractorMapping)
                    .HasForeignKey(d => d.ContractorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobContractorMapping_Contractor");
                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobContractorMapping)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobContractorMapping_Job");

                entity.HasOne(d => d.SubContractor)
                    .WithMany(p => p.JobContractorMapping)
                    .HasForeignKey(d => d.SubContractorId)
                    .HasConstraintName("FK_JobContractorMapping_Technicians");
            });

            modelBuilder.Entity<JobLog>(entity =>
            {
                entity.HasIndex(e => new { e.JobId, e.TimeStamp })
                    .HasName("_dta_index_JobLog_6_1394820031__K3_K5");

                entity.HasIndex(e => new { e.Id, e.NewStatus, e.JobId })
                    .HasName("_dta_index_JobLog_8_34099162__K8_K3_1");

                entity.HasIndex(e => new { e.JobId, e.NewStatus, e.TimeStamp })
                    .HasName("_dta_index_JobLog_8_34099162__K3_K8_K5");

                entity.HasIndex(e => new { e.Id, e.UserId, e.TimeStamp, e.JobId })
                    .HasName("_dta_index_JobLog_8_34099162__K5_K3_1_2");

                entity.HasIndex(e => new { e.JobId, e.TimeStamp, e.Id, e.PrevStatus, e.NewStatus })
                    .HasName("_dta_index_JobLog_8_34099162__K3_K5_K1_K7_K8");

                entity.HasIndex(e => new { e.TimeStamp, e.NewStatus, e.PrevStatus, e.JobId, e.UserId })
                    .HasName("_dta_index_JobLog_6_1394820031__K7_K3_K2_5_8");

                entity.HasIndex(e => new { e.JobId, e.LogMessage, e.NewStatus, e.TimeStamp, e.UserId, e.PrevStatus })
                    .HasName("nci_wi_JobLog_8F4601298D0FF1154ACE0D673032DA80");

                entity.Property(e => e.LogMessage)
                    .IsRequired()
                    .HasColumnType("nvarchar(max)");

                entity.Property(e => e.TimeStamp).HasColumnType("datetime");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobLog)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobLog_Job");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.JobLog)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobLog_User");
            });

            modelBuilder.Entity<JobNotes>(entity =>
            {
                entity.HasIndex(e => new { e.JobId, e.CreatedOn })
                    .HasName("nci_wi_JobNotes_764918B218BA2BA2C6CA7F56F3C90177");

                entity.Property(e => e.CreatedFromiPhone).HasColumnName("createdFromiPhone");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LasteUpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.JobNotesCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .HasConstraintName("FK_JobNotes_User");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobNotes)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobNotes_Job");

                entity.HasOne(d => d.LasdUpdatedByNavigation)
                    .WithMany(p => p.JobNotesLasdUpdatedByNavigation)
                    .HasForeignKey(d => d.LasdUpdatedBy)
                    .HasConstraintName("FK_JobNotes_User1");
            });

            modelBuilder.Entity<JobPart>(entity =>
            {
                entity.ToTable("Job_Part");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.LaborCost).HasColumnType("money");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Markup).HasColumnType("money");

                entity.Property(e => e.Quantity).HasColumnType("money");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobPart)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Job_Part_Job");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.JobPart)
                    .HasForeignKey(d => d.PartId)
                    .HasConstraintName("FK_Job_Part_Part");
            });

            modelBuilder.Entity<JobPayment>(entity =>
            {
                entity.Property(e => e.AmountPaid).HasColumnType("money");

                entity.Property(e => e.AuthorizationTransactionCode).HasMaxLength(4000);

                entity.Property(e => e.AuthorizationTransactionId)
                    .HasColumnName("AuthorizationTransactionID")
                    .HasMaxLength(4000);

                entity.Property(e => e.AuthorizationTransactionResult).HasMaxLength(4000);

                entity.Property(e => e.BillingAddress1).HasMaxLength(100);

                entity.Property(e => e.BillingAddress2).HasMaxLength(100);

                entity.Property(e => e.BillingCity).HasMaxLength(100);

                entity.Property(e => e.BillingCompany).HasMaxLength(100);

                entity.Property(e => e.BillingCountryId).HasColumnName("BillingCountryID");

                entity.Property(e => e.BillingEmail).HasMaxLength(255);

                entity.Property(e => e.BillingFaxNumber).HasMaxLength(50);

                entity.Property(e => e.BillingFirstName).HasMaxLength(100);

                entity.Property(e => e.BillingLastName).HasMaxLength(100);

                entity.Property(e => e.BillingPhoneNumber).HasMaxLength(50);

                entity.Property(e => e.BillingStateProvinceId).HasColumnName("BillingStateProvinceID");

                entity.Property(e => e.BillingUnit).HasMaxLength(20);

                entity.Property(e => e.BillingZipCode).HasMaxLength(30);

                entity.Property(e => e.CaptureTransactionId)
                    .HasColumnName("CaptureTransactionID")
                    .HasMaxLength(4000);

                entity.Property(e => e.CaptureTransactionResult).HasMaxLength(4000);

                entity.Property(e => e.CardId).HasColumnName("CardID");

                entity.Property(e => e.CheckNumber).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.PaidDate).HasColumnType("datetime");

                entity.Property(e => e.PaymentMethodId).HasColumnName("PaymentMethodID");

                entity.Property(e => e.ReceiptNumber).HasMaxLength(50);

                entity.Property(e => e.SubscriptionTransactionId)
                    .HasColumnName("SubscriptionTransactionID")
                    .HasMaxLength(4000);

                entity.HasOne(d => d.Card)
                    .WithMany(p => p.JobPayment)
                    .HasForeignKey(d => d.CardId)
                    .HasConstraintName("FK_JobPayment_CreditCard");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.JobPayment)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_JobPayment_Job");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.JobPayment)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK_JobPayment_PaymentMethod");
            });

            modelBuilder.Entity<JobStatus>(entity =>
            {
                entity.Property(e => e.BackgroundColorHex).HasMaxLength(50);

                entity.Property(e => e.BackgroundColorName).HasMaxLength(50);

                entity.Property(e => e.BackgroundColorRgb)
                    .HasColumnName("BackgroundColorRGB")
                    .HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FontColorHex).HasMaxLength(50);

                entity.Property(e => e.FontColorRgb)
                    .HasColumnName("FontColorRGB")
                    .HasMaxLength(50);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Published)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");
            });

            modelBuilder.Entity<JobType>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Type).IsRequired();
            });

            modelBuilder.Entity<ManagerSheet>(entity =>
            {
                entity.Property(e => e.FileName).IsRequired();

                entity.Property(e => e.LastUpdate).HasColumnType("datetime");

                entity.Property(e => e.Type).HasMaxLength(100);
            });

            modelBuilder.Entity<MobileNotification>(entity =>
            {
                entity.HasIndex(e => e.JobId)
                    .HasName("nci_wi_MobileNotification_E7FA8F6957723E1BBFB8F44279441C92");

                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastUpdatedOn).HasDefaultValueSql("(getdate())");

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.MobileNotification)
                    .HasForeignKey(d => d.ContractorId)
                    .HasConstraintName("FK_MobileNotification_Contractor");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.MobileNotificationCreatedByUser)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .HasConstraintName("FK_MobileNotification_User1");

                entity.HasOne(d => d.Device)
                    .WithMany(p => p.MobileNotification)
                    .HasForeignKey(d => d.DeviceId)
                    .HasConstraintName("FK_MobileNotification_Device");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.MobileNotification)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_MobileNotification_Job");

                entity.HasOne(d => d.LastUpdatedByUser)
                    .WithMany(p => p.MobileNotificationLastUpdatedByUser)
                    .HasForeignKey(d => d.LastUpdatedByUserId)
                    .HasConstraintName("FK_MobileNotification_User");

                entity.HasOne(d => d.Technician)
                    .WithMany(p => p.MobileNotification)
                    .HasForeignKey(d => d.TechnicianId)
                    .HasConstraintName("FK_MobileNotification_Technicians");
            });

            modelBuilder.Entity<OauthTokens>(entity =>
            {
                entity.ToTable("OAuthTokens");

                entity.Property(e => e.Type).HasMaxLength(200);
            });

            modelBuilder.Entity<PackagePriority>(entity =>
            {
                entity.HasKey(e => e.PriorityId);

                entity.Property(e => e.PriorityId).HasColumnName("PriorityID");

                entity.Property(e => e.No)
                    .HasColumnName("NO")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.PackageId).HasColumnName("PackageID");

                entity.Property(e => e.PriorityName)
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.Property(e => e.Yes)
                    .HasColumnName("YES")
                    .HasMaxLength(200)
                    .IsUnicode(false);

                entity.HasOne(d => d.Package)
                    .WithMany(p => p.PackagePriority)
                    .HasForeignKey(d => d.PackageId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PackagePriority_CompanyPackages");
            });

            modelBuilder.Entity<Part>(entity =>
            {
                entity.Property(e => e.PartId).HasColumnName("PartID");

                entity.Property(e => e.Apta)
                    .HasColumnName("APTA")
                    .HasColumnType("money");

                entity.Property(e => e.Baseline).HasColumnType("money");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.EcommercePricing).HasColumnType("money");

                entity.Property(e => e.HotNo).HasMaxLength(200);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Manufacturer).HasMaxLength(50);

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(400);

                entity.Property(e => e.OrderedFrom).HasMaxLength(200);

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.PurchasePrice).HasColumnType("money");

                entity.Property(e => e.ShelfLocation).HasMaxLength(50);
            });

            modelBuilder.Entity<PartsUserFavourites>(entity =>
            {
                entity.ToTable("Parts_UserFavourites");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Quantity).HasColumnType("money");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.PartsUserFavourites)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_Parts_UserFavourites_Customer");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PartsUserFavourites)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("FK_Parts_UserFavourites_User");
            });

            modelBuilder.Entity<PaymentLog>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Message).HasMaxLength(1000);

                entity.Property(e => e.Result)
                    .HasMaxLength(500)
                    .IsUnicode(false);

                entity.Property(e => e.StatusInfo)
                    .HasMaxLength(1000)
                    .IsUnicode(false);

                entity.Property(e => e.Type).HasMaxLength(100);

                entity.HasOne(d => d.JobPayment)
                    .WithMany(p => p.PaymentLog)
                    .HasForeignKey(d => d.JobPaymentId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PaymentLog_JobPayment");
            });

            modelBuilder.Entity<PaymentMethod>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name).HasMaxLength(250);

                entity.Property(e => e.Short).HasMaxLength(50);
            });

            modelBuilder.Entity<PermissionRecord>(entity =>
            {
                entity.Property(e => e.Category)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.SystemName)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<PermissionRecordRoleMapping>(entity =>
            {
                entity.HasKey(e => new { e.PermissionRecordId, e.RoleId });

                entity.ToTable("PermissionRecord_Role_Mapping");

                entity.Property(e => e.PermissionRecordId).HasColumnName("PermissionRecord_Id");

                entity.Property(e => e.RoleId).HasColumnName("Role_Id");

                entity.HasOne(d => d.PermissionRecord)
                    .WithMany(p => p.PermissionRecordRoleMapping)
                    .HasForeignKey(d => d.PermissionRecordId)
                    .HasConstraintName("PermissionRecord_CustomerRoles_Source");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.PermissionRecordRoleMapping)
                    .HasForeignKey(d => d.RoleId)
                    .HasConstraintName("PermissionRecord_CustomerRoles_Target");
            });

            modelBuilder.Entity<PermissionRecordUserMapping>(entity =>
            {
                entity.HasKey(e => new { e.PermissionRecordId, e.UserId });

                entity.ToTable("PermissionRecord_User_Mapping");

                entity.Property(e => e.PermissionRecordId).HasColumnName("PermissionRecord_Id");

                entity.HasOne(d => d.PermissionRecord)
                    .WithMany(p => p.PermissionRecordUserMapping)
                    .HasForeignKey(d => d.PermissionRecordId)
                    .HasConstraintName("PermissionRecord_User_Source");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.PermissionRecordUserMapping)
                    .HasForeignKey(d => d.UserId)
                    .HasConstraintName("PermissionRecord_User_Target");
            });

            modelBuilder.Entity<PhoneNumber>(entity =>
            {
                entity.ToTable("Phone_Number");

                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.CreatedOn).HasColumnType("date");

                entity.Property(e => e.Phone)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.UpdatedOn).HasColumnType("date");

                entity.Property(e => e.UserType)
                    .IsRequired()
                    .HasMaxLength(50);
            });

            modelBuilder.Entity<PoinventoryHistory>(entity =>
            {
                entity.ToTable("POInventoryHistory");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Projects>(entity =>
            {
                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.IsDefault)
                    .IsRequired()
                    .HasColumnName("isDefault")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.ProjectName).IsRequired();

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Projects)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Projects_Customer");
            });

            modelBuilder.Entity<PurchaseOrder>(entity =>
            {
                entity.Property(e => e.Aissparts).HasColumnName("AISSParts");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DateOrdered).HasColumnType("datetime");

                entity.Property(e => e.InvoiceBy).HasMaxLength(250);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.OrderedBy).HasMaxLength(250);

                entity.Property(e => e.PurchaseOrderNumber).HasMaxLength(50);

                entity.Property(e => e.ShippedBy).HasMaxLength(250);

                entity.Property(e => e.TrackingNumber).HasMaxLength(50);

                entity.Property(e => e.Type).HasMaxLength(50);

                entity.HasOne(d => d.BillingAddress)
                    .WithMany(p => p.PurchaseOrderBillingAddress)
                    .HasForeignKey(d => d.BillingAddressId)
                    .HasConstraintName("FK_PurchaseOrder_Address");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.PurchaseOrder)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseOrder_Job");

                entity.HasOne(d => d.ShippingAddress)
                    .WithMany(p => p.PurchaseOrderShippingAddress)
                    .HasForeignKey(d => d.ShippingAddressId)
                    .HasConstraintName("FK_PurchaseOrder_Address1");
            });

            modelBuilder.Entity<PurchaseOrderDetails>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);

                entity.HasOne(d => d.PurchaseOrder)
                    .WithMany(p => p.PurchaseOrderDetails)
                    .HasForeignKey(d => d.PurchaseOrderId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_PurchaseOrderDetails_PurchaseOrder");
            });

            modelBuilder.Entity<QueuedEmails>(entity =>
            {
                entity.HasKey(e => e.QueueId);

                entity.Property(e => e.QueueId).HasColumnName("QueueID");

                entity.Property(e => e.ContactPerson).HasColumnName("contactPerson");

                entity.Property(e => e.ContractorId).HasColumnName("ContractorID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CustomerId).HasColumnName("CustomerID");

                entity.Property(e => e.JobContractorEta).HasColumnName("JobContractorETA");

                entity.Property(e => e.JobId).HasColumnName("JobID");

                entity.Property(e => e.LastUpdateOn).HasColumnType("datetime");

                entity.Property(e => e.Nteamount).HasColumnName("NTEAmount");

                entity.Property(e => e.SentOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<QuickCallSlip>(entity =>
            {
                entity.Property(e => e.CustomerName).HasMaxLength(200);

                entity.Property(e => e.PhoneNumber).HasMaxLength(50);
            });

            modelBuilder.Entity<Receipt>(entity =>
            {
                entity.HasIndex(e => e.ContractorId)
                    .HasName("nci_wi_Receipt_DF322EECF291B1D123B97F650FA7CD2D");

                entity.HasIndex(e => e.JobId)
                    .HasName("nci_wi_Receipt_E7FA8F6957723E1BBFB8F44279441C92");

                entity.HasIndex(e => new { e.JobId, e.Id })
                    .HasName("_dta_index_Receipt_8_1877581727__K4_K1");

                entity.HasIndex(e => new { e.Week, e.Quarter, e.Year, e.JobId, e.Id })
                    .HasName("_dta_index_Receipt_8_1877581727__K4_K1_24_25_27");

                entity.HasIndex(e => new { e.AmexAmount, e.Approval, e.BillAmount, e.CalculatedTotal, e.CashAmount, e.CheckAmount, e.ContractorCommissionRate, e.CostOfGoodsSold, e.CreatedBy, e.CreatedOn, e.Discount, e.DiscoverAmount, e.ExtraCommission, e.Ilgparts, e.IncTax, e.Inventory, e.InvoiceDate, e.JobId, e.LastUpdateBy, e.LastUpdatedOn, e.MasterCardAmount, e.Notes, e.PaymentMethodId, e.Quarter, e.ReceiptNumber, e.RetailCostOfMaterials, e.SignaturePath, e.StraightCommission, e.TaxExempt, e.TaxOverride, e.Total, e.VisaAmount, e.Week, e.Year, e.ContractorId })
                    .HasName("nci_wi_Receipt_BDD1F37C2B98D05F81E6CCAA325696FA");

                entity.Property(e => e.Adjustment).HasColumnType("money");

                entity.Property(e => e.AmexAmount).HasColumnType("money");

                entity.Property(e => e.Approval).HasColumnType("nvarchar(max)");

                entity.Property(e => e.BillAmount).HasColumnType("money");

                entity.Property(e => e.CalculatedTotal).HasColumnType("money");

                entity.Property(e => e.CashAmount).HasColumnType("money");

                entity.Property(e => e.CheckAmount).HasColumnType("money");

                entity.Property(e => e.ContractorCommissionRate).HasColumnType("money");

                entity.Property(e => e.CostOfGoodsSold).HasColumnType("money");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CreditCardAmount).HasColumnType("money");

                entity.Property(e => e.Discount).HasColumnType("money");

                entity.Property(e => e.DiscoverAmount).HasColumnType("money");

                entity.Property(e => e.ExtraCommission).HasColumnType("money");

                entity.Property(e => e.Ilgparts)
                    .HasColumnName("ILGParts")
                    .HasColumnType("money");

                entity.Property(e => e.IncTax).HasColumnType("money");

                entity.Property(e => e.Inventory).HasColumnType("money");

                entity.Property(e => e.InvoiceDate).HasColumnType("date");

                entity.Property(e => e.Labor).HasColumnType("money");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.MasterCardAmount).HasColumnType("money");

                entity.Property(e => e.Notes).HasColumnType("nvarchar(max)");

                entity.Property(e => e.Part).HasColumnType("money");

                entity.Property(e => e.ReceiptNumber).HasMaxLength(50);

                entity.Property(e => e.RetailCostOfMaterials).HasColumnType("money");

                entity.Property(e => e.SignaturePath).HasColumnType("nvarchar(max)");

                entity.Property(e => e.StraightCommission).HasColumnType("money");

                entity.Property(e => e.TaxOverride).HasColumnType("money");

                entity.Property(e => e.Total).HasColumnType("money");

                entity.Property(e => e.Trip).HasColumnType("money");

                entity.Property(e => e.VisaAmount).HasColumnType("money");

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.Receipt)
                    .HasForeignKey(d => d.ContractorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receipt_Contractor");

                entity.HasOne(d => d.CreatedByNavigation)
                    .WithMany(p => p.ReceiptCreatedByNavigation)
                    .HasForeignKey(d => d.CreatedBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receipt_User");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Receipt)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receipt_Job");

                entity.HasOne(d => d.LastUpdateByNavigation)
                    .WithMany(p => p.ReceiptLastUpdateByNavigation)
                    .HasForeignKey(d => d.LastUpdateBy)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Receipt_User1");

                entity.HasOne(d => d.PaymentMethod)
                    .WithMany(p => p.Receipt)
                    .HasForeignKey(d => d.PaymentMethodId)
                    .HasConstraintName("FK_Receipt_PaymentMethod");
            });

            modelBuilder.Entity<Role>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(255);
            });

            modelBuilder.Entity<Service>(entity =>
            {
                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.Brochure).HasDefaultValueSql("((0))");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.DiscountPrice).HasColumnType("money");

                entity.Property(e => e.DisplayAmount).HasColumnType("money");

                entity.Property(e => e.HourlyRate).HasColumnType("money");

                entity.Property(e => e.IsCustomService).HasColumnName("isCustomService");

                entity.Property(e => e.IsQbsynced).HasColumnName("IsQBSynced");

                entity.Property(e => e.IsSaservice).HasColumnName("isSAService");

                entity.Property(e => e.Material).HasColumnType("money");

                entity.Property(e => e.Name).IsRequired();

                entity.Property(e => e.OfficeId).HasDefaultValueSql("((1))");

                entity.Property(e => e.Price).HasColumnType("money");

                entity.Property(e => e.Qbid).HasColumnName("QBId");

                entity.Property(e => e.ServiceCategoryId).HasColumnName("ServiceCategoryID");

                entity.Property(e => e.SpecialPrice).HasColumnType("money");

                entity.Property(e => e.TaskNo).HasMaxLength(10);

                entity.Property(e => e.TaxCategoryId).HasColumnName("TaxCategoryID");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Warranty).HasMaxLength(500);
            });

            modelBuilder.Entity<ServiceCategoryPicture>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<ServicePicture>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Service)
                    .WithMany(p => p.ServicePicture)
                    .HasForeignKey(d => d.ServiceId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_ServicePicture_Service");
            });

            modelBuilder.Entity<Services>(entity =>
            {
                entity.HasKey(e => e.ServiceId);

                entity.Property(e => e.ServiceId).HasColumnName("ServiceID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.ServiceCharges).HasColumnType("money");

                entity.Property(e => e.ServiceName)
                    .IsRequired()
                    .HasMaxLength(250);
            });

            modelBuilder.Entity<ServicesCategory>(entity =>
            {
                entity.HasKey(e => e.ServiceCategoryId);

                entity.Property(e => e.ServiceCategoryId).HasColumnName("ServiceCategoryID");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.OfficeId).HasDefaultValueSql("((1))");

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");
            });

            modelBuilder.Entity<Setting>(entity =>
            {
                entity.Property(e => e.Id).HasColumnName("ID");

                entity.Property(e => e.Category).HasMaxLength(100);

                entity.Property(e => e.Code)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.DateCreatedUtc)
                    .HasColumnName("DateCreatedUTC")
                    .HasColumnType("datetime");

                entity.Property(e => e.DateModifiedUtc)
                    .HasColumnName("DateModifiedUTC")
                    .HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Notes).IsRequired();

                entity.Property(e => e.Value)
                    .IsRequired()
                    .HasMaxLength(1000);
            });

            modelBuilder.Entity<ShippingRates>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.ShippingCompany)
                    .IsRequired()
                    .HasMaxLength(50);

                entity.Property(e => e.ShippingRates1)
                    .HasColumnName("ShippingRates")
                    .HasColumnType("money");
            });

            modelBuilder.Entity<Smslog>(entity =>
            {
                entity.ToTable("SMSLog");

                entity.HasIndex(e => new { e.Id, e.JobId, e.Body, e.To, e.From, e.DateCreated, e.CreatedByUserId, e.Sent, e.UserAlerted })
                    .HasName("_dta_index_SMSLog_6_1924917929__K6_K7_1_2_3_4_5_8_9");

                entity.Property(e => e.Body).HasColumnType("varchar(max)");

                entity.Property(e => e.DateCreated).HasColumnType("datetime");

                entity.Property(e => e.From)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.IsNotify).HasColumnName("isNotify");

                entity.Property(e => e.To)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.Smslog)
                    .HasForeignKey(d => d.JobId)
                    .HasConstraintName("FK_SMSLog_Job");
            });

            modelBuilder.Entity<State>(entity =>
            {
                entity.Property(e => e.Abbreviation).HasMaxLength(100);

                entity.Property(e => e.CountryId).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Name)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.Property(e => e.TaxPartsOnly)
                    .IsRequired()
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.TimeZone).HasMaxLength(250);

                entity.Property(e => e.TimeZoneCode)
                    .HasMaxLength(10)
                    .IsUnicode(false);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.State)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_State_Country");
            });

            modelBuilder.Entity<Store>(entity =>
            {
                entity.HasIndex(e => new { e.Id, e.StoreNumber })
                    .HasName("_dta_index_Store_8_1013578649__K1_K3");

                entity.HasIndex(e => new { e.StoreNumber, e.LocationName, e.Id })
                    .HasName("_dta_index_Store_8_1013578649__K1_3_4");

                entity.HasIndex(e => new { e.Address, e.Building, e.City, e.CountryId, e.CountyId, e.CreatedByUserId, e.CreatedOn, e.CrossStreet, e.Deleted, e.HistoricalData, e.Id, e.LastUpdatedByUserId, e.LastUpdatedOn, e.LocationName, e.Notes, e.Phone, e.StateId, e.ZipCode, e.CustomerId, e.StoreNumber })
                    .HasName("nci_wi_Store_1656CDBB913FA75F4259C988E7DE7B01");

                entity.Property(e => e.Address).HasColumnType("nvarchar(max)");

                entity.Property(e => e.Building).HasMaxLength(255);

                entity.Property(e => e.City).HasColumnType("nvarchar(max)");

                entity.Property(e => e.CountryId).HasDefaultValueSql("((1))");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CrossStreet).HasColumnType("nvarchar(max)");

                entity.Property(e => e.HistoricalData).HasColumnType("nvarchar(max)");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.LocationName).HasMaxLength(255);

                entity.Property(e => e.Notes).HasColumnType("nvarchar(max)");

                entity.Property(e => e.Phone).HasMaxLength(255);

                entity.Property(e => e.StoreNumber).HasMaxLength(255);

                entity.Property(e => e.ZipCode).HasMaxLength(255);

                entity.HasOne(d => d.Country)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.CountryId)
                    .HasConstraintName("FK_Store_Country");

                entity.HasOne(d => d.County)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.CountyId)
                    .HasConstraintName("FK_Store_County");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.CustomerId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Store_Customer");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.Store)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_Store_StateProvince");
            });

            modelBuilder.Entity<StorePartHistory>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Quantity).HasColumnType("money");

                entity.Property(e => e.StoreNumber).HasMaxLength(200);

                entity.Property(e => e.Title)
                    .IsRequired()
                    .HasMaxLength(200);

                entity.Property(e => e.Total).HasColumnType("money");

                entity.Property(e => e.UnitPrice)
                    .HasColumnName("Unit_Price")
                    .HasColumnType("money");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.StorePartHistory)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StorePartHistory_User");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.StorePartHistory)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StorePartHistory_Job");

                entity.HasOne(d => d.Store)
                    .WithMany(p => p.StorePartHistory)
                    .HasForeignKey(d => d.StoreId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_StorePartHistory_Store");
            });

            modelBuilder.Entity<TaxRate>(entity =>
            {
                entity.HasIndex(e => new { e.CreatedOn, e.ZipCode, e.Id, e.CountyTax, e.CityTax, e.SpecialRate, e.StateTax })
                    .HasName("_dta_index_TaxRate_8_1685581043__K7_K1_K9_K10_K11_K8_13");

                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.CountryId).HasDefaultValueSql("((1))");

                entity.Property(e => e.County).HasMaxLength(255);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.QuickBooksTaxAllocationAccount).HasMaxLength(255);

                entity.Property(e => e.UpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.ZipCode).HasMaxLength(255);

                entity.HasOne(d => d.CountyNavigation)
                    .WithMany(p => p.TaxRate)
                    .HasForeignKey(d => d.CountyId)
                    .HasConstraintName("FK_TaxRate_County");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.TaxRate)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_TaxRate_State");
            });

            modelBuilder.Entity<TechnicianNotes>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Technician)
                    .WithMany(p => p.TechnicianNotes)
                    .HasForeignKey(d => d.TechnicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TechnicianNotes_Contractor");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.TechnicianNotes)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TechnicianNotes_User");
            });

            modelBuilder.Entity<Technicians>(entity =>
            {
                entity.Property(e => e.BusinessName).HasMaxLength(20);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.FirstName).HasMaxLength(20);

                entity.Property(e => e.LastName).HasMaxLength(20);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.LicenseExpirationDate).HasColumnType("date");

                entity.Property(e => e.LicenseNumber).HasMaxLength(20);

                entity.Property(e => e.MainEmailAddress)
                    .IsRequired()
                    .HasMaxLength(30);

                entity.Property(e => e.MainPhone).HasMaxLength(20);

                entity.Property(e => e.TechnicianFax).HasMaxLength(250);

                entity.Property(e => e.TechnicianPicture).HasMaxLength(500);

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.Technicians)
                    .HasForeignKey(d => d.ContractorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Table_1_Contractor");
            });

            modelBuilder.Entity<TechReceiptLineItem>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Quantity).HasColumnType("money");

                entity.Property(e => e.UnitPrice).HasColumnType("money");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.TechReceiptLineItem)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TechReceiptLineItem_Job");
            });

            modelBuilder.Entity<TechSumary>(entity =>
            {
                entity.HasIndex(e => new { e.JobId, e.Types })
                    .HasName("nci_wi_TechSumary_B61121A35820F1A77C8C71970871D4D4");

                entity.Property(e => e.Charges).HasMaxLength(50);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.Description).HasMaxLength(200);

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.Quantity).HasMaxLength(50);

                entity.Property(e => e.ReceiptNumber).HasMaxLength(50);

                entity.Property(e => e.Tax).HasMaxLength(50);

                entity.Property(e => e.TechSummaryNumber).HasDefaultValueSql("((1))");

                entity.Property(e => e.Total).HasMaxLength(50);

                entity.Property(e => e.Types).HasMaxLength(50);

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.TechSumary)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TechSumary_Job");
            });

            modelBuilder.Entity<TopCitiesTable>(entity =>
            {
                entity.Property(e => e.CityName)
                    .IsRequired()
                    .HasMaxLength(100)
                    .IsUnicode(false);

                entity.Property(e => e.Latitude).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.Longtitude).HasColumnType("decimal(18, 6)");

                entity.Property(e => e.State)
                    .HasMaxLength(50)
                    .IsUnicode(false);

                entity.Property(e => e.Zip)
                    .HasMaxLength(50)
                    .IsUnicode(false);
            });

            modelBuilder.Entity<Truck>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.LicensePlateNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.TruckNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.Property(e => e.VinNumber)
                    .IsRequired()
                    .HasMaxLength(20);

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.Truck)
                    .HasForeignKey(d => d.ContractorId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Truck_Contractor");

                entity.HasOne(d => d.Technician)
                    .WithMany(p => p.Truck)
                    .HasForeignKey(d => d.TechnicianId)
                    .HasConstraintName("FK_Truck_Technicians");
            });

            modelBuilder.Entity<TruckParts>(entity =>
            {
                entity.ToTable("Truck_Parts");

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.LastUpdateOn).HasColumnType("datetime");

                entity.Property(e => e.PartId).HasColumnName("Part_Id");

                entity.Property(e => e.TruckId).HasColumnName("Truck_Id");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.TruckPartsCreatedByUser)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .HasConstraintName("FK_Truck_Parts_User");

                entity.HasOne(d => d.LastUpdatedByUser)
                    .WithMany(p => p.TruckPartsLastUpdatedByUser)
                    .HasForeignKey(d => d.LastUpdatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Truck_Parts_User1");

                entity.HasOne(d => d.Part)
                    .WithMany(p => p.TruckParts)
                    .HasForeignKey(d => d.PartId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Truck_Parts_Part");

                entity.HasOne(d => d.Truck)
                    .WithMany(p => p.TruckParts)
                    .HasForeignKey(d => d.TruckId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_Truck_Parts_Truck");
            });

            modelBuilder.Entity<TruckTechnicianHistory>(entity =>
            {
                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.HasOne(d => d.CreatedByUser)
                    .WithMany(p => p.TruckTechnicianHistory)
                    .HasForeignKey(d => d.CreatedByUserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TruckTechnicianHistory_User");

                entity.HasOne(d => d.Technician)
                    .WithMany(p => p.TruckTechnicianHistory)
                    .HasForeignKey(d => d.TechnicianId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TruckTechnicianHistory_Technicians");

                entity.HasOne(d => d.Truck)
                    .WithMany(p => p.TruckTechnicianHistory)
                    .HasForeignKey(d => d.TruckId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_TruckTechnicianHistory_Truck");
            });

            modelBuilder.Entity<User>(entity =>
            {
                entity.HasIndex(e => new { e.Username, e.Id })
                    .HasName("_dta_index_User_8_837578022__K1_3");

                entity.Property(e => e.Cell).HasMaxLength(250);

                entity.Property(e => e.City).HasMaxLength(250);

                entity.Property(e => e.CreatedOn).HasColumnType("datetime");

                entity.Property(e => e.CurrentBoardType).HasDefaultValueSql("((1))");

                entity.Property(e => e.Email).HasMaxLength(1000);

                entity.Property(e => e.GreaterThanNteamountEntryAllowed)
                    .HasColumnName("GreaterThanNTEAmountEntryAllowed")
                    .HasDefaultValueSql("((1))");

                entity.Property(e => e.HiringDate).HasColumnType("datetime");

                entity.Property(e => e.LastLoginDate).HasColumnType("datetime");

                entity.Property(e => e.LastUpdatedOn).HasColumnType("datetime");

                entity.Property(e => e.PasswordChangedOn).HasColumnType("datetime");

                entity.Property(e => e.Phone).HasMaxLength(250);

                entity.Property(e => e.Ssn)
                    .HasColumnName("SSN")
                    .HasMaxLength(250);

                entity.Property(e => e.TimeZone).HasMaxLength(250);

                entity.Property(e => e.Username).HasMaxLength(1000);

                entity.Property(e => e.ZipCode).HasMaxLength(50);

                entity.HasOne(d => d.Contractor)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.ContractorId)
                    .HasConstraintName("FK_User_Contractor");

                entity.HasOne(d => d.Customer)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.CustomerId)
                    .HasConstraintName("FK_User_Customer");

                entity.HasOne(d => d.Role)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.RoleId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Role");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_User_StateProvince");

                entity.HasOne(d => d.Technician)
                    .WithMany(p => p.User)
                    .HasForeignKey(d => d.TechnicianId)
                    .HasConstraintName("FK_User_Technicians");
            });

            modelBuilder.Entity<UserJobsRecord>(entity =>
            {
                entity.ToTable("User_Jobs_Record");

                entity.Property(e => e.ViewedOn).HasColumnType("datetime");

                entity.HasOne(d => d.Job)
                    .WithMany(p => p.UserJobsRecord)
                    .HasForeignKey(d => d.JobId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Jobs_Record_Job");

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserJobsRecord)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_User_Jobs_Record_User");
            });

            modelBuilder.Entity<UserLogin>(entity =>
            {
                entity.Property(e => e.Time).HasColumnType("datetime");

                entity.Property(e => e.Type)
                    .IsRequired()
                    .HasMaxLength(100);

                entity.HasOne(d => d.User)
                    .WithMany(p => p.UserLogin)
                    .HasForeignKey(d => d.UserId)
                    .OnDelete(DeleteBehavior.ClientSetNull)
                    .HasConstraintName("FK_UserLogin_User");
            });

            modelBuilder.Entity<WebAddressManager>(entity =>
            {
                entity.Property(e => e.CreatedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.LastModifiedOn)
                    .HasColumnType("datetime")
                    .HasDefaultValueSql("(getdate())");

                entity.Property(e => e.Password).HasMaxLength(255);

                entity.Property(e => e.Title).HasMaxLength(500);

                entity.Property(e => e.Username).HasMaxLength(255);

                entity.Property(e => e.WebAddress).HasMaxLength(500);
            });

            modelBuilder.Entity<ZipCodeData>(entity =>
            {
                entity.Property(e => e.City).HasMaxLength(255);

                entity.Property(e => e.CountryId).HasDefaultValueSql("((1))");

                entity.Property(e => e.CountyId).HasColumnName("CountyID");

                entity.Property(e => e.StateId).HasColumnName("StateID");

                entity.Property(e => e.ZipCode).HasMaxLength(50);

                entity.HasOne(d => d.County)
                    .WithMany(p => p.ZipCodeData)
                    .HasForeignKey(d => d.CountyId)
                    .HasConstraintName("FK_ZipCodeData_County");

                entity.HasOne(d => d.State)
                    .WithMany(p => p.ZipCodeData)
                    .HasForeignKey(d => d.StateId)
                    .HasConstraintName("FK_ZipCodeData_State");
            });
        }
    }
}
