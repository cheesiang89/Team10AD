namespace Team10AD_Web.App_Code.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Disbursement
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Disbursement()
        {
            DisbursementDetails = new HashSet<DisbursementDetail>();
        }

        public int DisbursementID { get; set; }

        public DateTime? CollectionDate { get; set; }

        public int PointID { get; set; }

        [StringLength(4)]
        public string DepartmentCode { get; set; }

        [StringLength(50)]
        public string Status { get; set; }

        public int? StoreStaffID { get; set; }

        public virtual CollectionPoint CollectionPoint { get; set; }

        public virtual Department Department { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<DisbursementDetail> DisbursementDetails { get; set; }

        public virtual StoreStaff StoreStaff { get; set; }
    }
}
