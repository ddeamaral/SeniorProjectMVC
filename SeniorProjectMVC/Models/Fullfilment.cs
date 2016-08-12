namespace SeniorProjectMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("Fullfilment")]
    public partial class Fullfilment
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int Fullfilment_ID { get; set; }

        public int Vendor_ID { get; set; }

        [StringLength(100)]
        public string Name { get; set; }

        [StringLength(500)]
        public string Description { get; set; }

        [StringLength(100)]
        public string Address1 { get; set; }

        [StringLength(50)]
        public string City { get; set; }

        [StringLength(2)]
        public string StateID { get; set; }

        [StringLength(7)]
        public string Zipcode { get; set; }

        [StringLength(10)]
        public string Telephone { get; set; }

        public virtual Vendor Vendor { get; set; }
    }
}
