using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{
    /// <summary>
    /// Request to place a new trade order.
    /// </summary>
    public class NewTradeOrderRequestDTO
    {
        /// <summary>
        /// The market identifier for the trade.
        /// </summary>
        public int MarketId { get; set; }

        /// <summary>
        /// The quantity to trade.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The trade direction ("buy" or "sell").
        /// </summary>
        public string Direction { get; set; }

        /// <summary>
        /// The bid price.
        /// </summary>
        public decimal BidPrice { get; set; }

        /// <summary>
        /// The offer price.
        /// </summary>
        public decimal OfferPrice { get; set; }
    }

}
