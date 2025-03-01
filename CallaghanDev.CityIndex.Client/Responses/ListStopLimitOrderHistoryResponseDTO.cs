using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{
    /// <summary>
    /// Response containing the stop limit order history.
    /// </summary>
    public class ListStopLimitOrderHistoryResponseDTO
    {
        /// <summary>
        /// A list of historical stop limit orders.
        /// </summary>
        public List<ApiStopLimitOrderDTO> Orders { get; set; }
    }

}
