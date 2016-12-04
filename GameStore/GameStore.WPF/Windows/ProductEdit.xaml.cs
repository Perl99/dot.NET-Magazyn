using System;
using System.Windows;
using GameStore.REST.JSONs;
using GameStore.WPF.Services;

namespace GameStore.WPF.Windows
{
    /// <summary>
    /// Interaction logic for ProductEdit.xaml
    /// </summary>
    public partial class ProductEdit : Window
    {
        private ProductJson product;

        private ProductServiceClient _productServiceClient;

        public ProductEdit(string productId)
        {
            InitializeComponent();

            _productServiceClient = new ProductServiceClient("ProductEndpoint");
            product = _productServiceClient.Get(productId);

            DataContext = product;
        }

        private void cancelButton_Click(object sender, RoutedEventArgs e)
        {
            var productList = new ProductList();
            productList.Show();
            Close();
        }

        private void saveButton_Click(object sender, RoutedEventArgs e)
        {
            try
            {
                ErrorLabel.Content = "";
                _productServiceClient.Save(product);
                cancelButton_Click(sender, e);
            }
            catch (Exception exception)
            {
                ErrorLabel.Content = exception.Message;
            }
        }
    }
}
