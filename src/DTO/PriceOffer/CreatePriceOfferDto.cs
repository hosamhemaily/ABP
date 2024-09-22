using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.PriceOffer
{
    public class CreatePriceOfferDto
    {
        public Guid AccountTrademarkId { get; set; }
        public Guid ColorId { get; set; }
        public decimal PriceAgence { get; set; }
        public decimal PriceBank { get; set; }
    }
}
