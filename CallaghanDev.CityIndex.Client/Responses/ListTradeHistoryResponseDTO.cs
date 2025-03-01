using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{

    /// <summary>
    /// Response containing the trade history.
    /// </summary>
    public class ListTradeHistoryResponseDTO
    {
        /// <summary>
        /// A list of historical trade orders.
        /// </summary>
        public List<ApiTradeOrderDTO> Trades { get; set; }
    }
}
