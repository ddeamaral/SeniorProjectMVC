
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Web;

namespace SeniorProjectMVC.Models
{
    [Table("ProductImages")]
    public class ProductImage
    {
        
        [Key]
        public int ProductImageID { get; set; }
        
        public int Product_ID { get; set; }

        [StringLength(2000)]
        public string ProductImagePath { get; set; }

        [StringLength(300)]
        public string ProductImageName { get; set; }

        public virtual Product product { get; set; }
    }
}