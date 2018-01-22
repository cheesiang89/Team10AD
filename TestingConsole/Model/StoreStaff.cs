namespace TestingConsole.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StoreStaff
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StoreStaff()
        {
            Disbursements = new HashSet<Disbursement>();
            GoodsReceivedRecords = new HashSet<GoodsReceivedRecord>();
            PurchaseOrders = new HashSet<PurchaseOrder>();
            Retrievals = new HashSet<Retrieval>();
            StockAdjustmentVouchers = new HashSet<StockAdjustmentVoucher>();
            StockAdjustmentVouchers1 = new HashSet<StockAdjustmentVoucher>();
        }

        public int StoreStaffID { get; set; }

        [StringLength(50)]
        public string Name { get; set; }

        public int? PhoneNumber { get; set; }

        [StringLength(10)]
        public string Title { get; set; }

        [StringLength(50)]
        public string Email { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Disbursement> Disbursements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsReceivedRecord> GoodsReceivedRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrder> PurchaseOrders { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Retrieval> Retrievals { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockAdjustmentVoucher> StockAdjustmentVouchers { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockAdjustmentVoucher> StockAdjustmentVouchers1 { get; set; }
    }
}
