namespace Team10AD_Web.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RequisitionDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RequisitionID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string ItemCode { get; set; }

        public int? QuantityRequested { get; set; }

        public int? QuantityRetrieved { get; set; }

        public virtual Catalogue Catalogue { get; set; }

        public virtual Requisition Requisition { get; set; }
    }
}
