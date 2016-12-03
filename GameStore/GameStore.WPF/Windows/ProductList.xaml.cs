using System.Windows;
using System.Windows.Controls;
using GameStore.WPF.Services;

namespace GameStore.WPF.Windows
{
    /// <summary>
    /// Interaction logic for ProductList.xaml
    /// </summary>
    public partial class ProductList : Window
    {
        private ProductServiceClient ProductServiceClient { get; }

        public ProductList()
        {
            InitializeComponent();

            ProductServiceClient = new ProductServiceClient("ProductEndpoint");
            ProductDataGrid.DataContext = ProductServiceClient.List();
        }

        private void details_Click(object sender, RoutedEventArgs e)
        {
            string id = (string) ((Button)sender).CommandParameter;
            // Pokaż szczegóły i edycję
        }
    }
}
