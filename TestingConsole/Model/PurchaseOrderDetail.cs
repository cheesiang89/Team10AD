namespace TestingConsole.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class PurchaseOrderDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string ItemCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int POID { get; set; }

        public int? Quantity { get; set; }

        public double? UnitPrice { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public virtual Catalogue Catalogue { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }
    }
}
