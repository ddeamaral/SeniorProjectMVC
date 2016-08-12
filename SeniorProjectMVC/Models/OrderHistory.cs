namespace SeniorProjectMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderHistory")]
    public partial class OrderHistory
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderHistory_ID { get; set; }

        public int OrderHeader_ID { get; set; }

        public int Customer_ID { get; set; }

        public DateTime? DateCreated { get; set; }

        public virtual Customer Customer { get; set; }

        public virtual OrderHeader OrderHeader { get; set; }
    }
}
