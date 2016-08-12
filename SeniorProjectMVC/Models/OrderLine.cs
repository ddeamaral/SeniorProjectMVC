namespace SeniorProjectMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    [Table("OrderLine")]
    public partial class OrderLine
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int OrderLine_ID { get; set; }

        public int OrderHeader_ID { get; set; }

        public int Product_ID { get; set; }

        public int SKU_ID { get; set; }

        public int Quantity { get; set; }

        public int Discount_ID { get; set; }

        public virtual Discount Discount { get; set; }

        public virtual OrderHeader OrderHeader { get; set; }

        public virtual Product Product { get; set; }

        public virtual SKU_Table SKU_Table { get; set; }
    }
}
