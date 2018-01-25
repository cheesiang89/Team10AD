namespace TestingConsole.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class GoodsReceivedRecord
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public GoodsReceivedRecord()
        {
            GoodsReceivedRecordDetails = new HashSet<GoodsReceivedRecordDetail>();
        }

        [Key]
        public int GoodReceiveID { get; set; }

        public DateTime? ReceivedDate { get; set; }

        public int? POID { get; set; }

        public int? StoreStaffID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<GoodsReceivedRecordDetail> GoodsReceivedRecordDetails { get; set; }

        public virtual PurchaseOrder PurchaseOrder { get; set; }

        public virtual StoreStaff StoreStaff { get; set; }
    }
}
