namespace SeniorProjectMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class XREF_CatalogProduct
    {
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int XREF_CatalogProduct_ID { get; set; }

        public int Catalog_ID { get; set; }

        public int Product_ID { get; set; }

        public DateTime? DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public virtual Catalog Catalog { get; set; }

        public virtual Product Product { get; set; }
    }
}
