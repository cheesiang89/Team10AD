namespace Team10AD_Web.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GoodsReceivedRecordDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string ItemCode { get; set; }

        [Key]
        [Column(Order = 1)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int GoodReceiveID { get; set; }

        public int? ReceivedQuantity { get; set; }

        [StringLength(50)]
        public string Remark { get; set; }

        public int? QuantityAfter { get; set; }

        public virtual Catalogue Catalogue { get; set; }

        public virtual GoodsReceivedRecord GoodsReceivedRecord { get; set; }
    }
}
