namespace SeniorProjectMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class XREF_CustomerRole
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int XREF_CustomerRole_ID { get; set; }

        public int Customer_ID { get; set; }

        public int Role_ID { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual Role Role { get; set; }
    }
}
