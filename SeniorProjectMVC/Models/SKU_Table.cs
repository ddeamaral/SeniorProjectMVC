namespace SeniorProjectMVC.Models
{
    using System;
    using System.Collections.Generic;
    using System.ComponentModel.DataAnnotations;
    using System.ComponentModel.DataAnnotations.Schema;
    using System.Data.Entity.Spatial;

    public partial class SKU_Table
    {
        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2214:DoNotCallOverridableMethodsInConstructors")]
        public SKU_Table()
        {
            OrderLines = new HashSet<OrderLine>();
        }

        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int SKU_ID { get; set; }

        [Required]
        [StringLength(250)]
        public string Name { get; set; }

        public bool InStock { get; set; }

        public int Quantity { get; set; }

        [StringLength(1)]
        public string UnitType { get; set; }

        public string Description { get; set; }

        public int Product_ID { get; set; }

        public bool IsActive { get; set; }

        [Column(TypeName = "money")]
        public decimal SKUPrice { get; set; }

        public int Property_ID { get; set; }

        [System.Diagnostics.CodeAnalysis.SuppressMessage("Microsoft.Usage", "CA2227:CollectionPropertiesShouldBeReadOnly")]
        public virtual ICollection<OrderLine> OrderLines { get; set; }

        public virtual Product Product { get; set; }

        public virtual Property Property { get; set; }
    }
}
