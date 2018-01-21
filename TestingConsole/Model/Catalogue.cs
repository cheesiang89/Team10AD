namespace TestingConsole.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Catalogue
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Catalogue()
        {
            DisbursementDetails = new HashSet<DisbursementDetail>();
            GoodsReceivedRecordDetails = new HashSet<GoodsReceivedRecordDetail>();
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
            RequisitionDetails = new HashSet<RequisitionDetail>();
            RetrievalDetails = new HashSet<RetrievalDetail>();
            StockAdjustmentVoucherDetails = new HashSet<StockAdjustmentVoucherDetail>();
            SupplierDetails = new HashSet<SupplierDetail>();
        }

        [Key]
        [StringLength(4)]
        public string ItemCode { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        [StringLength(10)]
        public string Category { get; set; }

        [StringLength(50)]
        public string Location { get; set; }

        [StringLength(20)]
        public string UnitOfMeasure { get; set; }

        public int? BalanceQuantity { get; set; }

        public int? ReorderLevel { get; set; }

        public int? MinimumOrderQuantity { get; set; }

        public int? PendingRequestQuantity { get; set; }

        public int? PendingDeliveryQuantity { get; set; }

        [StringLength(10)]
        public string ShortfallStatus { get; set; }

        [StringLength(4)]
        public string FirstSupplier { get; set; }

        [StringLength(4)]
        public string SecondSupplier { get; set; }

        [StringLength(4)]
        public string ThirdSupplier { get; set; }

        public virtual Supplier Supplier { get; set; }

        public virtual Supplier Supplier1 { get; set; }

        public virtual Supplier Supplier2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementDetail> DisbursementDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsReceivedRecordDetail> GoodsReceivedRecordDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RequisitionDetail> RequisitionDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<RetrievalDetail> RetrievalDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockAdjustmentVoucherDetail> StockAdjustmentVoucherDetails { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<SupplierDetail> SupplierDetails { get; set; }
    }
}
