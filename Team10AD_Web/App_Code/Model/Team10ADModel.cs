namespace Team10AD_Web.Model
{
    using System;
    using System.Data.Entity;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Linq;

    public partial class Team10ADModel : DbContext
    {
        public Team10ADModel()
            : base("name=team10")
        {
        }

        public virtual DbSet<Catalogue> Catalogues { get; set; }
        public virtual DbSet<CollectionPoint> CollectionPoints { get; set; }
        public virtual DbSet<Department> Departments { get; set; }
        public virtual DbSet<DisbursementDetail> DisbursementDetails { get; set; }
        public virtual DbSet<Disbursement> Disbursements { get; set; }
        public virtual DbSet<Employee> Employees { get; set; }
        public virtual DbSet<GoodsReceivedRecordDetail> GoodsReceivedRecordDetails { get; set; }
        public virtual DbSet<GoodsReceivedRecord> GoodsReceivedRecords { get; set; }
        public virtual DbSet<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }
        public virtual DbSet<PurchaseOrder> PurchaseOrders { get; set; }
        public virtual DbSet<RequisitionDetail> RequisitionDetails { get; set; }
        public virtual DbSet<Requisition> Requisitions { get; set; }
        public virtual DbSet<RetrievalDetail> RetrievalDetails { get; set; }
        public virtual DbSet<Retrieval> Retrievals { get; set; }
        public virtual DbSet<StockAdjustmentVoucherDetail> StockAdjustmentVoucherDetails { get; set; }
        public virtual DbSet<StockAdjustmentVoucher> StockAdjustmentVouchers { get; set; }
        public virtual DbSet<StoreStaff> StoreStaffs { get; set; }
        public virtual DbSet<SupplierDetail> SupplierDetails { get; set; }
        public virtual DbSet<Supplier> Suppliers { get; set; }
        public virtual DbSet<PurchaseOrderDetailsView> PurchaseOrderDetailsViews { get; set; }
        public virtual DbSet<StockFlow> StockFlows { get; set; }

        protected override void OnModelCreating(DbModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Catalogue>()
                .Property(e => e.ItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Catalogue>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<Catalogue>()
                .Property(e => e.Category)
                .IsUnicode(false);

            modelBuilder.Entity<Catalogue>()
                .Property(e => e.Location)
                .IsUnicode(false);

            modelBuilder.Entity<Catalogue>()
                .Property(e => e.UnitOfMeasure)
                .IsUnicode(false);

            modelBuilder.Entity<Catalogue>()
                .Property(e => e.ShortfallStatus)
                .IsUnicode(false);

            modelBuilder.Entity<Catalogue>()
                .Property(e => e.FirstSupplier)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Catalogue>()
                .Property(e => e.SecondSupplier)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Catalogue>()
                .Property(e => e.ThirdSupplier)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Catalogue>()
                .HasMany(e => e.DisbursementDetails)
                .WithRequired(e => e.Catalogue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Catalogue>()
                .HasMany(e => e.GoodsReceivedRecordDetails)
                .WithRequired(e => e.Catalogue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Catalogue>()
                .HasMany(e => e.PurchaseOrderDetails)
                .WithRequired(e => e.Catalogue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Catalogue>()
                .HasMany(e => e.RequisitionDetails)
                .WithRequired(e => e.Catalogue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Catalogue>()
                .HasMany(e => e.RetrievalDetails)
                .WithRequired(e => e.Catalogue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Catalogue>()
                .HasMany(e => e.StockAdjustmentVoucherDetails)
                .WithRequired(e => e.Catalogue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Catalogue>()
                .HasMany(e => e.SupplierDetails)
                .WithRequired(e => e.Catalogue)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<CollectionPoint>()
                .Property(e => e.PointName)
                .IsUnicode(false);

            modelBuilder.Entity<CollectionPoint>()
                .HasMany(e => e.Disbursements)
                .WithRequired(e => e.CollectionPoint)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.DepartmentCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .Property(e => e.DepartmentName)
                .IsUnicode(false);

            modelBuilder.Entity<Department>()
                .HasMany(e => e.Employees)
                .WithOptional(e => e.Department)
                .HasForeignKey(e => e.DepartmentCode);

            modelBuilder.Entity<DisbursementDetail>()
                .Property(e => e.ItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<DisbursementDetail>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<Disbursement>()
                .Property(e => e.DepartmentCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Disbursement>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Disbursement>()
                .HasMany(e => e.DisbursementDetails)
                .WithRequired(e => e.Disbursement)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .Property(e => e.DepartmentCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Departments)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.ContactPersonID);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Departments1)
                .WithOptional(e => e.Employee1)
                .HasForeignKey(e => e.RepresentativeID);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Departments2)
                .WithOptional(e => e.Employee2)
                .HasForeignKey(e => e.ApproverID);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Requisitions)
                .WithOptional(e => e.Employee)
                .HasForeignKey(e => e.RequestorID);

            modelBuilder.Entity<Employee>()
                .HasMany(e => e.Requisitions1)
                .WithOptional(e => e.Employee1)
                .HasForeignKey(e => e.ApproverID);

            modelBuilder.Entity<GoodsReceivedRecordDetail>()
                .Property(e => e.ItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<GoodsReceivedRecordDetail>()
                .Property(e => e.Remark)
                .IsUnicode(false);

            modelBuilder.Entity<GoodsReceivedRecord>()
                .HasMany(e => e.GoodsReceivedRecordDetails)
                .WithRequired(e => e.GoodsReceivedRecord)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(e => e.ItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrderDetail>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.SupplierCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrder>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrder>()
                .HasMany(e => e.PurchaseOrderDetails)
                .WithRequired(e => e.PurchaseOrder)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<RequisitionDetail>()
                .Property(e => e.ItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Requisition>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Requisition>()
                .Property(e => e.Remarks)
                .IsUnicode(false);

            modelBuilder.Entity<Requisition>()
                .HasMany(e => e.RequisitionDetails)
                .WithRequired(e => e.Requisition)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<Requisition>()
                .HasMany(e => e.Retrievals)
                .WithMany(e => e.Requisitions)
                .Map(m => m.ToTable("RequisitionSets").MapLeftKey("RequisitionID").MapRightKey("RetrievalID"));

            modelBuilder.Entity<RetrievalDetail>()
                .Property(e => e.ItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Retrieval>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<Retrieval>()
                .HasMany(e => e.RetrievalDetails)
                .WithRequired(e => e.Retrieval)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StockAdjustmentVoucherDetail>()
                .Property(e => e.ItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StockAdjustmentVoucherDetail>()
                .Property(e => e.Reason)
                .IsUnicode(false);

            modelBuilder.Entity<StockAdjustmentVoucher>()
                .Property(e => e.Status)
                .IsUnicode(false);

            modelBuilder.Entity<StockAdjustmentVoucher>()
                .HasMany(e => e.StockAdjustmentVoucherDetails)
                .WithRequired(e => e.StockAdjustmentVoucher)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<StoreStaff>()
                .Property(e => e.Name)
                .IsUnicode(false);

            modelBuilder.Entity<StoreStaff>()
                .Property(e => e.Title)
                .IsUnicode(false);

            modelBuilder.Entity<StoreStaff>()
                .Property(e => e.Email)
                .IsUnicode(false);

            modelBuilder.Entity<StoreStaff>()
                .HasMany(e => e.StockAdjustmentVouchers)
                .WithOptional(e => e.StoreStaff)
                .HasForeignKey(e => e.StoreStaffID);

            modelBuilder.Entity<StoreStaff>()
                .HasMany(e => e.StockAdjustmentVouchers1)
                .WithOptional(e => e.StoreStaff1)
                .HasForeignKey(e => e.ApproverID);

            modelBuilder.Entity<SupplierDetail>()
                .Property(e => e.ItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<SupplierDetail>()
                .Property(e => e.SupplierCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.SupplierCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.SupplierName)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.SupplierEmail)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.ContactName)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.Address)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .Property(e => e.GSTRegistrationNo)
                .IsUnicode(false);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Catalogues)
                .WithOptional(e => e.Supplier)
                .HasForeignKey(e => e.FirstSupplier);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Catalogues1)
                .WithOptional(e => e.Supplier1)
                .HasForeignKey(e => e.SecondSupplier);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.Catalogues2)
                .WithOptional(e => e.Supplier2)
                .HasForeignKey(e => e.ThirdSupplier);

            modelBuilder.Entity<Supplier>()
                .HasMany(e => e.SupplierDetails)
                .WithRequired(e => e.Supplier)
                .WillCascadeOnDelete(false);

            modelBuilder.Entity<PurchaseOrderDetailsView>()
                .Property(e => e.ItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<PurchaseOrderDetailsView>()
                .Property(e => e.Description)
                .IsUnicode(false);

            modelBuilder.Entity<StockFlow>()
                .Property(e => e.ItemCode)
                .IsFixedLength()
                .IsUnicode(false);

            modelBuilder.Entity<StockFlow>()
                .Property(e => e.Entity)
                .IsUnicode(false);
        }
    }
}
