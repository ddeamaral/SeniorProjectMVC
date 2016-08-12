using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace SeniorProjectMVC.Models
{
    public class CategoryMenuModel
    {
        public CategoryMenuModel(List<Product> products, List<Category> categories)
        {
            this.Categories = categories;
            this.Products = products;
        }

        public List<Category> Categories { get; set; }

        public List<Product> Products { get; set; }
    }
}