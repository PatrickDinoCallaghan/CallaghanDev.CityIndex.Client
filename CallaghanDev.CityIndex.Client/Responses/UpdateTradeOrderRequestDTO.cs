using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{
    /// <summary>
    /// Request to update an existing trade order (for example, to modify attached closing orders).
    /// </summary>
    public class UpdateTradeOrderRequestDTO
    {
        /// <summary>
        /// The unique identifier of the trade order to update.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// The updated stop loss value, if applicable.
        /// </summary>
        public decimal? NewStopLoss { get; set; }

        /// <summary>
        /// The updated take profit value, if applicable.
        /// </summary>
        public decimal? NewTakeProfit { get; set; }
    }

}
