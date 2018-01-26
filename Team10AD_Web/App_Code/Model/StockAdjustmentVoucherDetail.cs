namespace Team10AD_Web.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class StockAdjustmentVoucherDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int VoucherID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string ItemCode { get; set; }

        public int? QuantityAdjusted { get; set; }

        [StringLength(50)]
        public string Reason { get; set; }

        public int? QuantityAfter { get; set; }

        public virtual Catalogue Catalogue { get; set; }

        public virtual StockAdjustmentVoucher StockAdjustmentVoucher { get; set; }
    }
}
