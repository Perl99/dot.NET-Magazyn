using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Web.Mvc;
using GameStore.Domain.Entities;

namespace GameStore.WebUI.Models
{

    public class AuctionViewModel
    {
        public Auction Auction { get; set; }

        public List<int> SelectedProductIds { get; set; }

        public AuctionViewModel()
        {
            Auction = new Auction();
        }

        [Display(Name = "Produkty")]
        public MultiSelectList Products { get; set; }
    }

}