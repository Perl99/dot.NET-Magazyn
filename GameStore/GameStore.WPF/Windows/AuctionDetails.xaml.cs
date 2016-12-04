using System.Windows;
using GameStore.REST.JSONs;
using GameStore.WPF.Services;

namespace GameStore.WPF.Windows
{
    /// <summary>
    /// Interaction logic for AuctionDetails.xaml
    /// </summary>
    public partial class AuctionDetails : Window
    {
        private AuctionJson auction;

        private AuctionServiceClient _auctionServiceClient;

        public AuctionDetails(string auctionId)
        {
            InitializeComponent();

            _auctionServiceClient = new AuctionServiceClient("AuctionEndpoint");
            auction = _auctionServiceClient.Get(auctionId);

            DataContext = auction;
        }

        private void productsMenu_Click(object sender, RoutedEventArgs e)
        {
            var productList = new ProductList();
            productList.Show();
            Close();
        }

        private void auctionsMenu_Click(object sender, RoutedEventArgs e)
        {
            var auctionList = new AuctionList();
            auctionList.Show();
            Close();
        }
    }
}
