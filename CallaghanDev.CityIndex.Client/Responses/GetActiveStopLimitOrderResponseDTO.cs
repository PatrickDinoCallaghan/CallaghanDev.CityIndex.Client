using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{

    /// <summary>
    /// Response for a query for an active stop limit order.
    /// </summary>
    public class GetActiveStopLimitOrderResponseDTO
    {
        /// <summary>
        /// The unique identifier of the active stop/limit order.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// The current status code of the order.
        /// </summary>
        public int Status { get; set; }
    }

}
