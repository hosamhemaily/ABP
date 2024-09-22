using System;
using System.Collections.Generic;
using System.Text;

namespace DTO.PriceOffer
{
    public class PriceOfferDto
    {
        public Guid Id { get; set; }
        public string AccountTrademarkName { get; set; }
        public string TrademarkName { get; set; }
        public string VehicleModelName { get; set; }
        public string VehicleTypeName { get; set; }
        public string ColorName { get; set; }
        public decimal PriceAgence { get; set; }
        public decimal PriceBank { get; set; }
    }
}
