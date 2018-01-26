namespace Team10AD_Web.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("PurchaseOrderDetailsView")]
    public partial class PurchaseOrderDetailsView
    {
        [Key]
        [StringLength(4)]
        public string ItemCode { get; set; }

        [StringLength(50)]
        public string Description { get; set; }

        public int? Quantity { get; set; }

        public double? UnitPrice { get; set; }

        public double? Amount { get; set; }
    }
}
