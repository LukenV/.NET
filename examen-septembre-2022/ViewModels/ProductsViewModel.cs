using examen_septembre_2022.Models;
using examen_septembre_2022.ViewModels;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication1.ViewModels;

namespace examen_septembre_2022
{
    class ProductsViewModel : INotifyPropertyChanged
    {
        private NorthwindContext _context = new NorthwindContext();

        private List<ProductModel> _listProducts;
        private List<OrderModel> _listOrders;
        private ProductModel _selectedProduct;
        private DelegateCommand _saveProduct;

        public List<ProductModel> ListProducts { get => _listProducts = _listProducts ?? loadProducts(); set => _listProducts = value; }
        public List<OrderModel> ListOrders { get => _listOrders = _listOrders ?? loadOrders(); set => _listOrders = value; }

        public ProductModel SelectedProduct
        {
            get => _selectedProduct;
            set
            {
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                    OnPropertyChanged(nameof(SelectedProduct));
                }
            }
        }

        private List<ProductModel> loadProducts()
        {
            return _context.Products.Select(p => new ProductModel
            {
                ProductID = p.ProductId,
                ProductName = p.ProductName,
                UnitPrice = p.UnitPrice,
                UnitsInStock = p.UnitsInStock,
                SupplierContactName = p.Supplier.ContactName,
                QuantityPerUnit = p.QuantityPerUnit,
                Product = p
            }).ToList();
        }

        private List<OrderModel> loadOrders()
        {
            // Recuperer la liste des produits et le total des ventes pour chaque produit
            return _context.OrderDetails
                .GroupBy(od => od.ProductId)
                .Select(g => new OrderModel
                {
                    OrderProductID = g.Key,
                    OrderProductTotalSales = g.Sum(od => od.Quantity * od.UnitPrice)
                })
                .OrderBy(o => o.OrderProductID)
                .ToList();
        }

        public event PropertyChangedEventHandler? PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public DelegateCommand SaveProduct
        {
            get { return _saveProduct = _saveProduct ?? new DelegateCommand(UpdateProduct);  }
        }

        public void UpdateProduct()
        {
            if (SelectedProduct == null) return;

            SelectedProduct.Product.ProductName = SelectedProduct.ProductName;
            SelectedProduct.Product.QuantityPerUnit = SelectedProduct.QuantityPerUnit;
            _context.SaveChanges();

            MessageBox.Show("Produit mis à jour");
        }

    }

}
