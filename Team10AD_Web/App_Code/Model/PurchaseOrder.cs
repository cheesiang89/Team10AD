namespace Team10AD_Web.App_Code.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PurchaseOrder
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public PurchaseOrder()
        {
            GoodsReceivedRecords = new HashSet<GoodsReceivedRecord>();
            PurchaseOrderDetails = new HashSet<PurchaseOrderDetail>();
        }

        [Key]
        public int POID { get; set; }

        public DateTime? CreationDate { get; set; }

        [StringLength(4)]
        public string SupplierCode { get; set; }

        public int? StoreStaffID { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsReceivedRecord> GoodsReceivedRecords { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<PurchaseOrderDetail> PurchaseOrderDetails { get; set; }

        public virtual StoreStaff StoreStaff { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
