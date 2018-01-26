namespace Team10AD_Web.Model
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class Department
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public Department()
        {
            Disbursements = new HashSet<Disbursement>();
            Employees = new HashSet<Employee>();
        }

        [Key]
        [StringLength(4)]
        public string DepartmentCode { get; set; }

        [StringLength(50)]
        public string DepartmentName { get; set; }

        public int? ContactPersonID { get; set; }

        public int? PointID { get; set; }

        public int? RepresentativeID { get; set; }

        public int? ApproverID { get; set; }

        public DateTime? ApprovingPeriodStart { get; set; }

        public DateTime? ApprovingPeriodEnd { get; set; }

        public int? HODID { get; set; }

        public virtual CollectionPoint CollectionPoint { get; set; }

        public virtual Employee Employee { get; set; }

        public virtual Employee Employee1 { get; set; }

        public virtual Employee Employee2 { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Disbursement> Disbursements { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<Employee> Employees { get; set; }
    }
}
