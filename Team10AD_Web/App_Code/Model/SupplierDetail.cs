namespace Team10AD_Web.App_Code.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SupplierDetail
    {
        [Key]
        [Column(Order = 0)]
        [StringLength(4)]
        public string ItemCode { get; set; }

        public double? Price { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string SupplierCode { get; set; }

        public virtual Catalogue Catalogue { get; set; }

        public virtual Supplier Supplier { get; set; }
    }
}
