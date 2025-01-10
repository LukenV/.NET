using examen_septembre_2022.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace examen_septembre_2022.ViewModels
{
    class ProductModel
    {
        public int ProductID { get; set; }
        public string ProductName { get; set; }
        public decimal? UnitPrice { get; set; }
        public short? UnitsInStock { get; set; }
        public string SupplierContactName { get; set; }
        public string QuantityPerUnit { get; set; }
        public Product Product { get; set; }
    }
}
