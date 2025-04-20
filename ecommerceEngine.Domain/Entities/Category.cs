using ecommerceEngine.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EcommerceEngine.Domain.Entities
{
    public class Category : BaseEntity
    {
        public string Name { get; set; }
        public string Description { get; set; }
        public int? ParentId { get; set; }

        // Navigation properties
        public Category Parent { get; set; }
        public ICollection<Category> Subcategories { get; set; }
        public ICollection<Product> Products { get; set; }

        public Category()
        {
            Subcategories = new List<Category>();
            Products = new List<Product>();
        }
    }
}
