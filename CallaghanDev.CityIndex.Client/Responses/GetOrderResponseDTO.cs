using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{
    /// <summary>
    /// Response for an order query.
    /// May contain details for either a trade or a stop/limit order.
    /// </summary>
    public class GetOrderResponseDTO
    {
        /// <summary>
        /// If the order is a trade/open position, this property is populated.
        /// </summary>
        public ApiTradeOrderDTO TradeOrder { get; set; }

        /// <summary>
        /// If the order is a stop/limit order, this property is populated.
        /// </summary>
        public ApiStopLimitOrderDTO StopLimitOrder { get; set; }
    }

}
