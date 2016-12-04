using System.Windows;
using System.Windows.Controls;
using GameStore.REST.JSONs;
using GameStore.WPF.Services;

namespace GameStore.WPF.Windows
{
    /// <summary>
    /// Interaction logic for AuctionList.xaml
    /// </summary>
    public partial class AuctionList : Window
    {

        private AuctionServiceClient AuctionServiceClient { get; }

        public AuctionList()
        {
            InitializeComponent();

            AuctionServiceClient = new AuctionServiceClient("AuctionEndpoint");
            AuctionDataGrid.DataContext = AuctionServiceClient.List();
        }

        private void details_Click(object sender, RoutedEventArgs e)
        {
            Button buttonSender = (Button)sender;
            string id = ((AuctionJson)buttonSender.DataContext).Id.ToString();
            var auctionDetails = new AuctionDetails(id);
            auctionDetails.Show();
            Close();
        }

        private void productsMenu_Click(object sender, RoutedEventArgs e)
        {
            var productList = new ProductList();
            productList.Show();
            Close();
        }
    }
}
