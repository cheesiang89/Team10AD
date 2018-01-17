namespace Team10AD_Web.App_Code.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StockAdjustmentVoucher
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public StockAdjustmentVoucher()
        {
            StockAdjustmentVoucherDetails = new HashSet<StockAdjustmentVoucherDetail>();
        }

        [Key]
        public int VoucherID { get; set; }

        public int? StoreStaffID { get; set; }

        public int? ApproverID { get; set; }

        public DateTime? DateIssue { get; set; }

        public DateTime? DateApproved { get; set; }

        [StringLength(10)]
        public string Status { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<StockAdjustmentVoucherDetail> StockAdjustmentVoucherDetails { get; set; }

        public virtual StoreStaff StoreStaff { get; set; }

        public virtual StoreStaff StoreStaff1 { get; set; }
    }
}
