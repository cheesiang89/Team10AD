namespace Team10AD_Web.App_Code.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class RetrievalDetail
    {
        [Key]
        [Column(Order = 0)]
        [DatabaseGenerated(DatabaseGeneratedOption.None)]
        public int RetrievalID { get; set; }

        [Key]
        [Column(Order = 1)]
        [StringLength(4)]
        public string ItemCode { get; set; }

        public int? RequestedQuantity { get; set; }

        public int? RetrievedQuantity { get; set; }

        public virtual Catalogue Catalogue { get; set; }

        public virtual Retrieval Retrieval { get; set; }
    }
}
