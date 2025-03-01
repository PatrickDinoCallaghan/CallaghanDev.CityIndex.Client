using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{
    /// <summary>
    /// Request to cancel an order.
    /// </summary>
    public class CancelOrderRequestDTO
    {
        /// <summary>
        /// The unique identifier of the order to cancel.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// The trading account identifier (e.g. "ABCD890") associated with the order.
        /// </summary>
        public string TradingAccountId { get; set; }

        /// <summary>
        /// The market identifier of the order.
        /// </summary>
        public int MarketId { get; set; }
    }

}