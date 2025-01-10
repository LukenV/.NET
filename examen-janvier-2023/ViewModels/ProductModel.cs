using examen_janvier_2023.Model;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen_janvier_2023.ViewModels
{
    class ProductModel
    {
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string ProductCategoryName { get; set; }
        public string ProductSupplierName { get; set; }
        public Product Product { get; set; }
        public ProductModel(Product product) {
            Product = product;
            ProductId = product.ProductId;
            ProductName = product.ProductName;
            ProductCategoryName = product?.Category?.CategoryName ?? "";
            ProductSupplierName = product?.Supplier?.ContactName ?? "";
        }
    }
}
