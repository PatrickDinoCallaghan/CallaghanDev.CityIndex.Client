using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{
    /// <summary>
    /// Request to update an existing stop limit order.
    /// </summary>
    public class UpdateStopLimitOrderRequestDTO
    {
        /// <summary>
        /// The unique identifier of the order to update.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// The new trigger price.
        /// </summary>
        public decimal NewTriggerPrice { get; set; }

        /// <summary>
        /// The new quantity for the order.
        /// </summary>
        public int NewQuantity { get; set; }
    }
}
