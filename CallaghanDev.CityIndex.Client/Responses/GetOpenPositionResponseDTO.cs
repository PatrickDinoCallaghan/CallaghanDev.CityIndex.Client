using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{
    /// <summary>
    /// Response containing details of an open position.
    /// </summary>
    public class GetOpenPositionResponseDTO
    {
        /// <summary>
        /// The unique identifier of the open position.
        /// </summary>
        public int OrderId { get; set; }

        /// <summary>
        /// The size of the position.
        /// </summary>
        public int PositionSize { get; set; }

        /// <summary>
        /// The current profit or loss.
        /// </summary>
        public decimal ProfitLoss { get; set; }
    }

}
