using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CallaghanDev.CityIndex.Client.Responses
{



    /// <summary>
    /// Response containing historic price tick data.
    /// </summary>
    public class GetPriceTickResponseDTO
    {
        /// <summary>
        /// A collection of price tick data points.
        /// </summary>
        public List<PriceTickDTO> Ticks { get; set; }
    }


}
