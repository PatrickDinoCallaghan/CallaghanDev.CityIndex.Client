using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{
    /// <summary>
    /// Request to place a new stop limit order.
    /// </summary>
    public class NewStopLimitOrderRequestDTO
    {
        /// <summary>
        /// The market identifier for the order.
        /// </summary>
        public int MarketId { get; set; }

        /// <summary>
        /// The quantity to order.
        /// </summary>
        public int Quantity { get; set; }

        /// <summary>
        /// The type of order (for example, "limit" or "stop").
        /// </summary>
        public string OrderType { get; set; }

        /// <summary>
        /// The bid price.
        /// </summary>
        public decimal BidPrice { get; set; }

        /// <summary>
        /// The offer price.
        /// </summary>
        public decimal OfferPrice { get; set; }

        /// <summary>
        /// The trigger price (if applicable).
        /// </summary>
        public decimal? TriggerPrice { get; set; }
    }
}
