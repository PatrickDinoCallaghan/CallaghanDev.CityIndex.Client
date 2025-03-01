using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{
    /// <summary>
    /// Request for a list of active orders.
    /// </summary>
    public class ListActiveOrdersRequestDTO
    {
        /// <summary>
        /// The trading account identifier for which to retrieve active orders.
        /// </summary>
        public int TradingAccountId { get; set; }
    }
}
