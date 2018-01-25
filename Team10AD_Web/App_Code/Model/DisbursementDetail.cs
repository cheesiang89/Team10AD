namespace Team10AD_Web.App_Code.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class DisbursementDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int DisbursementID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string ItemCode { get; set; }

        public int? QuantityRequested { get; set; }

        public int? QuantityCollected { get; set; }

        [StringLength(50)]
        public string Remarks { get; set; }

        public int? QuantityAfter { get; set; }

        public virtual Catalogue Catalogue { get; set; }

        public virtual Disbursement Disbursement { get; set; }
    }
}
