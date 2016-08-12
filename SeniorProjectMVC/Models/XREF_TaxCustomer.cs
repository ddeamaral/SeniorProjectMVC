namespace SeniorProjectMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class XREF_TaxCustomer
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int XREF_TaxCustomer_ID { get; set; }

        public int OrderHeader_ID { get; set; }

        public int Tax_ID { get; set; }

        public virtual OrderHeader OrderHeader { get; set; }

        public virtual Tax Tax { get; set; }
    }
}
