namespace Team10AD_Web.App_Code.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("StockFlow")]
    public partial class StockFlow
    {
        [Key]
        [StringLength(4)]
        public string ItemCode { get; set; }

        public DateTime? Date { get; set; }

        [StringLength(10)]
        public string Entity { get; set; }

        [Column("Adjusted Quantity")]
        public int? Adjusted_Quantity { get; set; }

        [Column("Balance Quantity")]
        public int? Balance_Quantity { get; set; }
    }
}
