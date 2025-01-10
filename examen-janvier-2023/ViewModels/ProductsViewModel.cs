using examen_janvier_2023.Model;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using WpfApplication1.ViewModels;

namespace examen_janvier_2023.ViewModels
{
    class ProductsViewModel : INotifyPropertyChanged
    {
        private List<ProductModel> _listProducts;
        private List<OrderModel> _listOrders;
        private NorthwindContext context = new NorthwindContext();
        private DelegateCommand _discontinueProduct;
        private ProductModel _selectedProduct;

        public List<ProductModel> ListProducts {
            get { return _listProducts = _listProducts ?? loadProducts(); }
            set { _listProducts = value; OnPropertyChanged(nameof(ListProducts)); }
        }

        public List<OrderModel> ListOrders
        {
            get { return _listOrders = _listOrders ?? loadOrders(); }
            set { _listOrders = value; OnPropertyChanged(nameof(ListOrders)); }
        }

        private List<ProductModel> loadProducts()
        {
            List<ProductModel> localCollection = new List<ProductModel>();

            foreach (var item in context.Products)
            {
                if (item.Discontinued) continue;
                localCollection.Add(new ProductModel(item));
            }


            return localCollection;
        }

        private List<OrderModel> loadOrders()
        {
            var query = from order in context.Orders
                        join orderDetail in context.OrderDetails on order.OrderId equals orderDetail.OrderId
                        join product in context.Products on orderDetail.ProductId equals product.ProductId
                        group product by order.ShipCountry into countryGroup
                        select new
                        {
                            CountryName = countryGroup.Key,
                            ProductCount = countryGroup.Select(p => p.ProductId).Distinct().Count()
                        };

            var sortedQuery = query.OrderByDescending(x => x.ProductCount);

            List<OrderModel> localCollection = new List<OrderModel>();

            foreach (var item in sortedQuery)
            {
                if (item.ProductCount == 0) continue;
                if (item.CountryName.Trim().Length == 0) continue;
                localCollection.Add(new OrderModel
                {
                    CountryName = item.CountryName,
                    OrderNb = item.ProductCount
                });
            }


            return localCollection;
        }

        public ProductModel SelectedProduct
        {
            get { return _selectedProduct; }
            set { 
                if (_selectedProduct != value)
                {
                    _selectedProduct = value;
                    OnPropertyChanged(nameof(SelectedProduct));
                }
               
            }
        }

        public DelegateCommand DiscontinueCommand
        {
            get { return _discontinueProduct = _discontinueProduct ?? new DelegateCommand(DiscontinueProduct); }
        }

        private void DiscontinueProduct()
        {
            if (SelectedProduct == null) return;
            SelectedProduct.Product.Discontinued = true;
            context.SaveChanges();
            ListProducts = loadProducts();
            SelectedProduct = null;
            MessageBox.Show("Le produit a bien été retiré de la vente.");
        }

        public event PropertyChangedEventHandler PropertyChanged;

        protected virtual void OnPropertyChanged(string propertyName)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }
    }
}
