using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{

    /// <summary>
    /// Response containing a list of active stop limit orders.
    /// </summary>
    public class ListActiveStopLimitOrderResponseDTO
    {
        /// <summary>
        /// A list of active stop limit orders.
        /// </summary>
        public List<ApiStopLimitOrderDTO> Orders { get; set; }
    }

}
